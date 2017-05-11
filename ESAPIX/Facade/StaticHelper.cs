#region

using System;
using ESAPIX.AppKit;
using ESAPIX.Facade.API;
using VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIX.Facade
{
    public class StaticHelper
    {
        //MUST SET BEFORE CALLING
        public static Func<string, string, dynamic> CreateApplicationFunc { get; set; } = (u, p) => { return null; };

        //MUST SET BEFORE CALLING
        public static Action SerializableObject_ClearSerializationHistoryAction { get; set; } = () => { };

        //MUST SET BEFORE CALLING
        public static Func<dynamic> DoseValue_UndefinedDoseFunc { get; set; } = () => { return null; };

        //MUST SET BEFORE CALLING
        public static Func<dynamic, dynamic, double> VVector_DistanceFunc { get; set; } =
            (v1, v2) => { return double.NaN; };

        public static Application Application_CreateApplication(string username, string password, bool useCurrentThread = false)
        {
            var thread = new AppComThread(!useCurrentThread);
            Application xapp = null;
            thread.Invoke(() =>
            {
                var vms = CreateApplicationFunc(username, password);
                xapp = new Application(vms);
            });
            var sac = new StandAloneContext(xapp, thread);
            XContext.Instance.CurrentContext = sac;
            XContext.Instance.CurrentContext.UIDispatcher = System.Windows.Application.Current?.Dispatcher;
            return xapp;
        }

        public static void SerializableObject_ClearSerializationHistory()
        {
            XContext.Instance.CurrentContext.Thread.Invoke(() =>
            {
                SerializableObject_ClearSerializationHistoryAction();
            });
        }

        public static DoseValue DoseValue_UndefinedDose()
        {
            return XContext.Instance.CurrentContext.GetValue(sc => { return DoseValue_UndefinedDoseFunc(); });
        }

        public static double VVector_Distance(dynamic client1, dynamic client2)
        {
            return XContext.Instance.CurrentContext.GetValue<double>(sc =>
            {
                return VVector_DistanceFunc(client1, client2);
            });
        }
    }
}