using System;
using System.Collections.Generic;
using System.Linq;
using Autofac.Extras.Moq;
using BL.Implementations;
using DAL.Interfaces;
using DAL.Models;
using Moq;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class Tests
{
    [Test]
    public void CreateStudent_Success_ReturnsValidGuid()
    {
        using AutoMock mock = AutoMock.GetLoose();
        mock.Mock<IGroupRepository>()
            .Setup(x => x.FindById(It.IsAny<string>()))
            .Returns(new Group
            {
                Id = Guid.NewGuid().ToString()
            });
        var studentManager = mock.Create<StudentManager>();
        string studentId = studentManager.CreateStudent("student", "group");
        Assert.True(Guid.TryParse(studentId, out _));
    }

    [Test]
    public void GetAllStudents_Success_ReturnsAllStudentsFromRepository()
    {
        List<Student> sampleStudents = GetSampleStudents().ToList();
        AutoMock mock = AutoMock.GetLoose();
        mock.Mock<IStudentRepository>()
            .Setup(x => x.GetAllStudents())
            .Returns(sampleStudents);
        var studentManager = mock.Create<StudentManager>();
        Assert.AreEqual(sampleStudents.Count, studentManager.GetAllStudents().Count());
    }

    private IEnumerable<Student> GetSampleStudents()
    {
        return new List<Student>
        {
            new() {Id = Guid.NewGuid().ToString()},
            new() {Id = Guid.NewGuid().ToString()},
            new() {Id = Guid.NewGuid().ToString()},
            new() {Id = Guid.NewGuid().ToString()}
        };
    }

    [Test]
    public void FindById_Success_ReturnsValidStudentFromRepository()
    {
        var sampleStudent = new Student {Id = Guid.NewGuid().ToString()};
        using AutoMock mock = AutoMock.GetLoose();
        mock.Mock<IStudentRepository>()
            .Setup(x => x.FindById(It.IsAny<string>()))
            .Returns(sampleStudent);
        var studentManager = mock.Create<StudentManager>();
        Student actualStudent = studentManager.FindById(sampleStudent.Id);
        Assert.AreEqual(actualStudent.Id, sampleStudent.Id);
    }

    [Test]
    public void AddSubject_Success_DoesNotThrow()
    {
        using AutoMock mock = AutoMock.GetLoose();
        mock.Mock<ISubjectRepository>()
            .Setup(x => x.FindById(It.IsAny<string>()))
            .Returns(new Subject {Id = Guid.NewGuid().ToString()});
        var studentManager = mock.Create<StudentManager>();
        Assert.DoesNotThrow(() =>
            studentManager.AddSubject(
                Guid.NewGuid().ToString(), Guid.NewGuid().ToString()));
    }

    [Test]
    public void Delete_Success_DoesNotThrow()
    {
        using AutoMock mock = AutoMock.GetLoose();
        var studentManager = mock.Create<StudentManager>();
        Assert.DoesNotThrow(() => studentManager.Delete(Guid.NewGuid().ToString()));
    }
}