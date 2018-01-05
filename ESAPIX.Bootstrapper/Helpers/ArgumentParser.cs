using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Bootstrapper.Helpers
{
    public class ArgumentParser
    {
        internal static string GetPatientId(string[] commandLineArgs)
        {
            return GetSingle(commandLineArgs, ArgumentKey.PatientId);
        }

        internal static string GetPlanSetup(string[] commandLineArgs)
        {
            return GetSingle(commandLineArgs, ArgumentKey.PlanSetup);
        }

        internal static string GetBrachyPlanSetup(string[] commandLineArgs)
        {
            return GetSingle(commandLineArgs, ArgumentKey.BrachyPlanSetup);
        }

        internal static string GetExternalPlanSetup(string[] commandLineArgs)
        {
            return GetSingle(commandLineArgs, ArgumentKey.ExternalPlanSetup);
        }

        internal static (string,string) GetImage(string[] commandLineArgs)
        {
            var multiple = GetMultiple(commandLineArgs, ArgumentKey.Image);
            if(multiple!=null && multiple.Count() == 2)
            {
                return (multiple[0], multiple[1]);
            }
            return (string.Empty,string.Empty);
        }

        internal static string GetCourseId(string[] commandLineArgs)
        {
            return GetSingle(commandLineArgs, ArgumentKey.Course);
        }

        internal static List<string> GetPlansInScope(string[] commandLineArgs)
        {
            return GetMultiple(commandLineArgs, ArgumentKey.PlansInScope).ToList();
        }

        internal static List<string> GetPlanSumsInScope(string[] commandLineArgs)
        {
            return GetMultiple(commandLineArgs, ArgumentKey.PlanSumsInScope).ToList();
        }

        internal static List<string> GetExternalPlansInScope(string[] commandLineArgs)
        {
            return GetMultiple(commandLineArgs, ArgumentKey.ExternalPlansInScope).ToList();
        }

        internal static List<string> GetBrachyPlansInScope(string[] commandLineArgs)
        {
            return GetMultiple(commandLineArgs, ArgumentKey.BrachyPlansInScope).ToList();
        }

        private static string GetSingle(string[] commandLineArgs, string key)
        {
            if (commandLineArgs.Contains(key))
            {
                var index = commandLineArgs.ToList().IndexOf(key);
                return commandLineArgs[index + 1];
            }
            return null;
        }

        private static string[] GetMultiple(string[] commandLineArgs, string key)
        {
            if (commandLineArgs.Contains(key))
            {
                var index = commandLineArgs.ToList().IndexOf(key);
                return commandLineArgs.Skip(index).TakeWhile(k => !k.StartsWith("-")).ToArray();
            }
            return null;
        }
    }
}
