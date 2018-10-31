#if VMS155
using ESAPIX.Logging;
using System;
using System.Linq;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
//[assembly: ESAPIScript(IsWriteable = true)]

namespace ESAPIX.Helpers.Copiers
{
    public class PlanCopier
    {
        /// <summary>
        /// Copies a already created verification plan to: 
        /// 1. The same structure set if one is not inpput
        /// 2. A new phantom structure set if one is input
        /// </summary>
        /// <param name="planToCopy"></param>
        /// <param name="course"></param>
        /// <param name="phantomStructureSetId"></param>
        /// <param name="phantomPatientId"></param>
        /// <param name="phantomStudyId"></param>
        /// <returns></returns>
        public static ExternalPlanSetup CopyVerificationPlan(ExternalPlanSetup planToCopy, Course course, string phantomStructureSetId, string phantomPatientId, string phantomStudyId)
        {
            if (course.PlanSetups.Any(p => p.Id == planToCopy.Id))
            {
                GlobalLogger.Instance.Trace($"A plan with ID {planToCopy.Id} already exists in course {course.Id}.");
                throw new Exception("A plan with the same ID as the source plan already exists in the destination course.");
            }

            if (String.IsNullOrWhiteSpace(phantomStructureSetId))
            {
                return (ExternalPlanSetup)course.CopyPlanSetup(planToCopy);
            }
            else
            {
                StructureSet structureSet;
                if (String.IsNullOrWhiteSpace(phantomPatientId))
                    structureSet = planToCopy.Course.Patient.StructureSets.Where(s => s.Id == phantomStructureSetId).Single();
                else
                {

                    structureSet = planToCopy.Course.Patient.CopyImageFromOtherPatient(phantomPatientId, phantomStudyId, phantomStructureSetId);
                    GlobalLogger.Instance.Trace($"New phantom structure set {structureSet.Id} created from structure set {phantomStructureSetId} in patient ID {phantomPatientId}");
                }

                ExternalPlanSetup verifiedPlan = (ExternalPlanSetup)planToCopy.VerifiedPlan;
                ExternalPlanSetup copyPlan = course.AddExternalPlanSetupAsVerificationPlan(structureSet, verifiedPlan);
                copyPlan.Id = planToCopy.Id;
                copyPlan.SetPrescription((int)planToCopy.NumberOfFractions, planToCopy.DosePerFraction, planToCopy.TreatmentPercentage);
                GlobalLogger.Instance.Trace($"Added verification plan created from {verifiedPlan.Id} (Course {verifiedPlan.Course.Id}) using phantom structure set {structureSet.Id}");

                foreach (Beam b in planToCopy.Beams)
                {
                    VVector iso = b.IsocenterPosition - planToCopy.StructureSet.Image.UserOrigin;
                    iso += structureSet.Image.UserOrigin;
                    BeamCopier.CopyBeamToPlan(b, copyPlan, iso);// setup beam isocenters to user origin of the QA device
                    GlobalLogger.Instance.Trace($"Copied {b.Id} to verification plan");
                }
                return copyPlan;
            }
        }
    }
}
#endif