using System.ComponentModel.DataAnnotations;
using DAL.Models;

namespace Lab4.Models;

public class CreateGroupViewModel
{
    [Required]
    public string? Name { get; set; }
    
    public IEnumerable<Faculty>? Faculties { get; set; }
    
    [Required]
    public string? SelectedFacultyId { get; set; }
}