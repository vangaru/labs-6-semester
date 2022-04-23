using BL.Interfaces;
using DAL.Interfaces;
using DAL.Models;

namespace BL.Implementations;

public class GroupManager : IGroupManager
{
    private readonly IGroupRepository _groupRepository;
    private readonly IFacultyRepository _facultyRepository;
    
    public GroupManager(IGroupRepository groupRepository, IFacultyRepository facultyRepository)
    {
        _groupRepository = groupRepository;
        _facultyRepository = facultyRepository;
    }

    public string CreateGroup(string name, string facultyId)
    {
        Faculty faculty = _facultyRepository.FindById(facultyId);
        
        var group = new Group
        {
            Id = Guid.NewGuid().ToString(),
            Name = name,
            FacultyId = facultyId,
            Faculty = faculty
        };
        _groupRepository.AddGroup(group);
        return group.Id;
    }

    public IEnumerable<Group> GetAllGroups()
    {
        return _groupRepository.GetAllGroups();
    }

    public void Dispose()
    {
        _groupRepository.Dispose();
        _facultyRepository.Dispose();
    }
}