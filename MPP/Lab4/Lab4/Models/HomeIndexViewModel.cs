using DAL.Models;

namespace Lab4.Models;

public class HomeIndexViewModel
{
    public IEnumerable<Student>? Students { get; set; }
}