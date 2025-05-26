using System.Globalization;
using DbApp1.Data;
using Microsoft.EntityFrameworkCore;

namespace DbApp1;

using DbApp1.Models;

public class DbHelper
{
    private static AppDataContext Context = new AppDataContext();

    public static void AddStudent()
    {
        try
        {
            Console.WriteLine("Adding Student");

            var inputName = Helper.Ask("Name ");
            var inputLastName = Helper.Ask("Last Name");
            var inputBirtday = DateOnly.FromDateTime(DateTime.Parse(Helper.Ask("Birthday: ")));
            var inputGender = Helper.Ask("Gender");

            using (var context = new AppDataContext())
            {
                var classroomList = context.Classrooms.ToList();
                Console.WriteLine("Classroom List");
                if (Context.Classrooms.FirstOrDefault() == null)
                {
                    Console.WriteLine("Classroom Not Found");
                }

                foreach (var classroom in classroomList)
                {
                    Console.WriteLine($"{classroom.Id} - {classroom.Name}");
                }

                Console.WriteLine("Select the class you want to add the student to.");
                var selectedClassId = int.Parse(Console.ReadLine());
                var selectedClass = Context.Classrooms.Find(selectedClassId);
                if (selectedClass == null)
                {
                    Console.WriteLine("Class not found");
                    return;
                }

                var newStudent = new Student
                {
                    FirstName = inputName,
                    LastName = inputLastName,
                    Birthday = inputBirtday,
                    Gender = inputGender,
                    ClassId = selectedClassId
                };
                selectedClass.Students = new List<Student>()
                {
                    newStudent
                };
                Context.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The student has been added successfully!");
                Console.ResetColor();
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static List<Student> GetStudents()
    {
        return Context.Students.ToList();
    }

    public static void ListStudents()
    {
        var students = GetStudents();
        foreach (var student in students)
        {
            Console.WriteLine(
                $"{student.FirstName} {student.LastName},{student.Birthday:dd/MM/yyyy},{student.Gender}");
            Thread.Sleep(90);
        }
        
    }

    public static void AddTeacher()
    {
        try
        {
            Console.WriteLine("Adding Teacher");

            var inputName = Helper.Ask("Name ");
            var inputLastName = Helper.Ask("Last Name");
            var inputBirtday = DateOnly.FromDateTime(DateTime.Parse(Helper.Ask("Birthday: ")));
            var inputGender = Helper.Ask("Gender");

            using (var context = new AppDataContext())
            {
                var classroomList = context.Classrooms.ToList();
                Console.WriteLine("Classroom List");
                if (Context.Classrooms.FirstOrDefault() == null)
                {
                    Console.WriteLine("Classroom Not Found");
                }

                foreach (var classroom in classroomList)
                {
                    Console.WriteLine($"{classroom.Id} - {classroom.Name}");
                }

                Console.WriteLine("Select the class you want to add the teacher to.");
                var selectedClassId = int.Parse(Console.ReadLine());
                var selectedClass = Context.Classrooms.Find(selectedClassId);


                if (selectedClass == null)
                {
                    Console.WriteLine("Class not found");
                }

                var newTeacher = new Teacher
                {
                    FirstName = inputName,
                    LastName = inputLastName,
                    Birthday = inputBirtday,
                    Gender = inputGender,
                };

                selectedClass.Teachers = new List<Teacher>()
                {
                    newTeacher
                };
                Context.Teachers.Add(newTeacher);
                Context.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The Teacher has been added successfully!");
                Console.ResetColor();
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static List<Teacher> GetTeachers()
    {
        return Context.Teachers.ToList();
    }

    public static void ListTeachers()
    {
        var teachers = GetTeachers();
        foreach (var teacher in teachers)
        {
            Console.WriteLine(
                $"{teacher.FirstName} {teacher.LastName} | {teacher.Birthday:dd/MM/yyyy} | {teacher.Gender}");
        }

        Console.ResetColor();
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
            Context.Classrooms.Add(newClassroom);
            Context.SaveChanges();
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
        return Context.Classrooms.ToList();
    }

    public static void ListClassrooms()
    {
        var classrooms = Context.Classrooms.ToList();
        foreach (var classroom in classrooms)
        {
            Console.WriteLine($"{classroom.Name}");
        }
    }

    public static void SearchInClassrooms()
    {
        using var context = new AppDataContext();
        var classrooms = context.Classrooms.ToList();
        if (!classrooms.Any())
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("No Classrooms found");
            Console.ResetColor();
            return;
        }

        Console.WriteLine("Classroom List");
        foreach (var classroom in classrooms)
        {
            Console.WriteLine($"{classroom.Id} - {classroom.Name}");
        }

        Console.WriteLine("Select the class you want to search:");
        if (!int.TryParse(Console.ReadLine(), out var selectedClassId))
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Invalid input");
            Console.ResetColor();
            return;
        }

        var selectedClass = context.Classrooms
            .Include(c => c.Students)
            .Include(x => x.Teachers)
            .FirstOrDefault(c => c.Id == selectedClassId);
        Console.Clear();
        if (selectedClass == null)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Class not found");
            Console.ResetColor();
            return;
        }

        Console.WriteLine($"\nTeacher in {selectedClass.Name}");
        foreach (var teacher in selectedClass.Teachers)
        {
            Console.WriteLine(
                $"{teacher.FirstName} {teacher.LastName} {teacher.Birthday:dd/MM/yyyy} | {teacher.Gender}");
        }

        if (!selectedClass.Teachers.Any())
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nNo Teacher in this Classroom");
            Console.ResetColor();
        }

        Console.WriteLine($"\nStudents in {selectedClass.Name}");
        foreach (var student in selectedClass.Students)
        {
            Console.WriteLine(
                $"{student.FirstName} {student.LastName} : {student.Birthday:dd/MM/yyyy} | {student.Gender}");
        }

        if (!selectedClass.Students.Any())
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nNo Students in this Classroom");
            Console.ResetColor();
        }
    }
    
    public static void AssignedTeacher()
    {
        using var context = new AppDataContext();
        
        var teachers = Context.Teachers.ToList();
        Console.WriteLine("Teacher List");
        foreach (var teacher in teachers)
        {
            Console.WriteLine($"{teacher.Id}-{teacher.FirstName} {teacher.LastName}");
        }

        if (!teachers.Any())
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("No Teacher in this Classroom");
            Console.ResetColor();
            return;
        }
        
        Console.WriteLine("Select the teacher ID to assign to a class:");
        var selectedTeacherId = int.Parse(Console.ReadLine());
        var selectedTeacher = Context.Teachers.Find(selectedTeacherId);
        if (selectedTeacher == null)
        {
            Console.WriteLine("Teacher Not Found");
            return;
        }
        
        var classrooms = Context.Classrooms
            .Include(c => c.Teachers)
            .ToList();
        
        Console.WriteLine("Classroom List");
        foreach (var classroom in classrooms)
        {
            Console.WriteLine($"{classroom.Id} - {classroom.Name}");
        }
        
        if (!classrooms.Any())
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Class not found");
            Console.ResetColor();
            return;
        }

