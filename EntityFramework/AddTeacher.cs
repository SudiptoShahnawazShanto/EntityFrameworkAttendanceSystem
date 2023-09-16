using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public static class AddTeacher
    {
        public static List<Teacher> Teachers => new List<Teacher>
    {
        new Teacher { Id = 1, Name = "Jalaluddin", Username = "Jalaluddin", Password = "123456" },
        new Teacher { Id = 2, Name = "Md Barkat Ali", Username = "Barkat", Password = "123456" }
    };
    }
}
