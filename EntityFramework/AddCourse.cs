using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public static class AddCourse
    {
        public static List<Course> Courses => new List<Course>
        {
            new Course { Id = 1, CourseName = "C#", Fees = 8000, TeacherId = 1, ClassDay = "Thursday", ClassSchedule = "Thursday 9PM - 11PM", ClassStartTime = TimeSpan.Parse("21:00:00"), ClassEndTime = TimeSpan.Parse("23:00:00")},
            new Course {  Id = 2, CourseName = "Asp.Net", Fees = 30000, TeacherId = 2, ClassDay = "Monday", ClassSchedule = "Monday 9PM - 11PM", ClassStartTime = TimeSpan.Parse("21:00:00"), ClassEndTime = TimeSpan.Parse("23:00:00")}
        };
    }
}
