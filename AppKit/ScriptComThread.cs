using ESAPIX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ESAPIX.AppKit
{
    public class ScriptComThread : IVMSThread
    {
        Dispatcher _disp;

        public ScriptComThread(Dispatcher disp)
        {
            _disp = disp;
        }

        public void Dispose()
        {
            _disp.BeginInvokeShutdown(DispatcherPriority.Background);
        }

        public void Invoke(Action action)
        {
            _disp.Invoke(action);
        }

        public async Task InvokeAsync(Action action)
        {
            await _disp.InvokeAsync(action);
        }
    }
}
