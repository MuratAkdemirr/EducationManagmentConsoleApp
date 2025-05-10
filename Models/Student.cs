namespace DbApp1.Models;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly Birthday { get; set; }
    public string Gender { get; set; }
    public string Classroom { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}