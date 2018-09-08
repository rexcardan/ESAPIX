#region

using System.Windows;
using System.Windows.Threading;
using ESAPIX.Facade;
using VMS.TPS.Common.Model.API;
using ESAPIX.Common;

#endregion

namespace ESAPIX.Bootstrapper
{
    public abstract class XScriptBase
    {
        public void Execute(ScriptContext context, Window window)
        {
            var scriptContext = new Facade.API.ScriptContext(context);
            //Get this window barely visible so that when it does show, it isn't ugly ;)
            window.Height = window.Width = 0;
            window.WindowStyle = WindowStyle.None;
            window.Hide();
            window.Loaded += Window_Loaded;

            var plugCtx = new PluginContext(scriptContext, window);
            var frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.UnhandledException += CurrentDispatcher_UnhandledException;
            XContext.Instance.CurrentContext = plugCtx;
            XExecute(plugCtx, frame);
            Dispatcher.PushFrame(frame);
            Dispatcher.CurrentDispatcher.UnhandledException -= CurrentDispatcher_UnhandledException;
        }

        private void CurrentDispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"SCRIPT ERROR : \n\n" + e.Exception.Message);
            e.Handled = true;
        }

        #region WINDOW PLUMBING

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var win = sender as Window;
            win.Loaded -= Window_Loaded;
            win.Close();
        }
        #endregion

        public abstract void XExecute(PluginContext ctx, DispatcherFrame frame);
    }
}