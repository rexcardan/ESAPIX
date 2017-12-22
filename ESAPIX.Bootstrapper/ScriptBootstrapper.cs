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
using ESAPIX.AppKit.Exceptions;
using ESAPIX.Bootstrapper;
using ESAPIX.AppKit;

#endregion

namespace ESAPIX.Bootstrapper
{
    public class ScriptBootstrapper<T> : BootstrapperBase<T> where T : Window
    {
        private readonly DispatcherFrame _frame;

        public ScriptBootstrapper(PluginContext ctx, DispatcherFrame frame) : base()
        {
            XamlAssemblyLoader.LoadAssemblies();
            _ctx = ctx;
            _frame = frame;
        }

        protected override void CleanUp()
        {
            base.CleanUp();
            _frame.Continue = false;
        }

        public new void Run()
        {
            var ui = new Thread(() =>
            {
                try
                {
                    if (Splash != null) Splash.ShowDialog();
                    base.Run();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"SCRIPT ERROR (Closing Thread) \n Exception Details : \n {e.ToString()}");
                    _frame.Continue = false;
                    if (Shell?.Dispatcher != null)
                        Shell.Dispatcher.UnhandledException -= Dispatcher_UnhandledException;
                    var main = (Window)this.Shell;
                    if (main != null && main.IsActive) main.Close();
                }
            });
            ui.SetApartmentState(ApartmentState.STA);
            ui.Start();
        }
    }
}