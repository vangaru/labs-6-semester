using DAL.Models;

namespace BL.Interfaces;

public interface IFacultyManager : IDisposable
{
    public string CreateFaculty(string facultyName);
    public IEnumerable<Faculty> GetAllFaculties();
}