#region

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using ESAPIX.AppKit.Overlay;
using ESAPIX.Interfaces;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Unity;

#endregion

namespace ESAPIX.AppKit
{
    public class AppBootstrapper<T> : UnityBootstrapper where T : Window
    {
        private readonly StandAloneContext _ctx;
        private readonly EventAggregator _ea;

        public AppBootstrapper(string vmsUsername, string vmsPassword, bool singleThread = false)
        {
            _ctx = StandAloneContext.Create(vmsUsername, vmsPassword);
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
            var shell = (Window) Shell;
            shell.Closed += (send, args) =>
            {
                //Dispose ESAPI and shutdown app
                _ctx.Dispose();
                Application.Current.Shutdown();
            };

            if (shell != null)
                shell.ContentRendered += shell_ContentRendered;
            shell.MinWidth = 750;
            shell.ShowDialog();
            shell.ContentRendered -= shell_ContentRendered;
        }

        public void Run(Func<Window> getSplash = null)
        {
            if (getSplash != null)
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new Action(() => { getSplash().ShowDialog(); }));
            base.Run();
        }

        #region PLUMBING

        /// <summary>
        ///     This method hijacks the application and injects a patient selector to mimick the script context of a normal plugin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shell_ContentRendered(object sender, EventArgs e)
        {
            var shell = sender as Window;
            if (shell != null)
            {
                var currentContent = (UIElement) shell.Content;
                var stackPanel = new DockPanel();
                stackPanel.VerticalAlignment = VerticalAlignment.Stretch;
                shell.Content = stackPanel;
                var selectPat = new SelectPatient(_ctx);
                var selectPatContent = (FrameworkElement) selectPat.Content;
                selectPatContent.DataContext = selectPat;
                selectPat.Content = null;
                stackPanel.Children.Add(selectPatContent);
                stackPanel.Children.Add(currentContent);
                DockPanel.SetDock(selectPatContent, Dock.Top);
                DockPanel.SetDock(currentContent, Dock.Top);
                shell.Content = stackPanel;
                shell.ContentRendered -= shell_ContentRendered;
            }
        }

        #endregion
    }
}