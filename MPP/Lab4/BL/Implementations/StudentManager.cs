using BL.Interfaces;
using DAL.Interfaces;
using DAL.Models;

namespace BL.Implementations;

public class StudentManager : IStudentManager
{
    private readonly IStudentRepository _studentRepository;
    private readonly IGroupRepository _groupRepository;
    private readonly ISubjectRepository _subjectRepository;

    public StudentManager(
        IStudentRepository studentRepository, 
        IGroupRepository groupRepository, 
        ISubjectRepository subjectRepository)
    {
        _studentRepository = studentRepository;
        _groupRepository = groupRepository;
        _subjectRepository = subjectRepository;
    }

    public string CreateStudent(string name, string groupId)
    {
        string id = Guid.NewGuid().ToString();
        Group group = _groupRepository.FindById(groupId);

        var student = new Student
        {
            Id = id,
            Name = name,
            GroupId = groupId,
            Group = group
        };
        
        _studentRepository.AddStudent(student);
        return id;
    }

    public IEnumerable<Student> GetAllStudents()
    {
        IEnumerable<Student> students = _studentRepository.GetAllStudents().ToList();
        return students;
    }

    public Student FindById(string id)
    {
        Student student = _studentRepository.FindById(id);
        return student;
    }

    public void AddSubject(string studentId, string subjectId)
    {
        Subject subject = _subjectRepository.FindById(subjectId);
        _studentRepository.AddSubject(studentId, subject);
    }

    public void Delete(string id)
    {
        _studentRepository.Delete(id);
    }
}