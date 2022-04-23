using System.Collections.ObjectModel;

namespace DAL.Models;

public class Faculty
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    private ICollection<Group> Groups { get; set; } = new Collection<Group>();
}