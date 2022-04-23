using System.ComponentModel.DataAnnotations;

namespace Lab4.Models;

public class CreateFacultyViewModel
{
    [Required]
    public string? Name { get; set; }
}