using DAL.Models;

namespace BL.Interfaces;

public interface ISubjectManager
{
    public string CreateSubject(string name);

    public IEnumerable<Subject> GetSubjects();
}