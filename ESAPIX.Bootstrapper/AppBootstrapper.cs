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

#endregion

namespace ESAPIX.Bootstrapper
{
    public class AppBootstrapper<T> : UnityBootstrapper where T : Window
    {
        private IScriptContext _ctx;
        private readonly EventAggregator _ea;

        /// <summary>
        /// Constructs a bootstrapper for standalone applications from a username, password
        /// </summary>
        /// <param name="vmsUsername">username for VMS access</param>
        /// <param name="vmsPassword">password for VMS access</param>
        /// <param name="singleThread">indicates whether or not to use a single thread (default is multithread)</param>
        public AppBootstrapper(string vmsUsername, string vmsPassword, bool singleThread = false)
        {
            FacadeInitializer.Initialize();
            _ctx = StandAloneContext.Create(vmsUsername, vmsPassword, singleThread);
            _ea = new EventAggregator();
        }

        /// <summary>
        /// Constructs a bootstrapper for standalone applications from a offline context json file
        /// </summary>
        /// <param name="offlineContextPath">the path to the offline context json file</param>
        public AppBootstrapper(string offlineContextPath)
        {
            FacadeInitializer.Initialize();
            var json = File.ReadAllText(offlineContextPath);
            var ctx = JsonConvert.DeserializeObject<OfflineContext>(json, Facade.Serialization.FacadeSerializer.DeserializeSettings);
            ctx.Thread = new AppComThread();
            _ctx = ctx;
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
            _ctx.UIDispatcher = shell.Dispatcher;
            shell.Closed += (send, args) =>
            {
                //Dispose ESAPI and shutdown app
                if(_ctx is StandAloneContext)
                {
                    (_ctx as StandAloneContext).Dispose();
                }
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
            if (shell != null && _ctx is StandAloneContext)
            {
                var sac = _ctx as StandAloneContext;
                var currentContent = (UIElement) shell.Content;
                var stackPanel = new DockPanel();
                stackPanel.VerticalAlignment = VerticalAlignment.Stretch;
                shell.Content = stackPanel;
                var selectPat = new SelectPatient(sac);
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