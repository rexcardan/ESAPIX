using ESAPIX.Common;
using System;
using System.Threading.Tasks;

namespace ESAPIX.Interfaces
{
    public interface IESAPIService
    {
        void Invoke(Action a);

        Task InvokeAsync(Action a);

        Task<T> GetValueAsync<T>(Func<StandAloneContext, T> func);

        T GetValue<T>(Func<StandAloneContext, T> func);
    }
}
