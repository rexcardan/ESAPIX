using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Events;
using ESAPIX.Interfaces;
using ESAPIX.AppKit;
using ESAPIX.AppKit.Exceptions;
using System.Windows.Threading;

namespace ESAPIX.Bootstrapper
{
    public class BootstrapperBase<T> : UnityBootstrapper where T : Window
    {
        protected IScriptContext _ctx;
        private EventAggregator _ea;

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
        }

        protected override void InitializeShell()
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

            shell.ShowDialog();
            shell.ContentRendered -= shell_ContentRendered;
        }

        protected virtual void OnContentRendered(Window shell) { }

        protected virtual void CleanUp() { }



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
