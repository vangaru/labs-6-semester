using System.Collections.Generic;

namespace Lab3.Models;

public class Faculty
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<Group> Groups { get; set; } = new();

    public override string ToString()
    {
        return $"FACULTY: Id: {Id}; Name: {Name}";
    }
}