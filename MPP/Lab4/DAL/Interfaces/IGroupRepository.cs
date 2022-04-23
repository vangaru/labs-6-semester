using DAL.Models;

namespace DAL.Interfaces;

public interface IGroupRepository : IDisposable
{
    public void AddGroup(Group group);
    public Group FindById(string id);
    public IEnumerable<Group> FindByName(string name);
    public IEnumerable<Group> GetAllGroups();
    public bool Exists(string id);
}