
using ESAPIX.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ESAPIX.AppKit
{
    public class AppComThread : IVMSThread
    {
        public AppComThread(bool useNewThread = true)
        {
            if (!useNewThread)
            {
                this.thread = Thread.CurrentThread;
                this.ctx = SynchronizationContext.Current;
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

        public void BeginInvoke(Delegate dlg, params Object[] args)
        {
            if (ctx == null) throw new ObjectDisposedException("VmsComThread");
            ctx.Post((_) => dlg.DynamicInvoke(args), null);
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

        public object Invoke(Delegate dlg, params Object[] args)
        {
            if (ctx == null) throw new ObjectDisposedException("VmsComThread");
            object result = null;
            ctx.Send((_) => result = dlg.DynamicInvoke(null), null);
            return result;
        }
        protected virtual void Initialize(object sender, EventArgs e)
        {
            ctx = SynchronizationContext.Current;
            mre.Set();
            Application.Idle -= Initialize;
        }

        public void Dispose()
        {
            if (ctx != null)
            {
                ctx.Send((_) => Application.ExitThread(), null);
                ctx = null;
            }
        }

        private Thread thread;
        private SynchronizationContext ctx;
        private ManualResetEvent mre;

        public int ThreadId
        {
            get
            {
                return thread.ManagedThreadId;
            }
        }
    }
}