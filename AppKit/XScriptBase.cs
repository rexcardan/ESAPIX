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
    public abstract class XScriptBase
    {
        public void Execute(ScriptContext context, Window window)
        {
            var plugCtx = new PluginContext(context, window);
            XExecute(plugCtx, window);
        }

        public abstract void XExecute(IScriptContext ctx, Window w);
    }
}
