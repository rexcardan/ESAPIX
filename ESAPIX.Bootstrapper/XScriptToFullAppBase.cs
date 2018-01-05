using ESAPIX.AppKit;
using ESAPIX.Bootstrapper.Helpers;
using ESAPIX.Facade;
using ESAPIX.Facade.API;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ESAPIX.Bootstrapper
{
    public class XScriptToFullAppBase
    {
        public virtual string AppStartPath { get; set; }

        public void Execute(ScriptContext context, Window window)
        {
            var scriptContext = new Facade.API.ScriptContext(context);
            //When hooked up to bootstrapper (comment out otherwise)
            FacadeInitializer.Initialize();
            //Get this window barely visible so that when it does show, it isn't ugly ;)
            window.Height = window.Width = 0;
            window.WindowStyle = WindowStyle.None;
            window.Hide();
            window.Loaded += Window_Loaded;

            var plugCtx = new PluginContext(scriptContext, window);
            XContext.Instance.CurrentContext = plugCtx;
            var args = ArgumentBuilder.Build(plugCtx);
            Process.Start(AppStartPath, args);
        }

        #region WINDOW PLUMBING

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var win = sender as Window;
            win.Loaded += Window_Loaded;
            win.Close();
        }

        #endregion
    }
}
