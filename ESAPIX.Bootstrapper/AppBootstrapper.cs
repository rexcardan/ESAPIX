#region

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using ESAPIX.AppKit;
using ESAPIX.AppKit.Overlay;
using ESAPIX.Interfaces;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Unity;
using Newtonsoft.Json;
using System.IO;
using ESAPIX.Facade.Serialization;
using ESAPIX.AppKit.Exceptions;

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
        public AppBootstrapper(string vmsUsername, string vmsPassword, bool singleThread = false) : base()
        {
            FacadeInitializer.Initialize();
            _ctx = StandAloneContext.Create(vmsUsername, vmsPassword, singleThread);
            _ctx.UIDispatcher = Dispatcher.CurrentDispatcher;
        }

        /// <summary>
        /// Constructs a bootstrapper for standalone applications from a offline context json file
        /// </summary>
        /// <param name="offlineContextPath">the path to the offline context json file</param>
        public AppBootstrapper(string offlineContextPath) : base()
        {
            FacadeInitializer.Initialize();
            var ctx = FacadeSerializer.DeserializeContext(offlineContextPath);
            ctx.Thread = new AppComThread();
            _ctx = ctx;
        }


        public void Run(Func<Window> getSplash = null)
        {
            if (getSplash != null)
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new Action(() => { getSplash().ShowDialog(); }));
            base.Run();
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
            }
        }
    }
}