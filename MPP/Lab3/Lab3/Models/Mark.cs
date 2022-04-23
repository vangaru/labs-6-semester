using System;

namespace Lab3.Models;

public class Mark : IComparable
{
    public string Id { get; set; }
    public double Value { get; set; }

    public string ProgressId { get; set; }
    public Progress Progress { get; set; }
    
    public int CompareTo(object obj)
    {
        if (obj is Mark mark)
        {
            return (int) (mark.Value - Value);
        }

        throw new ArgumentException();
    }

    public override string ToString()
    {
        return $"MARK: Id: {Id}; Value: {Value};";
    }
}