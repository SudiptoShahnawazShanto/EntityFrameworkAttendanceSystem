using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public static class AddStudent
    {
        public static List<Student> Students => new List<Student>
        {
            new Student { Id = 1, Name = "Sudipto Shahnawaz", Username = "Sudipto", Password = "123456" },
            new Student { Id = 2, Name = "Turza Farhan", Username = "Turza", Password = "123456" }
        };
    }
}
