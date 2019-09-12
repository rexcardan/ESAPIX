using System.Linq;

namespace ESAPIX.Common.Args
{
    public class ArgumentKey
    {
        public const string CurrentUserId = "-u";
        public const string Course = "-c";
        public const string Image = "-i";
        public const string StructureSet = "-ss";
        public const string ApplicationName = "-a";
        public const string PatientId = "-id";
        public const string PlanSetup = "-p";
        public const string BrachyPlanSetup = "-bp";
        public const string BrachyPlansInScope = "-bpsc";
        public const string ExternalPlanSetup = "-ep";
        public const string ExternalPlansInScope = "-epsc";
        public const string PlansInScope = "-psc";
        public const string PlanSumsInScope = "-pssc";
        public const string IonPlansInScope = "-ipsc";
        public const string IonPlanSetup = "-ip";

        public static string[] Keys = new string[]
        {
            CurrentUserId,
            Course,
            Image,
            StructureSet,
            ApplicationName,
            PatientId,
            PlanSetup,
            BrachyPlanSetup,
            BrachyPlansInScope,
            ExternalPlanSetup,
            ExternalPlansInScope,
            PlansInScope,
            PlanSumsInScope,
            IonPlanSetup,
            IonPlansInScope
        };

        public static bool IsKey(string arg)
        {
            return Keys.Any(k => k == arg);
        }
    }
}
