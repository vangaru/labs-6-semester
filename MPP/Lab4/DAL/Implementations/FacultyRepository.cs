using DAL.Data;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Implementations;

public class FacultyRepository : IFacultyRepository
{
    private readonly ProgressDbContext _dbContext;
    
    public FacultyRepository(ProgressDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddFaculty(Faculty faculty)
    {
        _dbContext.Faculties!.Add(faculty);
        _dbContext.SaveChanges();
    }

    public Faculty FindById(string id)
    {
        return _dbContext.Faculties!.FirstOrDefault(faculty => faculty.Id == id) 
               ?? throw new ArgumentException($"Cannot find faculty with specified Id: {id}");
    }

    public IEnumerable<Faculty> FindByName(string name)
    {
        return _dbContext.Faculties!.Where(faculty => faculty.Name == name);
    }

    public IEnumerable<Faculty> GetAllFaculties()
    {
        return _dbContext.Faculties!;
    }

    public bool Exists(string id)
    {
        return _dbContext.Faculties!.Any(faculty => faculty.Id == id);
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}