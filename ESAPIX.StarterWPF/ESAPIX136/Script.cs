using ESAPIX.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.AppKit;
using System.Windows.Threading;
using $safeprojectname$.Views;

namespace $safeprojectname$
{
    public class Script : XScriptBase
    {
        public override void XExecute(PluginContext ctx, DispatcherFrame frame)
        {
            var bs = new ScriptBootstrapper<MainView>(ctx, frame);
            bs.Run();
        }
    }
}
