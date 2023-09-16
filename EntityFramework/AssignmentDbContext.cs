using EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class AssignmentDbContext : DbContext
    {
        private readonly string _connectionString;

        public AssignmentDbContext()
        {
            _connectionString = "Server=DESKTOP-I3U1030\\SQLEXPRESS;Database=CSharpB14;User Id=admin;Password=123456;TrustServerCertificate=True";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasData(AddTeacher.Teachers);
            modelBuilder.Entity<Course>().HasData(AddCourse.Courses);
            modelBuilder.Entity<Student>().HasData(AddStudent.Students);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
    }
}
