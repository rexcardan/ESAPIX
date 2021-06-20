using ESAPIX.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
