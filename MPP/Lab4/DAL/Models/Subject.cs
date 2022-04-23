namespace DAL.Models;

public class Subject
{
    public string? Id { get; set; }
    
    public string? Name { get; set; }

    public ICollection<Student>? Students { get; set; }
}