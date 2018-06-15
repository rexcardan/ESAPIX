#region

using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using ESAPIX.AppKit;
using ESAPIX.AppKit.Overlay;
using ESAPIX.Facade.Serialization;
using ESAPIX.Bootstrapper.Helpers;
using System.Linq;
using ESAPIX.Common;
using System;

#endregion

namespace ESAPIX.Bootstrapper
{
    public class AppBootstrapper<T> : BootstrapperBase<T> where T : Window
    {

        /// <summary>
        /// Constructs a bootstrapper for standalone applications from a username, password
        /// </summary>
        /// <param name="vmsUsername">username for VMS access</param>
        /// <param name="vmsPassword">password for VMS access</param>
        /// <param name="singleThread">indicates whether or not to use a single thread (default is multithread)</param>
        public AppBootstrapper(Func<VMS.TPS.Common.Model.API.Application> createAppFunc) : base()
        {
            _ctx = new StandAloneContext(createAppFunc);
            _ctx.UIDispatcher = Dispatcher.CurrentDispatcher;
        }

        /// <summary>
        /// Constructs a bootstrapper for standalone applications from a offline context json file
        /// </summary>
        /// <param name="offlineContextPath">the path to the offline context json file</param>
        public AppBootstrapper(string offlineContextPath) : base()
        {
            var ctx = FacadeSerializer.DeserializeContext(offlineContextPath);
            ctx.Thread = new AppComThread();
            _ctx = ctx;
        }

        /// <summary>
        /// This method will hijack the main window and place a patient selction toolbox
        /// overlaid in the application
        /// </summary>
        /// <param name="shell"></param>
        protected override void OnContentRendered(Window shell)
        {
            base.OnContentRendered(shell);
            if (shell != null)
            {
                var sac = _ctx as StandAloneContext;
                var currentContent = (UIElement)shell.Content;
                var stackPanel = new DockPanel();
                stackPanel.VerticalAlignment = VerticalAlignment.Stretch;
                shell.Content = stackPanel;
                var selectPat = new SelectPatient(sac);
                var selectPatContent = (FrameworkElement)selectPat.Content;
                selectPatContent.DataContext = selectPat;
                selectPat.Content = null;
                stackPanel.Children.Add(selectPatContent);
                stackPanel.Children.Add(currentContent);
                DockPanel.SetDock(selectPatContent, Dock.Top);
                DockPanel.SetDock(currentContent, Dock.Top);
                shell.Content = stackPanel;
            }
        }

        protected override void CleanUp()
        {
            base.CleanUp();
            //Dispose ESAPI and shutdown app
            if (_ctx is StandAloneContext)
            {
                (_ctx as StandAloneContext).Dispose();
                Application.Current.Shutdown();
            }
        }

        public void Run(string[] commandLineArgs)
        {
            var sac = _ctx as StandAloneContext;
            string patientId = ArgumentParser.GetPatientId(commandLineArgs);
            if (!string.IsNullOrEmpty(patientId))
            {
                sac.SetPatient(patientId);
            }

            string courseId = ArgumentParser.GetCourseId(commandLineArgs);
            if (!string.IsNullOrEmpty(courseId))
            {
                var course = sac.Patient.Courses.FirstOrDefault(c => c.Id == courseId);
                sac.SetCourse(course);

                //Only do this if course is set
                var planUid = ArgumentParser.GetPlanSetup(commandLineArgs);
                if (!string.IsNullOrEmpty(planUid))
                {
                    var plan = sac.Course.PlanSetups.FirstOrDefault(p => p.UID == planUid);
                    sac.SetPlanSetup(plan);
                }

#if !VMS110
                var externalPlanUid = ArgumentParser.GetExternalPlanSetup(commandLineArgs);
                if (!string.IsNullOrEmpty(planUid))
                {
                    var plan = sac.Course.ExternalPlanSetups.FirstOrDefault(p => p.UID == externalPlanUid);
                    sac.SetExternalPlanSetup(plan);
                }

                var brachyPlanUid = ArgumentParser.GetBrachyPlanSetup(commandLineArgs);
                if (!string.IsNullOrEmpty(planUid))
                {
                    var plan = sac.Course.BrachyPlanSetups.FirstOrDefault(p => p.UID == brachyPlanUid);
                    sac.SetBrachyPlanSetup(plan);
                }

                var explansInScope = ArgumentParser.GetExternalPlansInScope(commandLineArgs);
                if (explansInScope != null && explansInScope.Any())
                {
                    var plans = sac.Course.ExternalPlanSetups.Where(p => explansInScope.Contains(p.UID));
                    sac.SetExternalPlansInScope(plans);
                }

                var brachyInScope = ArgumentParser.GetBrachyPlansInScope(commandLineArgs);
                if (brachyInScope != null && brachyInScope.Any())
                {
                    var plans = sac.Course.BrachyPlanSetups.Where(p => explansInScope.Contains(p.UID));
                    sac.SetBrachyPlansInScope(plans);
                }
#endif
                var plansInScope = ArgumentParser.GetPlansInScope(commandLineArgs);
                if (plansInScope != null && plansInScope.Any())
                {
                    var plans = sac.Course.PlanSetups.Where(p => plansInScope.Contains(p.UID));
                    sac.SetPlansInScope(plans);
                }

#if (VMS150 || VMS151 || VMS155)
                var ionPlansInScope = ArgumentParser.GetIonPlansInScope(commandLineArgs);
                if (ionPlansInScope != null && ionPlansInScope.Any())
                {
                    var plans = sac.Course.IonPlanSetups.Where(p => explansInScope.Contains(p.UID));
                    sac.SetIonPlansInScope(plans);
                }

                var ionPlanUid = ArgumentParser.GetIonPlanSetup(commandLineArgs);
                if (!string.IsNullOrEmpty(planUid))
                {
                    var plan = sac.Course.IonPlanSetups.FirstOrDefault(p => p.UID == externalPlanUid);
                    sac.SetIonPlanSetup(plan);
                }
#endif
            }
        }
    }
}