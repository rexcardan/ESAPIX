using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Interfaces
{
    public interface IVMSThread : IDisposable
    {
        Task InvokeAsync(Action action);

        void Invoke(Action action);
    }
}
