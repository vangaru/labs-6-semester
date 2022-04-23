namespace DAL.Models;

public class Mark
{
    public string? Id { get; set; }
    
    public double? Value { get; set; }

    public string? ProgressId { get; set; }

    public Progress? Progress { get; set; }
}