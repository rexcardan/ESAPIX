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
        public static Func<string, string, dynamic> Application_CreateApplicationFunc0 { get; set; } = (u, p) => { return null; };

        //MUST SET BEFORE CALLING
        public static Action SerializableObject_ClearSerializationHistoryAction0 { get; set; } = () => { };

        //MUST SET BEFORE CALLING
        public static Func<dynamic> DoseValue_UndefinedDoseFunc { get; set; } = () => { return null; };

        //MUST SET BEFORE CALLING
        public static Func<dynamic, dynamic, double> VVector_DistanceFunc { get; set; } =
            (v1, v2) => { return double.NaN; };

        public static Application Application_CreateApplication(string username, string password,

            bool useCurrentThread = false)

        {

            var thread = new AppComThread(!useCurrentThread);

            Application xapp = null;

            Exception e = null;

            thread.Invoke(() =>

            {

                try

                {

                    var vms = Application_CreateApplicationFunc0(username, password);

                    xapp = new Application(vms);

                }

                catch (Exception ex)

                {

                    e = ex;

                }

            });

            if (xapp == null)

                throw new Exception("App was not created. Check to make sure the VMS dll references are correct.", e);

            var sac = new StandAloneContext(xapp, thread);

            XContext.Instance.CurrentContext = sac;

            XContext.Instance.CurrentContext.UIDispatcher = System.Windows.Application.Current?.Dispatcher;

            return xapp;

        }

        public static void SerializableObject_ClearSerializationHistory()
        {
            XContext.Instance.CurrentContext.Thread.Invoke(() =>
            {
                SerializableObject_ClearSerializationHistoryAction0();
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