using System.ComponentModel.DataAnnotations;
using DAL.Models;

namespace Lab4.Models;

public class CreateStudentViewModel
{
    [Required]
    public string? Name { get; set; }

    public IEnumerable<Group>? Groups;
    
    [Required] 
    public string? SelectedGroupId { get; set; }
}