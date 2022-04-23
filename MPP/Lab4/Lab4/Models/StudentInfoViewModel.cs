using System.ComponentModel.DataAnnotations;
using DAL.Models;

namespace Lab4.Models;

public class StudentInfoViewModel
{
    public Student? Student { get; set; }

    public IEnumerable<Subject>? Subjects;

    [Required]
    public string? SelectedSubjectId { get; set; }
}