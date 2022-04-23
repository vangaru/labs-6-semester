namespace DAL.Models;

public class Group
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? FacultyId { get; set; }
    public Faculty? Faculty { get; set; }
}
