using ESAPIX.AppKit;
using ESAPIX.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using VMS.TPS.Common.Model.API;

namespace ESAPIX.Bootstrapper
{
    public abstract class XScriptBase
    {
        public void Execute(ScriptContext context, Window window)
        {
            var scriptContext = new ESAPIX.Facade.API.ScriptContext(context);
            //When hooked up to bootstrapper (comment out otherwise)
            FacadeInitializer.Initialize();
            //Get this window barely visible so that when it does show, it isn't ugly ;)
            window.Height = window.Width = 0;
            window.WindowStyle = WindowStyle.None;
            window.Hide();
            window.Loaded += Window_Loaded;

            var plugCtx = new PluginContext(scriptContext, window);
            var frame = new DispatcherFrame();
            XContext.Instance.CurrentContext = plugCtx;
            XExecute(plugCtx, frame);
            Dispatcher.PushFrame(frame);
        }

        #region WINDOW PLUMBING

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var win = sender as Window;
            win.Loaded += Window_Loaded;
            win.Close();
        }

        #endregion

        public abstract void XExecute(PluginContext ctx, DispatcherFrame frame);
    }
}
