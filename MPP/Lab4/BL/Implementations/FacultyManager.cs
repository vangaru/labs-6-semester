using BL.Interfaces;
using DAL.Interfaces;
using DAL.Models;

namespace BL.Implementations;

public class FacultyManager : IFacultyManager
{
    private readonly IFacultyRepository _facultyRepository;

    public FacultyManager(IFacultyRepository facultyRepository)
    {
        _facultyRepository = facultyRepository;
    }
    
    public string CreateFaculty(string facultyName)
    {
        var facultyId = Guid.NewGuid().ToString();
        var faculty = new Faculty
        {
            Id = facultyId,
            Name = facultyName
        };
        _facultyRepository.AddFaculty(faculty);
        
        return facultyId;
    }

    public IEnumerable<Faculty> GetAllFaculties()
    {
        return _facultyRepository.GetAllFaculties();
    }

    public void Dispose()
    {
        _facultyRepository.Dispose();
    }
}