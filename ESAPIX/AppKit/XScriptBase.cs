#region

using System.Windows;
using ESAPIX.Facade.API;

#endregion

namespace ESAPIX.AppKit
{
    public abstract class XScriptBase
    {
        public void Execute(ScriptContext context, Window window)
        {
            var plugCtx = new PluginContext(context, window);
            XExecute(plugCtx, window);
        }

        public abstract void XExecute(PluginContext ctx, Window w);
    }
}