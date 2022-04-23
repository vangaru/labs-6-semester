using DAL.Models;

namespace BL.Interfaces;

public interface IGroupManager : IDisposable
{
    public string CreateGroup(string name, string facultyId);

    public IEnumerable<Group> GetAllGroups();
}