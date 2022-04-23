using BL.Interfaces;
using Lab4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers;

public class SubjectController : Controller
{
    private readonly ISubjectManager _subjectManager;
    
    public SubjectController(ISubjectManager subjectManager)
    {
        _subjectManager = subjectManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(CreateSubjectViewModel subjectViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(subjectViewModel);
        }

        _subjectManager.CreateSubject(subjectViewModel.Name!);
        return View(null);
    }
}