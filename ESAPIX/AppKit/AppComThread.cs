#region

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESAPIX.Interfaces;

#endregion

namespace ESAPIX.AppKit
{
    public class AppComThread : IVMSThread
    {
        private readonly ManualResetEvent mre;

        private readonly Thread thread;
        private SynchronizationContext ctx;

        public AppComThread(bool useNewThread = true)
        {
            if (!useNewThread)
            {
                thread = Thread.CurrentThread;
                ctx = SynchronizationContext.Current;
            }
            else
            {
                //For standalone apps - boot up another thread
                using (mre = new ManualResetEvent(false))
                {
                    thread = new Thread(() =>
                    {
                        //Hack to initiate a windows message pump (keeps the thread alive) :(
                        Application.Idle += Initialize;
                        Application.Run();
                    });
                    thread.IsBackground = true;
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    mre.WaitOne();
                }
            }
        }

        public async Task InvokeAsync(Action action)
        {
            await Task.Run(() =>
            {
                Delegate del = action;
                return Invoke(del);
            });
        }

        public void Invoke(Action action)
        {
            Delegate del = action;
            Invoke(del);
        }

        public void Dispose()
        {
            if (ctx != null)
            {
                ctx.Send(_ => Application.ExitThread(), null);
                ctx = null;
            }
        }

        public int ThreadId => thread.ManagedThreadId;

        public void BeginInvoke(Delegate dlg, params object[] args)
        {
            if (ctx == null) throw new ObjectDisposedException("VmsComThread");
            ctx.Post(_ => dlg.DynamicInvoke(args), null);
        }

        public object Invoke(Delegate dlg, params object[] args)
        {
            if (ctx == null) throw new ObjectDisposedException("VmsComThread");
            object result = null;
            ctx.Send(_ => result = dlg.DynamicInvoke(null), null);
            return result;
        }

        protected virtual void Initialize(object sender, EventArgs e)
        {
            ctx = SynchronizationContext.Current;
            mre.Set();
            Application.Idle -= Initialize;
        }
    }
}