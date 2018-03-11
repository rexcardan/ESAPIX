#region

using System.Threading;

#endregion

namespace ESAPIX.Common
{
    public class ConsoleSyncContext : SynchronizationContext
    {
        public override void Post(SendOrPostCallback action, object state)
        {
            SendOrPostCallback actionWrap = state2 =>
            {
                SetSynchronizationContext(new ConsoleSyncContext());
                action.Invoke(state2);
            };
            var callback = new WaitCallback(actionWrap.Invoke);
            ThreadPool.QueueUserWorkItem(callback, state);
        }

        public override SynchronizationContext CreateCopy()
        {
            return new ConsoleSyncContext();
        }

        public override void Send(SendOrPostCallback d, object state)
        {
            base.Send(d, state);
        }

        public override void OperationStarted()
        {
            base.OperationStarted();
        }

        public override void OperationCompleted()
        {
            base.OperationCompleted();
        }
    }
}