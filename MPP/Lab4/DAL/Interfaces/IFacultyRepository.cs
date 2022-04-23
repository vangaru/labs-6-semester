using DAL.Models;

namespace DAL.Interfaces;

public interface IFacultyRepository : IDisposable
{
    public void AddFaculty(Faculty faculty);
    public Faculty FindById(string id);
    public IEnumerable<Faculty> FindByName(string name);
    public IEnumerable<Faculty> GetAllFaculties();

    public bool Exists(string id);
}