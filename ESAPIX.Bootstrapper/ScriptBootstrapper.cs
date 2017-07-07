#region

using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using ESAPIX.Helpers;
using ESAPIX.Interfaces;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Unity;

#endregion

namespace ESAPIX.AppKit
{
    public class ScriptBootstrapper<T> : UnityBootstrapper where T : Window
    {
        private readonly IEventAggregator _ea;
        private readonly DispatcherFrame _frame;

        private readonly PluginContext _sc;

        public ScriptBootstrapper(PluginContext ctx, DispatcherFrame frame)
        {
            XamlAssemblyLoader.LoadAssemblies();
            _sc = ctx;
            _ea = new EventAggregator();
            _frame = frame;
        }

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<T>();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterInstance<IScriptContext>(_sc);
            Container.RegisterInstance(_ea);
            Container.RegisterInstance(Container);
        }

        protected override void InitializeShell()
        {
            var shell = (Window) Shell;
            _sc.UIDispatcher = shell.Dispatcher;
            shell.ShowDialog();
            _frame.Continue = false;
        }

        public void Run(Func<Window> getSplash = null)
        {
            var ui = new Thread(() =>
            {
                try
                {
                    if (getSplash != null) getSplash().ShowDialog();
                    base.Run();
                }
                catch(Exception e)
                {
                    MessageBox.Show($"SCRIPT ERROR (Closing Thread) \n Exception Details : \n {e.ToString()}");
                    _sc.Thread.Invoke(() =>
                    {
                        _frame.Continue = false;
                    });
                }
            });
            ui.SetApartmentState(ApartmentState.STA);
            ui.Start();
        }
    }
}