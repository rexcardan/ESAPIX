using System;
using System.Threading.Tasks;

namespace ESAPIX.Interfaces
{
    public interface IVMSThread : IDisposable
    {
        int ThreadId { get; }
        Task InvokeAsync(Action action);

        void Invoke(Action action);
    }
}