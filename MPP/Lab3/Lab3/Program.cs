using System;
using System.Collections.Generic;
using System.Linq;
using Lab3.Data;
using Lab3.Models;
using Lab3.Repositories;

namespace Lab3;

internal static class Program
{
    private static readonly string FacultyId = Guid.NewGuid().ToString();
    private static readonly string GroupId = Guid.NewGuid().ToString();
    private static readonly string Mark1Id = Guid.NewGuid().ToString();
    private static readonly string Mark2Id = Guid.NewGuid().ToString();
    private static readonly string ProgressId = Guid.NewGuid().ToString();
    private static readonly string StudentId = Guid.NewGuid().ToString();
    private static readonly string SubjectId = Guid.NewGuid().ToString();

    private static void Main()
    {
        var dbContext = new StudentsProgressContext();
        using var repository = new StudentsProgressRepository(dbContext);

        /*string studentId = "fb4eb95b-5b75-498c-bbc3-d3c0826617c1";
        repository.ChangeStudentName(studentId, "Krechko Kirill");*/

        foreach (var mark in repository.GetAllProgresses())
        {
            Console.WriteLine(mark);
        }

        //repository.DeleteProgressesLessThan(6.0);

        /*var faculty = new Faculty
        {
            Id = FacultyId,
            Name = "IT Faculty"
        };
        
        repository.AddFaculty(faculty);

        var group = new Group
        {
            Id = GroupId,
            Name = "Software development",
            FacultyId = FacultyId,
            Faculty = faculty
        };
        
        repository.AddGroup(group);

        var student = new Student
        {
            Id = StudentId,
            Name = "Nikolay Pivnik",
            GroupId = GroupId,
            Group = group
        };

        var subject = new Subject
        {
            Id = SubjectId,
            Name = "Computer Networks"
        };

        var subjects = new List<Subject> {subject};
        
        repository.InitStudent(student, subjects);

        var progress = new Progress
        {
            Id = ProgressId,
            StudentId = StudentId,
            Student = student,
            SubjectId = SubjectId,
            Subject = subject
        };

        var mark1 = new Mark
        {
            Id = Mark1Id,
            Value = 5.3
        };

        var mark2 = new Mark
        {
            Id = Mark2Id,
            Value = 6.0
        };

        var marks = new List<Mark> {mark1, mark2};
        
        repository.InitProgress(progress, marks);*/
    }
}