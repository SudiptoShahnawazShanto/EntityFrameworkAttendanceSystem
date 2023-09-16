using System;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

while (true)
{
    Console.WriteLine("\nWelcome to the Class System");
    Console.WriteLine("1. Admin Login");
    Console.WriteLine("2. Teacher Login");
    Console.WriteLine("3. Student Login");
    Console.WriteLine("4. Exit");
    Console.Write("Enter your choice: ");
    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.WriteLine("\nadmin username = \"admin\" & admin password = \"123456\"");
            AdminMenu();
            break;
        case 2:
            TeacherMenu();
            break;
        case 3:
            StudentMenu();
            break;
        case 4:
            return;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}

static void AdminMenu()
{
    Console.WriteLine("\nAdmin Login");
    Console.Write("Enter admin username: ");
    string adminUsername = Console.ReadLine();
    Console.Write("Enter admin password: ");
    string adminPassword = Console.ReadLine();

    if (adminUsername == "admin" && adminPassword == "123456")
    {
        while (true)
        {
            Console.WriteLine("\nAdmin Menu");
            Console.WriteLine("1. Create Teacher");
            Console.WriteLine("2. Create Course");
            Console.WriteLine("3. Create Student");
            Console.WriteLine("4. Assign Teacher to Course");
            Console.WriteLine("5. Assign Student to Course");
            Console.WriteLine("6. Set Class Schedule");
            Console.WriteLine("7. Exit Admin Menu");
            Console.Write("Enter your choice: ");
            int adminChoice = int.Parse(Console.ReadLine());

            switch (adminChoice)
            {
                case 1:
                    CreateTeacher();
                    break;
                case 2:
                    CreateCourse();
                    break;
                case 3:
                    CreateStudent();
                    break;
                case 4:
                    AssignTeacherToCourse();
                    break;
                case 5:
                    AssignStudentToCourse();
                    break;
                case 6:
                    SetClassSchedule();
                    break;
                case 7:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    else
    {
        Console.WriteLine("Admin login failed.");
    }
}

static void TeacherMenu()
{
    Console.WriteLine("\nTeacher Login");
    Console.Write("Enter teacher username: ");
    string teacherUsername = Console.ReadLine();
    Console.Write("Enter teacher password: ");
    string teacherPassword = Console.ReadLine();

    using (var context = new AssignmentDbContext())
    {
        var teacher = context.Teachers.FirstOrDefault(t => t.Username == teacherUsername && t.Password == teacherPassword);

        if (teacher != null)
        {
            while (true)
            {
                Console.WriteLine($"\nWelcome, {teacher.Name}!");
                Console.WriteLine("Teacher Menu");
                Console.WriteLine("1. View Attendance Report");
                Console.WriteLine("2. Exit Teacher Menu");
                Console.Write("Enter your choice: ");
                int teacherChoice = int.Parse(Console.ReadLine());

                switch (teacherChoice)
                {
                    case 1:
                        Console.Write("Enter the course ID: ");
                        int courseId = int.Parse(Console.ReadLine());
                        ViewAttendanceReport(courseId);
                        break;
                    case 2:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("Teacher login failed.");
        }
    }
}

static void StudentMenu()
{
    Console.WriteLine("\nStudent Login");
    Console.Write("Enter student username: ");
    string studentUsername = Console.ReadLine();
    Console.Write("Enter student password: ");
    string studentPassword = Console.ReadLine();

    using (var context = new AssignmentDbContext())
    {
        var student = context.Students.FirstOrDefault(s => s.Username == studentUsername && s.Password == studentPassword);

        if (student != null)
        {
            while (true)
            {
                Console.WriteLine($"\nWelcome, {student.Name}!");
                Console.WriteLine("Student Menu");
                Console.WriteLine("1. Give Attendance");
                Console.WriteLine("2. Exit Student Menu");
                Console.Write("Enter your choice: ");
                int studentChoice = int.Parse(Console.ReadLine());

                switch (studentChoice)
                {
                    case 1:
                        Console.Write("Enter the course ID: ");
                        int courseId = int.Parse(Console.ReadLine());
                        GiveAttendance(student.Id, courseId);
                        break;
                    case 2:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("Student login failed.");
        }
    }
}

static void CreateTeacher()
{
    Console.WriteLine("\nCreate Teacher");
    using (var context = new AssignmentDbContext())
    {
        Console.Write("Enter teacher name: ");
        string name = Console.ReadLine();
        Console.Write("Enter teacher username: ");
        string username = Console.ReadLine();
        Console.Write("Enter teacher password: ");
        string password = Console.ReadLine();

        var newTeacher = new Teacher { Name = name, Username = username, Password = password };
        context.Teachers.Add(newTeacher);
        context.SaveChanges();
        Console.WriteLine("Teacher created successfully.");
    }
}

static void CreateCourse()
{
    Console.WriteLine("\nCreate Course");
    using (var context = new AssignmentDbContext())
    {
        Console.Write("Enter course name: ");
        string courseName = Console.ReadLine();
        Console.Write("Enter course fees: ");
        double fees = double.Parse(Console.ReadLine());
        Console.Write("Enter course teacher id: ");
        int teacherId = int.Parse(Console.ReadLine());
        Console.Write("Enter class day (Ex: Tuesday): ");
        string classDay = Console.ReadLine();
        Console.Write("Enter class schedule (Ex: Tuesday, 8PM - 10PM): ");
        string classSchedule = Console.ReadLine();
        Console.Write("Enter class start time (Ex: 20:00:00): ");
        TimeSpan classStartTime = TimeSpan.Parse(Console.ReadLine());
        Console.Write("Enter class end time (Ex: 22:00:00): ");
        TimeSpan classEndTime = TimeSpan.Parse(Console.ReadLine());

        var newCourse = new Course { CourseName = courseName, Fees = (decimal)fees, TeacherId = teacherId, ClassDay = classDay, ClassSchedule = classSchedule, ClassStartTime = classStartTime, ClassEndTime = classEndTime };
        context.Courses.Add(newCourse);
        context.SaveChanges();
        Console.WriteLine("Course created successfully.");
    }
}

static void CreateStudent()
{
    Console.WriteLine("\nCreate Student");
    using (var context = new AssignmentDbContext())
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();
        Console.Write("Enter student username: ");
        string username = Console.ReadLine();
        Console.Write("Enter student password: ");
        string password = Console.ReadLine();

        var newStudent = new Student { Name = name, Username = username, Password = password };
        context.Students.Add(newStudent);
        context.SaveChanges();
        Console.WriteLine("Student created successfully.");
    }
}

static void AssignTeacherToCourse()
{
    Console.WriteLine("\nAssign Teacher to Course");
    using (var context = new AssignmentDbContext())
    {
        Console.Write("Enter teacher ID: ");
        int teacherId = int.Parse(Console.ReadLine());
        Console.Write("Enter course ID: ");
        int courseId = int.Parse(Console.ReadLine());

        var course = context.Courses.Find(courseId);
        if (course != null)
        {
            course.TeacherId = teacherId;
            context.SaveChanges();
            Console.WriteLine("Teacher assigned to course successfully.");
        }
        else
        {
            Console.WriteLine("Course not found.");
        }
    }
}

static void AssignStudentToCourse()
{
    Console.WriteLine("\nAssign Student to Course");
    using (var context = new AssignmentDbContext())
    {
        Console.Write("Enter student ID: ");
        int studentId = int.Parse(Console.ReadLine());
        Console.Write("Enter course ID: ");
        int courseId = int.Parse(Console.ReadLine());

        var course = context.Courses.Find(courseId);
        var student = context.Students.Find(studentId);
        if (course != null && student != null)
        {
            student.CourseId = courseId;
            context.SaveChanges();
            Console.WriteLine("Course assigned to student successfully.");
        }
        else if (course == null)
        {
            Console.WriteLine("Course not found.");
        }
        else if (student == null)
        {
            Console.WriteLine("Student not found.");
        }
    }
}

static void SetClassSchedule()
{
    Console.WriteLine("\nSet Class Schedule");
    using (var context = new AssignmentDbContext())
    {
        Console.Write("Enter course ID: ");
        int courseId = int.Parse(Console.ReadLine());

        var course = context.Courses.Find(courseId);
        if (course != null)
        {
            Console.Write("Enter class schedule (e.g., Sunday 8PM - 10PM, Monday 7PM - 9PM): ");
            string schedule = Console.ReadLine();
            Console.Write("Enter total number of classes: ");
            int totalClasses = int.Parse(Console.ReadLine());

            course.ClassSchedule = schedule;
            course.TotalClasses = totalClasses;
            context.SaveChanges();
            Console.WriteLine("Class schedule set successfully.");
        }
        else
        {
            Console.WriteLine("Course not found.");
        }
    }
}

static void ViewAttendanceReport(int courseId)
{
    Console.WriteLine($"\nAttendance Report for Course ID {courseId}");
    using (var context = new AssignmentDbContext())
    {
        var attendances = context.Attendances
            .Where(a => a.CourseId == courseId)
            .Include(a => a.Student)
            .ToList();

        foreach (var attendance in attendances)
        {
            string presence = attendance.IsPresent ? "Present" : "Absent";
            Console.WriteLine($"{attendance.Student.Name}: {presence}");
        }
    }
}

static void GiveAttendance(int studentId, int courseId)
{
    using (var context = new AssignmentDbContext())
    {
        var course = context.Courses.Find(courseId);
        if (course != null)
        {
            var currentDate = DateTime.Now;
            if (currentDate.DayOfWeek.ToString() == course.ClassDay &&
                currentDate.TimeOfDay >= course.ClassStartTime && currentDate.TimeOfDay <= course.ClassEndTime)
            {
                var existingAttendance = context.Attendances
                    .FirstOrDefault(a => a.StudentId == studentId && a.CourseId == courseId && a.Date.Date == currentDate.Date);

                if (existingAttendance == null)
                {
                    var newAttendance = new Attendance
                    {
                        StudentId = studentId,
                        CourseId = courseId,
                        Date = currentDate,
                        IsPresent = true
                    };

                    context.Attendances.Add(newAttendance);
                    context.SaveChanges();
                    Console.WriteLine("Attendance marked successfully.");
                }
                else
                {
                    Console.WriteLine("Attendance already marked for today.");
                }
            }
            else
            {
                Console.WriteLine("It's not class time.");
            }
        }
        else
        {
            Console.WriteLine("Course not found.");
        }
    }
}
