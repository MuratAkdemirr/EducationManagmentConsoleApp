namespace DbApp1;

public class Menu
{
    public static void MainMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        var inputSelection =
            Helper.AskOption("EDUCATION MANAGMENT SYSTEM", ["TEACHER", "STUDENT", "CLASSROOM", "EXIT"]);
        switch (inputSelection)
        {
            case 1:
                Console.Clear();
                TeacherMenu();
                break;
            case 2:
                Console.Clear();
                StudentMenu();
                break;
            case 3:
                Console.Clear();
                ClassMenu();
                break;
            case 4:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("The program has been terminated..");
                Console.ResetColor();
                Thread.Sleep(1250);
                Console.Clear();
                break;
        }

        Console.ResetColor();
    }

    public static void TeacherMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            var inputSelection = Helper.AskOption("TEACHER MENU", ["ADD", "LIST", "UPDATE", "DELETE", "MAIN MENU"]);
            switch (inputSelection)
            {
                case 1:
                    Console.Clear();
                    DbHelper.AddTeacher();
                    break;
                case 2:
                    Console.Clear();
                    DbHelper.ListTeachers();
                    break;
                case 3:
                    Console.Clear();
                    Update.UpdateTeacher();
                    break;
                case 4:
                    Console.Clear();
                    Delete.DeleteTeacher();
                    break;
                case 5:
                    Console.Clear();
                    MainMenu(); 
                    break;
            }

            Console.ResetColor();
        }
    }

    public static void StudentMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            var inputSelection = Helper.AskOption("STUDENT MENU", ["ADD", "LIST", "UPDATE", "DELETE", "MAIN MENU"]);
            switch (inputSelection)
            {
                case 1:
                    Console.Clear();
                    DbHelper.AddStudent();
                    break;
                case 2:
                    Console.Clear();
                    DbHelper.ListStudents();
                    break;
                case 3:
                    Console.Clear();
                    Update.UpdateStudent();
                    break;
                case 4:
                    Console.Clear();
                    Delete.DeleteStudent();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }

            Console.ResetColor();
        }
        
    }

    public static void ClassMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            var inputSelection = Helper.AskOption("CLASSROOM MENU", ["ADD", "LIST", "UPDATE", "DELETE", "MAIN MENU"]);
            switch (inputSelection)
            {
                case 1:
                    Console.Clear();
                    DbHelper.AddClassroom();
                    break;
                case 2:
                    Console.Clear();
                    DbHelper.SearchInTable();
                    break;
                case 3:
                    Console.Clear();
                    Update.UpdateClassroom();
                    break;
                case 4:
                    Console.Clear();
                    Delete.DeleteClassroom();
                    break;
                case 5:
                    Console.Clear();
                    MainMenu();
                    break;
            }

            Console.ResetColor();
        }
    }
}