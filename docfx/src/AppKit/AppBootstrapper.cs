using ESAPIX.AppKit.Splash;
using ESAPIX.Interfaces;
using Prism.Events;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.Unity;
using ESAPIX.AppKit.Overlay;
using System.Windows.Threading;

namespace ESAPIX.AppKit
{
    public class AppBootstrapper<T> : UnityBootstrapper where T : Window
    {
        private EventAggregator _ea;
        private StandAloneContext _ctx;

        public AppBootstrapper(string vmsUsername, string vmsPassword, bool singleThread = false)
        {
            if (singleThread)
            {
                _ctx = StandAloneContext.CreateSingleThread(vmsUsername, vmsPassword);
            }
            else
            {
                _ctx = StandAloneContext.Create(vmsUsername, vmsPassword);
            }
            _ea = new EventAggregator();
        }

        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<T>();
        }
    
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            this.Container.RegisterInstance<IScriptContext>(_ctx);
            this.Container.RegisterInstance<IEventAggregator>(_ea);
            this.Container.RegisterInstance(this.Container);
        }

        protected override void InitializeShell()
        {
            var shell = (Window)this.Shell;
            shell.Closed += (send, args) =>
            {
                //Dispose ESAPI and shutdown app
                _ctx.Dispose();
                Application.Current.Shutdown();
            };

            if (shell != null)
            {
                //Inject patient selection
                shell.ContentRendered += shell_ContentRendered;
            }
            shell.MinWidth = 750;
            shell.ShowDialog();
            shell.ContentRendered -= shell_ContentRendered;
        }

        public new void Run(Func<Window> getSplash = null)
        {
            if (getSplash != null)
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                {
                    getSplash().ShowDialog();
                }));
            }
            base.Run();
        }

        #region PLUMBING
        /// <summary>
        /// This method hijacks the application and injects a patient selector to mimick the script context of a normal plugin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void shell_ContentRendered(object sender, EventArgs e)
        {
            var shell = sender as Window;
            if (shell != null)
            {
                var currentContent = (UIElement)shell.Content;
                var stackPanel = new DockPanel();
                stackPanel.VerticalAlignment = VerticalAlignment.Stretch;
                shell.Content = stackPanel;
                var selectPat = new SelectPatient(_ctx);
                var selectPatContent = (FrameworkElement)selectPat.Content;
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
