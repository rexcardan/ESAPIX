#region
using System;
using ESAPIX.Facade.API;
using VMS.TPS.Common.Model.Types;
using ESAPIX.Common;

#endregion

namespace ESAPIX.Facade
{
    public class StaticHelper
    {
        //MUST SET BEFORE CALLING
        public static Func<string, string, dynamic> Application_CreateApplicationFunc0 { get; set; } =
            (u, p) => { return null; };
        //V15 +
        public static Func<dynamic> Application_CreateApplicationFunc1 { get; set; } = () => { return null; };

        //MUST SET BEFORE CALLING
        public static Action SerializableObject_ClearSerializationHistoryAction0 { get; set; } = () => { };

        //MUST SET BEFORE CALLING
        public static Func<dynamic> DoseValue_UndefinedDoseFunc { get; set; } = () => { return null; };

        //MUST SET BEFORE CALLING
        public static Func<dynamic, dynamic, double> VVector_DistanceFunc { get; set; } =
            (v1, v2) => { return double.NaN; };

        public static Application Application_CreateApplication(string username, string password)
        {
            throw new Exception("This method should not be called. Call StandAloneContext contructor instead.");
        }

        public static Application Application_CreateApplication(
           bool useCurrentThread = false)
        {
            throw new Exception("This method should not be called. Call StandAloneContext contructor instead.");
        }

        public static void SerializableObject_ClearSerializationHistory()
        {
            AppComThread.Instance.Execute((sac) =>
            {
                SerializableObject_ClearSerializationHistoryAction0();
            });
        }

        public static DoseValue DoseValue_UndefinedDose()
        {
            return AppComThread.Instance.GetValue(sc => { return DoseValue_UndefinedDoseFunc(); });
        }

        public static double VVector_Distance(dynamic client1, dynamic client2)
        {
            return AppComThread.Instance.GetValue(sc =>
            {
                return VVector_DistanceFunc(client1, client2);
            });
        }
    }
}