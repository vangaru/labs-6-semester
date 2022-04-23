using DAL.Models;

namespace BL.Interfaces;

public interface IStudentManager
{
    public string CreateStudent(string name, string groupId);

    public IEnumerable<Student> GetAllStudents();

    public Student FindById(string id);

    public void AddSubject(string studentId, string subjectId);

    public void Delete(string id);
}