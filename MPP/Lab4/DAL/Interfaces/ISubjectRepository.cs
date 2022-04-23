using DAL.Models;

namespace DAL.Interfaces;

public interface ISubjectRepository : IDisposable
{
    public void AddSubject(Subject subject);
    public Subject FindById(string id);
    public IEnumerable<Subject> GetAllSubjects();
}