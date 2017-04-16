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
        //MUST SET BEFORE CALLING
        public static Action SerializableObject_ClearSerializationHistoryAction { get; set; } = new Action(() => { });
        public static void SerializableObject_ClearSerializationHistory()
        {
            XContext.Instance.CurrentContext.Thread.Invoke(() =>
            {
                SerializableObject_ClearSerializationHistoryAction();
            });
        }

        //MUST SET BEFORE CALLING
        public static Func<dynamic> DoseValue_UndefinedDoseFunc { get; set; } = new Func<dynamic>(() => { return null; });
        public static DoseValue DoseValue_UndefinedDose()
        {
            return XContext.Instance.CurrentContext.GetValue<dynamic>((sc) =>
            {
                return DoseValue_UndefinedDoseFunc();
            });
        }
        //MUST SET BEFORE CALLING
        public static Func<dynamic, dynamic, double> VVector_DistanceFunc { get; set; } = new Func<dynamic, dynamic, double>((v1, v2) => { return double.NaN; });
        public static double VVector_Distance(dynamic client1, dynamic client2)
        {
            return XContext.Instance.CurrentContext.GetValue<double>((sc) =>
            {
                return VVector_DistanceFunc(client1, client2);
            });
        }
    }
}
