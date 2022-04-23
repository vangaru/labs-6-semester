using System.Collections.Generic;

namespace Lab3.Models;

public class Student
{
    public string Id { get; set; }
    public string Name { get; set; }

    public string GroupId { get; set; }
    public Group Group { get; set; }

    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    public List<Progress> Progresses { get; set; } = new();

    public override string ToString()
    {
        return $"STUDENT: Id: {Id}; Name: {Name};";
    }
}