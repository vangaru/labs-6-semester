using System.ComponentModel.DataAnnotations;

namespace Lab4.Models;

public class CreateSubjectViewModel
{
    [Required]
    public string? Name { get; set; }
}