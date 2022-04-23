using System.Collections.Generic;
using System.Linq;

namespace Lab3.Models;

public class Progress
{
    public string Id { get; set; }

    public string StudentId { get; set; }
    public Student Student { get; set; }

    public string SubjectId { get; set; }
    public Subject Subject { get; set; }

    public ICollection<Mark> Marks { get; set; } = new List<Mark>();

    public double AverageResult => Marks.Select(m => m.Value).Average();

    public override string ToString()
    {
        return
            $"PROGRESS: Id: {Id};";
    }
}