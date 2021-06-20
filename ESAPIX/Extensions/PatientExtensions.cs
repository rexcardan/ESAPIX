using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.API;
using static ESAPIX.Helpers.Strings.MagicStrings;

namespace ESAPIX.Extensions
{
    public static class PatientExtensions
    {
        public static Course AddCourseIfNotExists(this Patient p, string courseId)
        {
            if (!p.CanAddCourse())
            {
                throw new Exception("Can't add a course. Make sure you have called BeginModifications() on patien object");
            }

            if (p.Courses.Any(c => c.Id == courseId)) { return p.Courses.FirstOrDefault(c => c.Id == courseId); }
            else
            {
                var course = p.AddCourse();
                if (!string.IsNullOrEmpty(courseId))
                    course.Id = courseId;
                return course;
            }
        }
    }
}
