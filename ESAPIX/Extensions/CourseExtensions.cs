using System.Linq;
using VMS.TPS.Common.Model.API;

namespace ESAPIX.Extensions
{
    public static class CourseExtensions
    {
        /// <summary>
        /// Add a new ion plan if it does not exist or returns the current version with that plan ID
        /// </summary>
        /// <param name="c">the course to add the plan</param>
        /// <param name="ss">the structure set</param>
        /// <param name="deviceId">the couch ID</param>
        /// <param name="planId">the plan ID for the new plan</param>
        /// <returns>the new or existing ion plan</returns>
        public static IonPlanSetup AddIonPlanSetupIfNotExists(this Course c, StructureSet ss, string deviceId, string planId)
        {
            var match = c.PlanSetups.FirstOrDefault(p => p.Id == planId);
            if (match != null && match is IonPlanSetup ion)
            {
                return ion;
            }
            else if (match != null)
            {
                throw new System.Exception($"Plan ({planId}) already exists and is not an IonPlanSetup");
            }
            else
            {
                if (!c.CanAddPlanSetup(ss)) { throw new System.Exception($"Cannot add plan to course {c.Id}"); }
                //Good to go
                ion = c.AddIonPlanSetup(ss, deviceId);
                ion.Id = planId;
                return ion;
            }
        }

        /// <summary>
        /// If a plan exists with the input ID, it is deleted, then a new empty plan is created
        /// </summary>
        /// <param name="c">the course to add the plan</param>
        /// <param name="ss">the structure set</param>
        /// <param name="deviceId">the couch ID</param>
        /// <param name="planId">the plan ID for the new plan</param>
        /// <returns>the new ion plan</returns>
        public static IonPlanSetup AddOrResetIonPlan(this Course c, StructureSet ss, string deviceId, string planId)
        {
            var match = c.PlanSetups.FirstOrDefault(p => p.Id == planId);
            if (match != null)
            {
                c.RemovePlanSetup(match);
            }

            if (!c.CanAddPlanSetup(ss)) { throw new System.Exception($"Cannot add plan to course {c.Id}"); }
            //Good to go
            var ion = c.AddIonPlanSetup(ss, deviceId);
            ion.Id = planId;
            return ion;

        }
    }
}
