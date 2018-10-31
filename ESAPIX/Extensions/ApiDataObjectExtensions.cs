using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.API;

namespace ESAPIX.Extensions
{
    public static class ApiDataObjectExtensions
    {
        public static T ToFacade<T>(this ApiDataObject vms) where T : ESAPIX.Facade.API.ApiDataObject
        {
            return (T)Activator.CreateInstance(typeof(T), vms);
        }

        public static T ToConcrete<T>(this ESAPIX.Facade.API.ApiDataObject facade) where T : ApiDataObject
        {
            var fieldInfo = facade.GetType()
                .GetField("_client",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
           
            return (T)fieldInfo?.GetValue(facade);
        }
    }
}
