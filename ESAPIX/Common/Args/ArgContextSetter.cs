using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Common.Args
{
    public class ArgContextSetter
    {
        /// <summary>
        /// Sets up a stand alone context to emulate a plugin by injection command line arguments
        /// </summary>
        /// <param name="sac">the current standalone context</param>
        /// <param name="commandLineArgs">the command line args for the plugin</param>
        public static void Set(StandAloneContext sac, string[] commandLineArgs)
        {
            {
                string patientId = ArgumentParser.GetPatientId(commandLineArgs);
                if (!string.IsNullOrEmpty(patientId))
                {
                    sac.SetPatient(patientId);
                }
            }

            {
                string courseId = ArgumentParser.GetCourseId(commandLineArgs);
                if (!string.IsNullOrEmpty(courseId))
                {
                    var course = sac.Patient.Courses.FirstOrDefault(c => c.Id == courseId);
                    sac.SetCourse(course, false);

                    {
                        //Only do this if course is set
                        var planUid = ArgumentParser.GetPlanSetup(commandLineArgs);
                        if (!string.IsNullOrEmpty(planUid))
                        {
                            var plan = sac.Course.PlanSetups.FirstOrDefault(p => p.UID == planUid);
                            sac.SetPlanSetup(plan);
                        }
                    }

                    {
                        var plansInScope = ArgumentParser.GetPlansInScope(commandLineArgs);
                        if (plansInScope != null && plansInScope.Any())
                        {
                            var plans = sac.Patient.Courses.SelectMany(c=>c.PlanSetups).Where(p => plansInScope.Contains(p.UID));
                            sac.SetPlansInScope(plans);
                        }
                    }

#if !VMS110
                    {
                        var externalPlanUid = ArgumentParser.GetExternalPlanSetup(commandLineArgs);
                        if (!string.IsNullOrEmpty(externalPlanUid))
                        {
                            var plan = sac.Course.ExternalPlanSetups.FirstOrDefault(p => p.UID == externalPlanUid);
                            sac.SetExternalPlanSetup(plan);
                        }
                    }
                    {
                        var brachyPlanUid = ArgumentParser.GetBrachyPlanSetup(commandLineArgs);
                        if (!string.IsNullOrEmpty(brachyPlanUid))
                        {
                            var plan = sac.Course.BrachyPlanSetups.FirstOrDefault(p => p.UID == brachyPlanUid);
                            sac.SetBrachyPlanSetup(plan);
                        }
                    }
                    {
                        var explansInScope = ArgumentParser.GetExternalPlansInScope(commandLineArgs);
                        if (explansInScope != null && explansInScope.Any())
                        {
                            var plans = sac.Patient.Courses.SelectMany(c => c.ExternalPlanSetups).Where(p => explansInScope.Contains(p.UID));
                            sac.SetExternalPlansInScope(plans);
                        }
                    }
                    {
                        var brachyInScope = ArgumentParser.GetBrachyPlansInScope(commandLineArgs);
                        if (brachyInScope != null && brachyInScope.Any())
                        {
                            var plans = sac.Patient.Courses.SelectMany(c => c.BrachyPlanSetups).Where(p => brachyInScope.Contains(p.UID));
                            sac.SetBrachyPlansInScope(plans);
                        }
                    }
#endif
#if (VMS151 || VMS150 || VMS155)
                    {
                        var ionPlansInScope = ArgumentParser.GetIonPlansInScope(commandLineArgs);
                        if (ionPlansInScope != null && ionPlansInScope.Any())
                        {
                            var plans = sac.Patient.Courses.SelectMany(c => c.IonPlanSetups).Where(p => ionPlansInScope.Contains(p.UID));
                            sac.SetIonPlansInScope(plans);
                        }
                    }

                    {
                        var planUid = ArgumentParser.GetIonPlanSetup(commandLineArgs);
                        if (!string.IsNullOrEmpty(planUid))
                        {
                            var plan = sac.Course.IonPlanSetups.FirstOrDefault(p => p.UID == planUid);
                            sac.SetIonPlanSetup(plan);
                        }
                    }
#endif
                }
            }
        }
    }
}
