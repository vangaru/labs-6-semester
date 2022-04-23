using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations;

public class StudentRepository : IStudentRepository
{
    private readonly ProgressDbContext _dbContext;

    public StudentRepository(ProgressDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddStudent(Student student)
    {
        _dbContext.Add(student);
        _dbContext.SaveChanges();
    }

    public Student FindById(string id)
    {
        return _dbContext.Students.Include(s => s.Group)
            .Include(s => s.Subjects)
            .Include(s => s.Progresses)!
                .ThenInclude(p => p.Marks)
            .FirstOrDefault(s => s.Id == id)!;
    }

    public IEnumerable<Student> GetAllStudents()
    {
        return _dbContext.Students
            .Include(s => s.Group)
            .Include(s => s.Subjects);
    }

    public void AddSubject(string id, Subject subject)
    {
        Student student = FindById(id);
        student.Subjects!.Add(subject);
        subject.Students ??= new List<Student>();
        subject.Students.Add(student);
        _dbContext.SaveChanges();
    }

    public void Delete(string id)
    {
        Student studentToDelete = FindById(id);
        _dbContext.Students.Remove(studentToDelete);
        _dbContext.SaveChanges();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}