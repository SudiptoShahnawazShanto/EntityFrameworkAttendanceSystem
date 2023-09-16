using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<Course> TaughtCourses { get; set; }

        public void ViewAttendanceReport(int courseId)
        {
            using (var context = new AssignmentDbContext())
            {
                var attendances = context.Attendances
                    .Where(a => a.CourseId == courseId)
                    .Include(a => a.Student)
                    .ToList();

                Console.WriteLine("Attendance Report for Course:");
                foreach (var attendance in attendances)
                {
                    string presence = attendance.IsPresent ? "Present" : "Absent";
                    Console.WriteLine($"{attendance.Student.Name}: {presence}");
                }
            }
        }
    }
}
