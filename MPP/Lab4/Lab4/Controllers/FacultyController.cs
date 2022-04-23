using BL.Interfaces;
using Lab4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers;

public class FacultyController : Controller
{
    private readonly ILogger<FacultyController> _logger;
    private readonly IFacultyManager _facultyManager;
    
    public FacultyController(ILogger<FacultyController> logger, 
        IFacultyManager facultyManager)
    {
        _logger = logger;
        _facultyManager = facultyManager;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Index(CreateFacultyViewModel facultyViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(facultyViewModel);
        }

        _facultyManager.CreateFaculty(facultyViewModel.Name!);
        return View(null);
    }
}