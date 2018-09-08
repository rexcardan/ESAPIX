#region

using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using ESAPIX.AppKit;
using ESAPIX.AppKit.Overlay;
using ESAPIX.Facade.Serialization;
using System.Linq;
using ESAPIX.Common;
using System;

#endregion

namespace ESAPIX.Bootstrapper
{
    public class AppBootstrapper<T> : BootstrapperBase<T> where T : Window
    {
        public bool IsPatientSelectionEnabled { get; set; } = true;

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
            if (shell != null && IsPatientSelectionEnabled)
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
    }
}