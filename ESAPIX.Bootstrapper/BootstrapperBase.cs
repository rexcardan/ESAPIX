using Prism.Unity;
using System;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Events;
using ESAPIX.Interfaces;
using ESAPIX.AppKit.Exceptions;
using System.Windows.Threading;
using System.Threading;
using ESAPIX.Bootstrapper.Helpers;
using ESAPIX.Common;
using System.Linq;

namespace ESAPIX.Bootstrapper
{
    public class BootstrapperBase<T> : UnityBootstrapper where T : Window
    {
        protected IScriptContext _ctx;
        private EventAggregator _ea;
        private ManualResetEvent mre = new ManualResetEvent(false); //For splash screen

        public BootstrapperBase()
        {
            _ea = new EventAggregator();
        }

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<T>();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterInstance<IScriptContext>(_ctx);
            Container.RegisterInstance<IEventAggregator>(_ea);
            Container.RegisterInstance(Container);
            AdditionalRegistrations?.Invoke(Container);
        }

        protected async override void InitializeShell()
        {
            var shell = (Window)Shell;
            _ctx.UIDispatcher = shell.Dispatcher;

            //Needed to not crash app on multithreading exceptions
            shell.Dispatcher.UnhandledException += Dispatcher_UnhandledException;
            shell.Closed += (send, args) =>
            {
                CleanUp();
                shell.Dispatcher.UnhandledException -= Dispatcher_UnhandledException;
                Application.Current.Shutdown();
            };

            //Give the bootstrapper the opportunity to inject some stuff if desired
            if (shell != null)
                shell.ContentRendered += shell_ContentRendered;

            //If there is a splash screen.Show it here
            if (Splash != null)
            {
                Splash.Show();
                Splash.Closing += (ob, args) => { mre.Set(); };
                await Task.Run(() => { mre.WaitOne(); });
            }

            shell.ShowDialog();
            shell.ContentRendered -= shell_ContentRendered;
        }

        protected Window Splash { get; set; }

        protected virtual void OnContentRendered(Window shell) { }

        protected virtual void CleanUp() { }

        /// <summary>
        /// Allows for registered services, views, etc with the UnityContainer
        /// </summary>
        public Action<IUnityContainer> AdditionalRegistrations { get; set; }

        public void Run(string[] commandLineArgs)
        {
            var sac = _ctx as StandAloneContext;
            {
                string patientId = ArgumentParser.GetPatientId(commandLineArgs);
                if (!string.IsNullOrEmpty(patientId))
                {
                    sac.SetPatient(patientId);
                }
            }
            { //USER
                string currentUser = ArgumentParser.CurrentUserId(commandLineArgs);
                if (!string.IsNullOrEmpty(currentUser))
                {
                    sac.CurrentUser = new ESAPIX.Facade.API.User();
                    sac.CurrentUser.Id = currentUser;
                }
            }
            {
                string courseId = ArgumentParser.GetCourseId(commandLineArgs);
                if (!string.IsNullOrEmpty(courseId))
                {
                    var course = sac.Patient.Courses.FirstOrDefault(c => c.Id == courseId);
                    sac.SetCourse(course, false);

                    {
                        //Only do this if course is set
                        var planUid = ArgumentParser.GetPlanSetup(commandLineArgs);
                        if (!string.IsNullOrEmpty(planUid))
                        {
                            var plan = sac.Course.PlanSetups.FirstOrDefault(p => p.UID == planUid);
                            sac.SetPlanSetup(plan);
                        }
                    }

                    {
                        var plansInScope = ArgumentParser.GetPlansInScope(commandLineArgs);
                        if (plansInScope != null && plansInScope.Any())
                        {
                            var plans = sac.Course.PlanSetups.Where(p => plansInScope.Contains(p.UID));
                            sac.SetPlansInScope(plans);
                        }
                    }

#if !VMS110
                    {
                        var externalPlanUid = ArgumentParser.GetExternalPlanSetup(commandLineArgs);
                        if (!string.IsNullOrEmpty(externalPlanUid))
                        {
                            var plan = sac.Course.ExternalPlanSetups.FirstOrDefault(p => p.UID == externalPlanUid);
                            sac.SetExternalPlanSetup(plan);
                        }
                    }
                    {
                        var brachyPlanUid = ArgumentParser.GetBrachyPlanSetup(commandLineArgs);
                        if (!string.IsNullOrEmpty(brachyPlanUid))
                        {
                            var plan = sac.Course.BrachyPlanSetups.FirstOrDefault(p => p.UID == brachyPlanUid);
                            sac.SetBrachyPlanSetup(plan);
                        }
                    }
                    {
                        var explansInScope = ArgumentParser.GetExternalPlansInScope(commandLineArgs);
                        if (explansInScope != null && explansInScope.Any())
                        {
                            var plans = sac.Course.ExternalPlanSetups.Where(p => explansInScope.Contains(p.UID));
                            sac.SetExternalPlansInScope(plans);
                        }
                    }
                    {
                        var brachyInScope = ArgumentParser.GetBrachyPlansInScope(commandLineArgs);
                        if (brachyInScope != null && brachyInScope.Any())
                        {
                            var plans = sac.Course.BrachyPlanSetups.Where(p => brachyInScope.Contains(p.UID));
                            sac.SetBrachyPlansInScope(plans);
                        }
                    }
#endif
#if (VMS151 || VMS150 || VMS155)
                    {
                        var ionPlansInScope = ArgumentParser.GetIonPlansInScope(commandLineArgs);
                        if (ionPlansInScope != null && ionPlansInScope.Any())
                        {
                            var plans = sac.Course.IonPlanSetups.Where(p => ionPlansInScope.Contains(p.UID));
                            sac.SetIonPlansInScope(plans);
                        }
                    }

                    {
                        var planUid = ArgumentParser.GetIonPlanSetup(commandLineArgs);
                        if (!string.IsNullOrEmpty(planUid))
                        {
                            var plan = sac.Course.IonPlanSetups.FirstOrDefault(p => p.UID == planUid);
                            sac.SetIonPlanSetup(plan);
                        }
                    }
#endif
                }
            }
            base.Run();
        }
        #region PLUMBING
        /// <summary>
        /// A method to help push errors to the UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Dispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            if (e.Exception is ScriptException)
            {
                MessageBox.Show(e.Exception.InnerException.Message);
            }
            else
            {
                MessageBox.Show(e.Exception.GetRootException().Message);
            }
        }
        /// <summary>
        ///     This method hijacks the application and injects a patient selector to mimick the script context of a normal plugin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shell_ContentRendered(object sender, EventArgs e)
        {
            var shell = sender as Window;
            OnContentRendered(shell);
            shell.ContentRendered -= shell_ContentRendered;
            //Force foreground
            shell.Activate();
        }

        #endregion
    }
}
