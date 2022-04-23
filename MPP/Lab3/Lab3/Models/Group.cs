using System.Collections.Generic;

namespace Lab3.Models;

public class Group
{
    public string Id { get; set; }
    public string Name { get; set; }

    public string FacultyId { get; set; }
    public Faculty Faculty { get; set; }

    public List<Student> Students { get; set; } = new();

    public override string ToString()
    {
        return $"GROUP: Id: {Id}; Name: {Name};";
    }
}