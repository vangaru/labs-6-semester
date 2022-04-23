using BL.Interfaces;
using DAL.Interfaces;
using DAL.Models;

namespace BL.Implementations;

public class SubjectManager : ISubjectManager
{
    private readonly ISubjectRepository _subjectRepository;

    public SubjectManager(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public string CreateSubject(string name)
    {
        string id = Guid.NewGuid().ToString();
        var subject = new Subject
        {
            Id = id,
            Name = name
        };

        _subjectRepository.AddSubject(subject);
        return id;
    }

    public IEnumerable<Subject> GetSubjects()
    {
        return _subjectRepository.GetAllSubjects();
    }
}