using DAL.Models;

namespace DAL.Interfaces;

public interface IStudentRepository : IDisposable
{
    public void AddStudent(Student student);
    public Student FindById(string id);
    public IEnumerable<Student> GetAllStudents();
    public void AddSubject(string id, Subject subject);
    public void Delete(string id);
}