using ESAPIX.Common;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ESAPIX.Interfaces
{
    public interface IESAPIService
    {
        void Invoke(Action a);

        Task InvokeAsync(Action a);

        void Execute(Action<StandAloneContext> sacFunc);

        Task ExecuteAsync(Action<StandAloneContext> sacFunc);

        Task<T> GetValueExpAsync<T>(Expression<Func<StandAloneContext, T>> func);

        T GetValueExp<T>(Expression<Func<StandAloneContext, T>> func);

        Task<T> GetValueAsync<T>(Func<StandAloneContext, T> func);

        T GetValue<T>(Func<StandAloneContext, T> func);
    }
}
