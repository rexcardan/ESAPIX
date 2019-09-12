using ESAPIX.Common;
using ESAPIX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.API;

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

        public Task<T> GetValueAsync<T>(Func<StandAloneContext,T> func)
        {
            return _thread.GetValueAsync(func);
        }

        public T GetValue<T>(Func<StandAloneContext, T> func)
        {
            return _thread.GetValue(func);
        }
    }
}
