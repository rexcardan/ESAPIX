using System;
using System.Collections.Generic;
using System.Text;

namespace ESAPIX.AppLauncher
{
    /// <summary>
    /// The prefix key to the cmd line arguments for ESAPIX to parse
    /// </summary>
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
    }
}
