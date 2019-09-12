#region

using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using ESAPIX.AppKit;
using ESAPIX.AppKit.Overlay;
using System.Linq;
using ESAPIX.Common;
using System;
using Prism.Unity;
using Prism.Ioc;
using CommonServiceLocator;

#endregion

namespace ESAPIX.Bootstrapper
{
    public class AppBootstrapper<T> : PrismApplication where T : Window
    {
        private EventHandler _coverHandler;

        public bool IsPatientSelectionEnabled { get; set; } = true;

        /// <summary>
        /// Constructs a bootstrapper for standalone applications from a username, password
        /// </summary>
        /// <param name="vmsUsername">username for VMS access</param>
        /// <param name="vmsPassword">password for VMS access</param>
        /// <param name="singleThread">indicates whether or not to use a single thread (default is multithread)</param>
        public AppBootstrapper(Func<VMS.TPS.Common.Model.API.Application> createAppFunc) : base()
        {
            var thread = AppComThread.Instance;
            thread.SetContext(createAppFunc);
            _coverHandler = new EventHandler((o, args) =>
            {
                OnContentRendered(o as Window);
            });
        }

        /// <summary>
        /// This method will hijack the main window and place a patient selction toolbox
        /// overlaid in the application
        /// </summary>
        /// <param name="shell"></param>
        protected void OnContentRendered(Window shell)
        {
            if (shell != null && IsPatientSelectionEnabled)
            {
                var sac = _ctx as StandAloneContext;
                var currentContent = (UIElement)shell.Content;
                var stackPanel = new DockPanel();
                stackPanel.VerticalAlignment = VerticalAlignment.Stretch;
                shell.Content = stackPanel;
                var selectPat = new SelectPatient();
                var selectPatContent = (FrameworkElement)selectPat.Content;
                selectPatContent.DataContext = selectPat;
                selectPat.Content = null;
                stackPanel.Children.Add(selectPatContent);
                stackPanel.Children.Add(currentContent);
                DockPanel.SetDock(selectPatContent, Dock.Top);
                DockPanel.SetDock(currentContent, Dock.Top);
                shell.WindowState = WindowState.Maximized;
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

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            throw new NotImplementedException();
        }

        protected override Window CreateShell()
        {
            var win = ServiceLocator.Current.GetInstance<T>();
            win.ContentRendered += OnContentRendered;
        }
    }
}