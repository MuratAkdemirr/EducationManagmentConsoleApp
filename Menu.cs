namespace DbApp1;

public class Menu
{
    private static ConsoleMenu _consoleMenu = new("EDUCATION MANAGMENT SYSTEM", true);

    public static void MainMenu()
    {
        _consoleMenu
            .AddMenu("Teacher", TeacherMenu)
            .AddMenu("Student", StudentMenu)
            .AddMenu("Classroom", ClassMenu);

        Console.ResetColor();
        _consoleMenu.Show();
    }

    private static void TeacherMenu()
    {
        Console.Clear();
        var teacherMenu = new ConsoleMenu("TEACHER MANAGEMENT")
            .AddOption("Add", DbHelper.AddTeacher)
            .AddOption("List", DbHelper.ListTeachers)
            .AddOption("Delete", Delete.DeleteTeacher)
            .AddOption("Update", Update.UpdateTeacher)
            .AddOption("Assing Classroom", DbHelper.AssignedTeacher);
        teacherMenu.Show();
    }

    private static void StudentMenu()
    {
        var studentMenu = new ConsoleMenu("STUDENT MANAGMENT")
            .AddOption("Add", DbHelper.AddStudent)
            .AddOption("List", DbHelper.ListStudents)
            .AddOption("Delete", Delete.DeleteStudent)
            .AddOption("Update", Update.UpdateStudent)
            .AddOption("As   +," +
                       "    sing Classroom", DbHelper.AssignedStudent);
        studentMenu.Show();
    }

    private static void ClassMenu()
    {
        var classMenu = new ConsoleMenu("CLASS MANAGMENT")
            .AddOption("Add", DbHelper.AddClassroom)
            .AddOption("List", DbHelper.SearchInClassrooms)
            .AddOption("Delete", Delete.DeleteClassroom)
            .AddOption("Update", Update.UpdateClassroom);
        classMenu.Show();
    }
}