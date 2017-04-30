using System;
using System.Threading.Tasks;
using System.Windows.Threading;
using ESAPIX.Interfaces;

namespace ESAPIX.AppKit
{
    public class ScriptComThread : IVMSThread
    {
        private readonly Dispatcher _disp;

        public ScriptComThread(Dispatcher disp)
        {
            _disp = disp;
        }

        public int ThreadId => _disp.Thread.ManagedThreadId;

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