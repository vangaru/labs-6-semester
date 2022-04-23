using System;
using System.Collections.Generic;
using System.Linq;
using Lab3.Data;
using Lab3.Models;

namespace Lab3.Repositories;

public class StudentsProgressRepository : IDisposable
{
    private readonly StudentsProgressContext _dbContext;

    public StudentsProgressRepository(StudentsProgressContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<Progress> GetAllProgresses()
    {
        Console.WriteLine("Getting all progresses");
        return _dbContext.Progresses.ToList();
    }

    public List<Mark> GetAllMarks()
    {
        Console.WriteLine("Getting all marks");
        return _dbContext.Marks.ToList();
    }

    public List<Mark> GetAllMarksSorted()
    {
        Console.WriteLine("Getting sorted marks");
        List<Mark> marksToSort = _dbContext.Marks.ToList();
        marksToSort.Sort();
        return marksToSort;
    }

    public void AddFaculty(Faculty faculty)
    {
        Console.WriteLine($"Adding {faculty}");
        _dbContext.Faculties.Add(faculty);
        _dbContext.SaveChanges();
    }

    public void AddGroup(Group group)
    {
        Console.WriteLine($"Adding {group}");
        _dbContext.Groups.Add(group);
        _dbContext.SaveChanges();
    }

    public void AddStudent(Student student)
    {
        Console.WriteLine($"Adding {student}");
        _dbContext.Students.Add(student);
        _dbContext.SaveChanges();
    }

    public void AddSubject(Subject subject)
    {
        Console.WriteLine($"Adding subject");
        _dbContext.Subjects.Add(subject);
        _dbContext.SaveChanges();
    }

    public void InitStudent(Student student, List<Subject> subjects)
    {
        Console.WriteLine($"Initializing {student}");
        foreach (var subject in subjects)
        {
            Console.WriteLine($"Adding {subject}");
            subject.Students.Add(student);
            student.Subjects.Add(subject);
            _dbContext.Subjects.Add(subject);
        }

        _dbContext.Students.Add(student);
        _dbContext.SaveChanges();
    }

    public void AddProgress(Progress progress)
    {
        Console.WriteLine($"Adding {progress}");
        _dbContext.Progresses.Add(progress);
        _dbContext.SaveChanges();
    }

    public void AddMark(Mark mark)
    {
        Console.WriteLine($"Adding {mark}");
        _dbContext.Marks.Add(mark);
        _dbContext.SaveChanges();
    }

    public void InitProgress(Progress progress, List<Mark> marks)
    {
        Console.WriteLine($"Initializing {progress}");
        foreach (var mark in marks)
        {
            Console.WriteLine($"Adding {mark}");
            mark.ProgressId = progress.Id;
            mark.Progress = progress;
            progress.Marks.Add(mark);
            _dbContext.Marks.Add(mark);
        }

        _dbContext.Progresses.Add(progress);
        _dbContext.SaveChanges();
    }

    public void DeleteProgressesLessThan(double averageResult)
    {
        Console.WriteLine($"Deleting progress less than {averageResult}");
        var progressesToDelete =
            _dbContext.Progresses.Where(p => p.Marks.Select(m => m.Value).Average() < averageResult).ToList();
        foreach (var progress in progressesToDelete)
        {
            Console.WriteLine($"Deleting {progress}");
        }
        _dbContext.Progresses.RemoveRange(progressesToDelete);
        _dbContext.SaveChanges();
    }

    public void ChangeStudentName(string studentId, string newName)
    {
        Console.WriteLine($"Updating student with id {studentId}");
        Student studentToUpdate = _dbContext.Students.FirstOrDefault(s => s.Id == studentId);
        Console.WriteLine($"Student to update: {studentToUpdate}");
        if (studentToUpdate != null)
        {
            studentToUpdate.Name = newName;
            _dbContext.SaveChanges();
        }
        Console.WriteLine($"New name {newName}");
    }

    public void Dispose()
    {
        _dbContext?.Dispose();
    }
}