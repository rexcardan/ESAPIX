﻿using Prism.Unity;
using System;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Events;
using ESAPIX.Interfaces;
using ESAPIX.AppKit.Exceptions;
using System.Windows.Threading;
using System.Threading;

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
                Splash.Closing += (ob, args)=> { mre.Set(); } ;
                await Task.Run(() => { mre.WaitOne(); });
            }
            InitializeModules();
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
