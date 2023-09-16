using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public decimal Fees { get; set; }
        public int TeacherId { get; set; }
        public string ClassSchedule { get; set; }
        public TimeSpan ClassStartTime { get; set; }
        public TimeSpan ClassEndTime { get; set; }
        public string ClassDay { get; set; }
        public int TotalClasses { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
