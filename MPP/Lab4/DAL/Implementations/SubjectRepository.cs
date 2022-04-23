using DAL.Data;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Implementations;

public class SubjectRepository : ISubjectRepository
{
    private readonly ProgressDbContext _dbContext;

    public SubjectRepository(ProgressDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddSubject(Subject subject)
    {
        _dbContext.Subjects!.Add(subject);
        _dbContext.SaveChanges();
    }

    public Subject FindById(string id)
    {
        return _dbContext.Subjects!.FirstOrDefault(subject => subject.Id == id)!;
    }

    public IEnumerable<Subject> GetAllSubjects()
    {
        return _dbContext.Subjects!;
    }
    
    public void Dispose()
    {
        _dbContext.Dispose();
    }
}