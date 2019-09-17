using ESAPIX.Common;
using ESAPIX.Interfaces;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ESAPIX.Services
{
    public class ESAPIService : IESAPIService
    {
        private AppComThread _thread;

        public ESAPIService(Func<VMS.TPS.Common.Model.API.Application> createAppFunc)
        {
            _thread = AppComThread.Instance;
            _thread.SetContext(createAppFunc);
        }

        public void Invoke(Action a)
        {
            _thread.Invoke(a);
        }

        public Task InvokeAsync(Action a)
        {
            return _thread.InvokeAsync(a);
        }

        public void Execute(Action<StandAloneContext> sacFunc)
        {
            _thread.Execute(sacFunc);
        }

        public Task ExecuteAsync(Action<StandAloneContext> sacFunc)
        {
            return _thread.ExecuteAsync(sacFunc);
        }

        public Task<T> GetValueAsync<T>(Func<StandAloneContext, T> func)
        {
            return _thread.GetValueAsync(func);
        }

        public Task<T> GetValueExpAsync<T>(Expression<Func<StandAloneContext, T>> func)
        {
            return _thread.GetValueAsync(func.Compile());
        }

        public T GetValue<T>(Func<StandAloneContext, T> func)
        {
            return _thread.GetValue(func);
        }

        public T GetValueExp<T>(Expression<Func<StandAloneContext, T>> func)
        {
            return _thread.GetValue(func.Compile());
        }
    }
}
