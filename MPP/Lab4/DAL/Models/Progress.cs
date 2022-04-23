namespace DAL.Models;

public class Progress
{
    public string? Id { get; set; }

    public string? StudentId { get; set; }
    public Student? Student { get; set; }
    
    public string? SubjectId { get; set; }
    public Subject? Subject { get; set; }

    public ICollection<Mark>? Marks { get; set; }
}