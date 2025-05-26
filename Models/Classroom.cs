namespace DbApp1.Models;

public class Classroom
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Student> Students { get; set; } = new List<Student>();
    public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}