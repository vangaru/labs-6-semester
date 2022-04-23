using DAL.Data;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Implementations;

public class GroupRepository : IGroupRepository
{
    private readonly ProgressDbContext _dbContext;

    public GroupRepository(ProgressDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddGroup(Group group)
    {
        _dbContext.Groups!.Add(group);
        _dbContext.SaveChanges();
    }

    public Group FindById(string id)
    {
        return _dbContext.Groups!.FirstOrDefault(group => group.Id == id) 
               ?? throw new ArgumentException($"Cannot find group with specified Id: {id}");
    }

    public IEnumerable<Group> FindByName(string name)
    {
        return _dbContext.Groups!.Where(group => group.Name == name);
    }

    public IEnumerable<Group> GetAllGroups()
    {
        return _dbContext.Groups!;
    }

    public bool Exists(string id)
    {
        return _dbContext.Groups!.Any(group => group.Id == id);
    }
    
    public void Dispose()
    {
        _dbContext.Dispose();
    }
}