using ESAPIX.Common;
using System.Linq;
using VMS.TPS.Common.Model.API;

namespace ESAPIX.Extensions
{
    public static class ConsoleUIExtensions
    {
        public static StructureSet GetStructureSet(this ConsoleUI ui, StandAloneContext context)
        {
            var patientExists = context.Patient != null;
            if (!patientExists) { ui.WriteError("There is no patient in the context"); return null; }

            var strSetIds = context.Patient.StructureSets.Select(s => s.Id).ToList();
            ui.WritePrompt("The following are a list of available structure sets:");
            var selectedIndex = ui.GetResponse(strSetIds.ToArray());
            var strSet = strSetIds[selectedIndex];
            context.StructureSet = context.Patient.StructureSets.FirstOrDefault(s => s.Id == strSet);
            return context.StructureSet;
        }

        public static Structure GetStructure(this ConsoleUI ui, StandAloneContext context)
        {
            var patientExists = context.Patient != null;
            if (!patientExists) { ui.WriteError("There is no patient in the context"); return null; }

            var structureSetExists = context.StructureSet != null;
            if (!structureSetExists) { ui.WriteError("There is no structure set in the context"); return null; }
            ui.WritePrompt("The following are a list of available structures:");

            var structureIds = context.StructureSet.Structures.Select(s => s.Id).ToList();
            var selectedIndex = ui.GetResponse(structureIds.ToArray());
            return context.StructureSet.Structures.ToList()[selectedIndex];
        }

        public static Beam GetField(this ConsoleUI ui, StandAloneContext context)
        {
            var patientExists = context.Patient != null;
            if (!patientExists) { ui.WriteError("There is no patient in the context"); return null; }

            var planSetupExists = context.PlanSetup != null;
            if (!planSetupExists) { ui.WriteError("There is no plan setup in the context"); return null; }
            ui.WritePrompt("The following are a list of available fields:");

            var beamIds = context.PlanSetup.Beams.Select(s => s.Id).ToList();
            var selectedIndex = ui.GetResponse(beamIds.ToArray());
            return context.PlanSetup.Beams.ToList()[selectedIndex];
        }

        public static Course GetCourse(this ConsoleUI ui, StandAloneContext context)
        {
            var patientExists = context.Patient != null;
            if (!patientExists) { ui.WriteError("There is no patient in the context"); return null; }

            var courseIds = context.Patient.Courses.Select(s => s.Id).ToList();
            if (courseIds.Any())
            {
                ui.WritePrompt("The following are a list of available courses:");
                var selectedIndex = ui.GetResponse(courseIds.ToArray());
                var courseId = courseIds[selectedIndex];
                context.Course = context.Patient.Courses.FirstOrDefault(s => s.Id == courseId);

            }
            else
            {
                var courseId = ui.GetStringInput("There are no courses. What course ID to create?");
                context.Course = context.Patient.AddCourseIfNotExists(courseId);
            }
            return context.Course;
        }

        public static PlanSetup GetPlan(this ConsoleUI ui, StandAloneContext context)
        {
            var patientExists = context.Patient != null;
            if (!patientExists) { ui.WriteError("There is no patient in the context"); return null; }

            var courseExists = context.Course != null;
            if (!courseExists) { ui.WriteError("There is no course in the context"); return null; }

            var planIds = context.Course.PlanSetups.Select(s => s.Id).ToList();
            if (planIds.Any())
            {
                ui.WritePrompt("The following are a list of available plans:");
                var selectedIndex = ui.GetResponse(planIds.ToArray());
                var planId = planIds[selectedIndex];
                context.PlanSetup = context.Course.PlanSetups.FirstOrDefault(s => s.Id == planId);
                return context.PlanSetup;
            }
            return null;
        }

        public static Patient GetPatient(this ConsoleUI ui, StandAloneContext context)
        {
            var patientExists = context.Patient != null;
            if (patientExists) { context.Application.ClosePatient(); }

            var patientId = ui.GetStringInput("Which patient ID do you want?");
            if (!context.SetPatient(patientId))
            {
                ui.WriteError($"Patient {patientId} does not exist");
                if(ui.GetYesNoResponse("Do you want to try again? (Y/N)"))
                {
                    GetPatient(ui, context);
                }
            }
            return context.Patient;
        }
    }
}
