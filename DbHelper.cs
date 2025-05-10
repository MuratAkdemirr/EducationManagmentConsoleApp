using DbApp1.Data;

namespace DbApp1;

using DbApp1.Models;

public class DbHelper
{
    private static AppDataContext dbContext = new AppDataContext();

    public static void AddStudent()
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Adding Student");
            var newStudent = new Student
            {
                FirstName = Helper.Ask("Name "),
                LastName = Helper.Ask("Surname "),
                Birthday = DateOnly.FromDateTime(DateTime.Parse(Helper.Ask("Birthday: "))),
                Gender = Helper.Ask("Gender "),
                Classroom = Helper.Ask("Class ")
            };
            dbContext.Students.AddRange(newStudent);
            dbContext.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The student has been added successfully!");
            Console.ResetColor();
            Thread.Sleep(1000);
            Console.Clear();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static List<Student> GetStudents()
    {
        return dbContext.Students.ToList();
    }

    public static void ListStudents()
    {
        var students = GetStudents();
        foreach (var student in students)
        {
            Console.WriteLine(
                $"{student.FirstName} {student.LastName},{student.Birthday:dd/MM/yyyy},{student.Gender},{student.Classroom}");
            Thread.Sleep(90);
        }

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    public static void AddTeacher()
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Adding Teacher");
            var newTeacher = new Teacher
            {
                FirstName = Helper.Ask("Name "),
                LastName = Helper.Ask("Surname "),
                Birthday = DateOnly.FromDateTime(DateTime.Parse(Helper.Ask("Birthday: "))),
                Gender = Helper.Ask("Gender "),
                Classroom = Helper.Ask("Class ")
            };
            dbContext.Teachers.AddRange(newTeacher);
            dbContext.SaveChanges();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Teacher has been added successfully!");
            Console.ResetColor();
            Thread.Sleep(750);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static List<Teacher> GetTeachers()
    {
        return dbContext.Teachers.ToList();
    }

    public static void ListTeachers()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        var teachers = GetTeachers();
        foreach (var teacher in teachers)
        {
            Console.WriteLine(
                $"{teacher.FirstName} {teacher.LastName},{teacher.Birthday:dd/MM/yyyy},{teacher.Gender},{teacher.Classroom}");
        }

        Console.WriteLine("Press any key to continue");
        Console.ResetColor();
        Console.ReadKey();
    }

    public static void AddClassroom()
    {
        try
        {
            Console.WriteLine("Adding Classroom");
            var newClassroom = new Classroom
            {
                Name = Helper.Ask("Name "),
            };
            dbContext.Classrooms.Add(newClassroom);
            dbContext.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Classroom has been added successfully!");
            Console.ResetColor();
            Thread.Sleep(750);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static List<Classroom> GetClassrooms()
    {
        return dbContext.Classrooms.ToList();
    }

    public static void ListClassrooms()
    {
        var classrooms = dbContext.Classrooms.ToList();
        foreach (var classroom in classrooms)
        {
            Console.WriteLine($"{classroom.Name}");
        }

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    public static void SearchInTable()
    {
        Console.Clear();
        DbHelper.ListClassrooms();
        var inputSelection = Helper.Ask("Choose a Class");

        var teachers = DbHelper.GetTeachers();
        foreach (var teacher in teachers)
        {
            if (inputSelection == teacher.Classroom)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(
                    $"{teacher.FirstName} {teacher.LastName} {teacher.Classroom} {teacher.Gender} {teacher.Birthday}");
                Console.ResetColor();
                Thread.Sleep(90);
            }
        }

        var students = DbHelper.GetStudents();
        foreach (var student in students)
        {
            if (inputSelection == student.Classroom)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(
                    $"{student.FirstName} {student.LastName} {student.Classroom} {student.Gender} {student.Birthday}");
                Thread.Sleep(90);
                Console.ResetColor();
            }
        }
    }
}