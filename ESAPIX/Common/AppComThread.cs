#region
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ESAPIX.Interfaces;
using ESAPIX.AppKit.Exceptions;
using ESAPIX.Extensions;
using System.Windows.Threading;
using System.Windows.Forms;
using VMS.TPS.Common.Model.API;

#endregion

namespace ESAPIX.Common
{
    public class AppComThread
    {
        private static AppComThread instance = null;
        private static readonly object padlock = new object();
        private Thread thread;
        private SynchronizationContext ctx;
        private TaskScheduler _scheduler;
        private ManualResetEvent mre;
        private StandAloneContext _sac;

        private AppComThread()
        {
            using (mre = new ManualResetEvent(false))
            {
                thread = new Thread(() =>
                {
                    System.Windows.Forms.Application.Idle += Initialize;
                    System.Windows.Forms.Application.Run();
                });
                thread.IsBackground = true;
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                mre.WaitOne();
            }
        }

        public static AppComThread Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new AppComThread();
                    }
                    return instance;
                }
            }
        }

        public void SetContext(Func<VMS.TPS.Common.Model.API.Application> createAppFunc)
        {
            Invoke(new Action(() =>
            {
                var app = createAppFunc();
                _sac = new StandAloneContext(app);
                _sac.Thread = this;
            }));
        }

        public T GetValue<T>(Func<StandAloneContext, T> sacFunc)
        {
            T toReturn = default(T);
            Invoke(() =>
            {
                toReturn = sacFunc(_sac);
            });
            return toReturn;
        }

        public async Task<T> GetValueAsync<T>(Func<StandAloneContext, T> sacFunc)
        {
            T toReturn = default(T);
            await InvokeAsync(() =>
            {
                toReturn = sacFunc(_sac);
            });
            return toReturn;
        }

        public void Execute(Action<StandAloneContext> sacOp)
        {
            Invoke(() =>
            {
                sacOp(_sac);
            });
        }

        public Task ExecuteAsync(Action<StandAloneContext> sacOp)
        {
            return InvokeAsync(() =>
            {
                sacOp(_sac);
            });
        }

        public async Task InvokeAsync(Action action)
        {
            var task = Task.Run(() =>
            {
                Invoke(action);
            });
            await task;
            if (task.Exception != null)
            {
                var wrapped = new ScriptException(task.Exception);
                throw wrapped;
            }
        }

        public void Invoke(Action action)
        {
            var timeout = 5000;
            var cts = new CancellationTokenSource();
            try
            {
                cts.CancelAfter(timeout);
                var task = Task.Factory.StartNew(() =>
                {
                    Delegate del = action;
                    Invoke(del);
                },
                  cts.Token,
                  TaskCreationOptions.None,
                  _scheduler);
                //Wait
                task.GetAwaiter().GetResult();
                if (task.Exception != null)
                {
                    throw task.Exception;
                }
            }
            catch (OperationCanceledException)
            {
                //handle cancellation
                throw new Exception("ESAPIX Timeout!");
            }
            catch (Exception e)
            {
                var wrapped = new ScriptException(e);
                throw wrapped;
            }
        }

        //private void BeginInvoke(Delegate dlg, params Object[] args)
        //{
        //    if (ctx == null) throw new ObjectDisposedException("ESAPIX_Thread");
        //    ctx.Post((_) => dlg.DynamicInvoke(args), null);
        //}

        private object Invoke(Delegate dlg, params Object[] args)
        {
            if (ctx == null) throw new ObjectDisposedException("ESAPIX_Thread");
            object result = null;
            ctx.Send((_) => result = dlg.DynamicInvoke(args), null);
            return result;
        }

        protected virtual void Initialize(object sender, EventArgs e)
        {
            ctx = SynchronizationContext.Current;
            _scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            mre.Set();
            System.Windows.Forms.Application.Idle -= Initialize;
        }
        public void Dispose()
        {
            Invoke(new Action(() =>
            {
                if (_sac != null)
                {
                    _sac.Application.Dispose();
                    _sac = null;
                }
            }));
            if (ctx != null)
            {
                ctx.Send((_) => System.Windows.Forms.Application.ExitThread(), null);
                ctx = null;
            }
        }

        public int ThreadId => thread.ManagedThreadId;
    }
}