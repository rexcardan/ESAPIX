#region

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESAPIX.Interfaces;
using ESAPIX.Facade;
using System.Windows.Threading;
using ESAPIX.AppKit.Exceptions;

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
                if (thread.GetApartmentState() != ApartmentState.STA)
                    throw new Exception("The current thread must be marked as STA. Cannot connect to ESAPI!");
                if (SynchronizationContext.Current == null)
                    SynchronizationContext.SetSynchronizationContext(new ConsoleSyncContext());
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
                        {
                            //Hack to initiate a windows message pump (keeps the thread alive) :(
                            Application.Idle += Initialize;
                            Application.Run();
                            Debug.WriteLine("ESAPIX Thread closing...");
                        }
                        catch (Exception e)
                        {
                            Debug.Write(e.ToString());
                            MessageBox.Show($"VMS Thread crashed : \n{e}");
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
                var wrapped = new ScriptException(task.Exception);
                XContext.Instance.CurrentContext.Logger.Log(wrapped.Message);
                XContext.Instance.CurrentContext.Logger.Log(task.Exception.GetRootException().Message);
                XContext.Instance.CurrentContext.UIDispatcher.Invoke(() =>
                {
                    throw wrapped;
                });
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
                var wrapped = new ScriptException(e);
                XContext.Instance.CurrentContext.Logger.Log(wrapped.Message);
                XContext.Instance.CurrentContext.Logger.Log(e.GetRootException().Message);
                XContext.Instance.CurrentContext.UIDispatcher.Invoke(() =>
                {
                    throw wrapped;
                });
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
            object result = null;
            if (ctx == null) throw new ObjectDisposedException("VmsComThread");
            ctx.Send(_ => result = dlg.DynamicInvoke(args), null);
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