namespace DAL.Models;

public class Student
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? GroupId { get; set; }

    public Group? Group { get; set; }

    public ICollection<Subject>? Subjects { get; set; }

    public ICollection<Progress>? Progresses { get; set; }
}