        Console.WriteLine("Select the class you want to add the teacher to.");
        var selectedClassId = int.Parse(Console.ReadLine());
        var selectedClass = Context.Classrooms
            .Include(c => c.Teachers)
            .FirstOrDefault(c => c.Id == selectedClassId);
        if (selectedClass == null)
        {
            Console.WriteLine("Class not found");
            return;
        }

        if (!selectedClass.Teachers.Any(t => t.Id == selectedTeacherId))
        {
            selectedClass.Teachers.Add(selectedTeacher);
            Context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Teacher successfully assigned to the classroom.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("This teacher is already assigned to the classroom.");
            Console.ResetColor();
        }
    }
    public static void AssignedStudent()
    {
        using var context = new AppDataContext();
        
        var students = Context.Students.ToList();
        Console.WriteLine("Student List");
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Id}-{student.FirstName} {student.LastName}");
        }

        if (!students.Any())
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("No Student in this Classroom");
            Console.ResetColor();
            return;
        }
        
        Console.WriteLine("Select the student ID to assign to a class:");
        var selectedStudentId = int.Parse(Console.ReadLine());
        var selectedStudent = Context.Students.Find(selectedStudentId);
        if (selectedStudent == null)
        {
            Console.WriteLine("Student Not Found");
            return;
        }
        
        var classrooms = Context.Classrooms
            .Include(c => c.Students)
            .ToList();
        
        Console.WriteLine("Classroom List");
        foreach (var classroom in classrooms)
        {
            Console.WriteLine($"{classroom.Id} - {classroom.Name}");
        }
        
        if (!classrooms.Any())
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Class not found");
            Console.ResetColor();
            return;
        }

        Console.WriteLine("Select the class you want to add the student to.");
        var selectedClassId = int.Parse(Console.ReadLine());
        var selectedClass = Context.Classrooms
            .Include(c => c.Students)
            .FirstOrDefault(c => c.Id == selectedClassId);
        if (selectedClass == null)
        {
            Console.WriteLine("Class not found");
            return;
        }

        if (!selectedClass.Students.Any(t => t.Id == selectedStudentId))
        {
            selectedClass.Students.Add(selectedStudent);
            Context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Student successfully assigned to the classroom.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("This Student is already assigned to the classroom.");
            Console.ResetColor();
        }
    }
}