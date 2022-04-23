using BL.Interfaces;
using DAL.Models;
using Lab4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers;

public class StudentController : Controller
{
    private readonly IStudentManager _studentManager;
    private readonly ISubjectManager _subjectManager;
    private readonly IGroupManager _groupManager;
    
    public StudentController(
        IStudentManager studentManager, 
        IGroupManager groupManager, 
        ISubjectManager subjectManager)
    {
        _studentManager = studentManager;
        _groupManager = groupManager;
        _subjectManager = subjectManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<Group> groups = _groupManager.GetAllGroups().ToList();

        var viewModel = new CreateStudentViewModel
        {
            Groups = groups
        };
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Info(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Student student = _studentManager.FindById(id);
        IEnumerable<Subject> subjects = _subjectManager.GetSubjects();

        var studentInfoViewModel = new StudentInfoViewModel
        {
            Student = student,
            Subjects = subjects
        };
        
        return View(studentInfoViewModel);
    }

    [HttpPost]
    public IActionResult Index(CreateStudentViewModel createStudentViewModel)
    {
        createStudentViewModel.Groups = _groupManager.GetAllGroups().ToList();
        if (!ModelState.IsValid)
        {
            return View(createStudentViewModel);
        }

        _studentManager.CreateStudent(createStudentViewModel.Name!, createStudentViewModel.SelectedGroupId!);
        return View(createStudentViewModel);
    }

    [HttpPost]
    public IActionResult Info(string subjectId, string studentId)
    {
        _studentManager.AddSubject(studentId, subjectId);

        Student student = _studentManager.FindById(studentId);
        IEnumerable<Subject> subjects = _subjectManager.GetSubjects();

        var studentInfoViewModel = new StudentInfoViewModel
        {
            Student = student,
            Subjects = subjects
        };

        return View(studentInfoViewModel);
    }
}