using ESAPIX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VMS.TPS.Common.Model.API;

namespace ESAPIX.AppKit
{
    public abstract class XScriptMultithreadBase
    {
        public void Execute(ScriptContext context, Window window)
        {
            window.Height = window.Width = 0;
            var plugCtx = new PluginContext(context, window);
            XExecute(plugCtx);
            window.Close();
        }

        public abstract void XExecute(IScriptContext ctx);
    }
}
