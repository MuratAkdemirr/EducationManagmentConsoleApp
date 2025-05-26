using DbApp1.Data;
using DbApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace DbApp1;

public class Delete
{
    private static AppDataContext dbContext = new AppDataContext();

    public static void DeleteTeacher()
    {
        try
        {
            Console.WriteLine("Delete Teacher");
            Console.WriteLine("Choose a Teacher Id To Delete");
            var teachers = DbHelper.GetTeachers();
            foreach (var teacher in teachers)
            {
                Console.WriteLine(
                    $"{teacher.Id}- {teacher.FirstName} {teacher.LastName},{teacher.Birthday:dd/MM/yyyy},{teacher.Gender},{teacher.Classrooms}");
            }

            var inputSelection = Console.ReadLine();
            var teacherId = int.Parse(inputSelection);
            var teacherToDelete = teachers.FirstOrDefault(x => x.Id == teacherId);
            if (teacherToDelete != null)
            {
                dbContext.Remove(teacherToDelete);
                dbContext.SaveChanges();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Teacher was deleted..");
            Console.ResetColor();
            Thread.Sleep(1000);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static void DeleteStudent()
    {
        try
        {
            Console.WriteLine("Delete Student");
            Console.WriteLine("Choose a Student Id To Delete");
            var students = DbHelper.GetStudents();
            foreach (var student in students)
            {
                Console.WriteLine(
                    $"{student.Id}- {student.FirstName} {student.LastName},{student.Birthday:dd/MM/yyyy},{student.Gender},{student.Classrooms}");
            }

            var inputSelection = Console.ReadLine();
            var studentId = int.Parse(inputSelection);
            var studentToDelete = students.FirstOrDefault(x => x.Id == studentId);
            if (studentToDelete != null)
            {
                dbContext.Remove(studentToDelete);
                dbContext.SaveChanges();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Student was deleted..");
            Console.ResetColor();
            Thread.Sleep(1000);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static void DeleteClassroom()
    {
        try
        {
            Console.WriteLine("Delete Classroom");
            Console.WriteLine("Choose a Classroom Id To Delete");
            var classrooms = DbHelper.GetClassrooms();
            foreach (var clasroom in classrooms)
            {
                Console.WriteLine($"{clasroom.Id}- {clasroom.Name}");
    
                var inputSelection = Console.ReadLine();
                var classroomId = int.Parse(inputSelection);
                var classroomToDelete = classrooms.FirstOrDefault(x => x.Id == classroomId);
                if (classroomToDelete != null)
                {
                    dbContext.Remove(classroomToDelete);
                    dbContext.SaveChanges();
                }
    
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The Classroom was deleted..");
                Console.ResetColor();
                Thread.Sleep(1000);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}