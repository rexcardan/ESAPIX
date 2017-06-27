#region

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESAPIX.Interfaces;
using System.Diagnostics;

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
                if (SynchronizationContext.Current == null)
                {
                    SynchronizationContext.SetSynchronizationContext(new ConsoleSyncContext());
                }
                ctx = SynchronizationContext.Current;
            }
            else
            {
                //For standalone apps - boot up another thread
                using (mre = new ManualResetEvent(false))
                {
                    thread = new Thread(() =>
                    {
                        try
                        {                         //Hack to initiate a windows message pump (keeps the thread alive) :(
                            Application.Idle += Initialize;
                            Application.Run();
                        }
                        catch (Exception e)
                        {
                            Debug.Write(e.ToString());
                            MessageBox.Show($"VMS Thread crashed : \n{e.ToString()}");
                        }

                    });
                    thread.Name = "ESAPIX Thread";
                    thread.IsBackground = true;
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    mre.WaitOne();
                }
            }
        }


        public async Task InvokeAsync(Action action)
        {
            var task = Task.Run(() =>
            {
                Delegate del = action;
                return Invoke(del);
            });
            await task;
            if (task.Exception != null)
            {
                Debug.Write(task.Exception.ToString());
                throw task.Exception;
            }
        }

        public void Invoke(Action action)
        {
            try
            {
                Delegate del = action;
                Invoke(del);
            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
            }
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