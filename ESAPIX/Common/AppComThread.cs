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
            BeginInvoke(new Action(() => { _sac = new StandAloneContext(createAppFunc()); }));
        }

        public void Execute(Action<StandAloneContext> sacAction)
        {
            BeginInvoke(new Action(() => { sacAction(_sac); }));
        }

        private void BeginInvoke(Delegate dlg, params Object[] args)
        {
            if (ctx == null) throw new ObjectDisposedException("ESAPIX_Thread");
            ctx.Post((_) => dlg.DynamicInvoke(args), null);
        }

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
            mre.Set();
            System.Windows.Forms.Application.Idle -= Initialize;
        }
        public void Dispose()
        {
            if (ctx != null)
            {
                ctx.Send((_) => System.Windows.Forms.Application.ExitThread(), null);
                ctx = null;
            }
        }

        public int ThreadId => thread.ManagedThreadId;
    }
}