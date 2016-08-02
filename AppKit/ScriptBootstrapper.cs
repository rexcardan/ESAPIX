using ESAPIX.Helpers;
using ESAPIX.Interfaces;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ESAPIX.AppKit
{
    public class ScriptBootstrapper<T> : UnityBootstrapper where T : Window
    {
        public Window _vmsWindow;

        //private EventAggregator _ea;
        private IScriptContext _sc;
        private IEventAggregator _ea;
        private DispatcherFrame _frame;

        public ScriptBootstrapper(PluginContext ctx, DispatcherFrame frame)
        {
            XamlAssemblyLoader.LoadAssemblies();
            _sc = ctx;
            _ea = new EventAggregator();
            _frame = frame;
        }

        protected override DependencyObject CreateShell()
        {
            return Activator.CreateInstance<T>();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            this.Container.RegisterInstance<IScriptContext>(_sc);
            this.Container.RegisterInstance<IEventAggregator>(_ea);
            this.Container.RegisterInstance<IUnityContainer>(this.Container);
        }

        protected override void InitializeShell()
        {
            CreateShell();
            var shell = (Window)this.Shell;
            shell.ShowDialog();
            _frame.Continue = false;
        }

        public new void Run(Func<Window> getSplash = null)
        {
            Thread ui = new Thread(() =>
            {
                if (getSplash != null) { getSplash().ShowDialog(); }
                base.Run();
            });
            ui.SetApartmentState(ApartmentState.STA);
            ui.Start();
        }
    }
}
