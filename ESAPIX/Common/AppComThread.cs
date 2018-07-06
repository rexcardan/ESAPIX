#region
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ESAPIX.Interfaces;
using ESAPIX.Facade;
using ESAPIX.AppKit.Exceptions;
using ESAPIX.Extensions;
using System.Windows.Threading;

#endregion

namespace ESAPIX.Common
{
    public class AppComThread : IVMSThread
    {
        private readonly ManualResetEvent mre;

        private readonly Thread thread;
        private SynchronizationContext ctx;
        private Dispatcher _dispatcher;

        public AppComThread(bool useNewThread = true)
        {
            if (!useNewThread)
            {
                thread = Thread.CurrentThread;
                if (thread.GetApartmentState() != ApartmentState.STA)
                    throw new Exception("The current thread must be marked as STA. Cannot connect to ESAPI!");
                if (SynchronizationContext.Current == null)
                    SynchronizationContext.SetSynchronizationContext(new ConsoleSyncContext());
                ctx = SynchronizationContext.Current;
            }
            else
            {
                using (mre = new ManualResetEvent(false))
                {
                    Exception ex = null;
                    thread = new Thread(() =>
                    {
                        _dispatcher = Dispatcher.CurrentDispatcher;
                        _dispatcher.UnhandledException += _dispatcher_UnhandledException;
                        mre.Set();
                        Dispatcher.Run();
                    });
                    thread.Name = "ESAPIX Thread";
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    mre.WaitOne();
                    if (ex != null) { throw ex; }
                }
            }
        }

        private void _dispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            _dispatcher.UnhandledException -= _dispatcher_UnhandledException;
            throw e.Exception;
        }

        public async Task InvokeAsync(Action action)
        {
            await Task.Run(async () => await _dispatcher.InvokeAsync(action));
        }

        public void Invoke(Action action)
        {
            try
            {
                _dispatcher.Invoke(action);
            }
            catch (Exception e)
            {
                var wrapped = new ScriptException(e);
                XContext.Instance.CurrentContext.Logger.Log(wrapped.Message);
                XContext.Instance.CurrentContext.Logger.Log(e.GetRootException().Message);
                throw wrapped;
            }
        }

        public void Dispose()
        {
            _dispatcher.InvokeShutdown();
        }

        public int ThreadId => thread.ManagedThreadId;
    }
}