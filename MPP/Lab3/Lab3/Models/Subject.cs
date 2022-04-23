using System.Collections.Generic;

namespace Lab3.Models;

public class Subject
{
    public string Id { get; set; }
    public string Name { get; set; }
    public ICollection<Student> Students { get; set; } = new List<Student>();

    public override string ToString()
    {
        return $"SUBJECT: Id: {Id}; Name: {Name}";
    }
}