using DbApp1.Data;

namespace DbApp1;

using DbApp1.Models;

public class Update
{
    private static AppDataContext dbContext = new AppDataContext();

    public static void UpdateTeacher()
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Update Teacher");
            Console.WriteLine("Choose a Teacher Id To Update");
            var teachers0 = DbHelper.GetTeachers();
            foreach (var teacher in teachers0)
            {
                Console.WriteLine(
                    $"{teacher.Id}- {teacher.FirstName} {teacher.LastName},{teacher.Birthday:dd/MM/yyyy},{teacher.Gender},{teacher.Classroom}");
            }

            var inputSelection = Console.ReadLine();
            var teachers = DbHelper.GetTeachers();
            var teacherId = int.Parse(inputSelection);
            var teacherToUpdate = dbContext.Teachers.FirstOrDefault(x => x.Id == int.Parse(inputSelection));
            Console.Clear();
            Console.Write("Enter new First Name: (Press enter to keep current.) :");
            var newFirstName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newFirstName))
            {
                teacherToUpdate.FirstName = newFirstName;
                dbContext.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("First Name has changed sucessfully");
                Console.ResetColor();
                Thread.Sleep(750);
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter new Last Name: (Press enter to keep current.) :");
            var newLastName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newLastName))
            {
                teacherToUpdate.LastName = newLastName;
                dbContext.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Last Name has changed sucessfully");
                Console.ResetColor();
                Thread.Sleep(750);
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter new Birth Date(dd.MM.yyyy): (Press enter to keep current.) :");
            var newBirthDay = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newBirthDay))
            {
                teacherToUpdate.Birthday = DateOnly.Parse(newBirthDay);
                dbContext.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Birth date has changed sucessfully");
                Console.ResetColor();
                Thread.Sleep(750);
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter new Gender: (Press enter to keep current.) :");
            var newGender = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newGender))
            {
                teacherToUpdate.Gender = newGender;
                dbContext.SaveChanges();
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter new Classroom: (Press enter to keep current.) :");
            var newClassroom = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newClassroom))
            {
                teacherToUpdate.Classroom = newClassroom;
                dbContext.SaveChanges();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static void UpdateStudent()
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Update Student");
            Console.WriteLine("Choose a Student Id To Update");
            var students0 = DbHelper.GetStudents();
            foreach (var student in students0)
            {
                Console.WriteLine(
                    $"{student.Id}- {student.FirstName} {student.LastName},{student.Birthday:dd/MM/yyyy},{student.Gender},{student.Classroom}");
            }

            var inputSelection = Console.ReadLine();
            var student1 = DbHelper.GetStudents();
            var studentId = int.Parse(inputSelection);
            var studentToUpdate = dbContext.Teachers.FirstOrDefault(x => x.Id == int.Parse(inputSelection));
            Console.Clear();
            Console.Write("Enter new First Name: (Press enter to keep current.) :");
            var newFirstName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newFirstName))
            {
                studentToUpdate.FirstName = newFirstName;
                dbContext.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("First Name has changed sucessfully");
                Console.ResetColor();
                Thread.Sleep(750);
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter new Last Name: (Press enter to keep current.) :");
            var newLastName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newLastName))
            {
                studentToUpdate.LastName = newLastName;
                dbContext.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Last Name has changed sucessfully");
                Console.ResetColor();
                Thread.Sleep(750);
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter new Birth Date(dd.MM.yyyy): (Press enter to keep current.) :");
            var newBirthDay = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newBirthDay))
            {
                studentToUpdate.Birthday = DateOnly.Parse(newBirthDay);
                dbContext.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Birth date has changed sucessfully");
                Console.ResetColor();
                Thread.Sleep(750);
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter new Gender: (Press enter to keep current.) :");
            var newGender = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newGender))
            {
                studentToUpdate.Gender = newGender;
                dbContext.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Gender has changed sucessfully");
                Console.ResetColor();
                Thread.Sleep(750);
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter new Classroom: (Press enter to keep current.) :");
            var newClassroom = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newClassroom))
            {
                studentToUpdate.Classroom = newClassroom;
                dbContext.SaveChanges();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Classroom has changed sucessfully");
            Console.ResetColor();
            Thread.Sleep(750);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static void UpdateClassroom()
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Update Classroom");
            Console.WriteLine("Choose a Classroom Id To Update | Exit(0).");
            var classrooms = DbHelper.GetClassrooms();
            foreach (var classroom in classrooms)
            {
                Console.WriteLine($"{classroom.Id}- {classroom.Name}");
            }
            
            var classroomId = int.Parse(Console.ReadLine());
            var classroomToUpdate = dbContext.Classrooms.FirstOrDefault(x => x.Id == classroomId);
            Console.Clear();
            Console.Write("Enter new Class Name: (Press enter to keep current.) :");
            var newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                classroomToUpdate.Name = newName;
                dbContext.SaveChanges();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Classromm has changed sucessfully!");
            Console.ResetColor();
            Thread.Sleep(750);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}