using ESAPIX.AppKit;
using ESAPIX.Facade.API;
using ESAPIX.Facade.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Facade
{
    public class StaticHelper
    {
        //MUST SET BEFORE CALLING
        public static Func<string, string, dynamic> CreateApplicationFunc { get; set; } = new Func<string, string, dynamic>((u, p) => { return null; });
        public static Application Application_CreateApplication(string username, string password)
        {
            var thread = new AppComThread();
            Application xapp = null;
            thread.Invoke(() =>
            {
                var vms = CreateApplicationFunc(username, password);
                xapp = new Application(vms);
            });
            var sac = new StandAloneContext(xapp, thread);
            XContext.Instance.CurrentContext = sac;
            return xapp;
        }

        internal static void SerializableObject_ClearSerializationHistory()
        {
            throw new NotImplementedException();
        }

        //MUST SET BEFORE CALLING
        public static Func<dynamic> DoseValue_UndefinedDoseFunc { get; set; } = new Func<dynamic>(() => { return null; });
        public static DoseValue DoseValue_UndefinedDose()
        {
            return new DoseValue(DoseValue_UndefinedDoseFunc());
        }

        internal static double VVector_Distance(dynamic client1, dynamic client2)
        {
            throw new NotImplementedException();
        }
    }
}
