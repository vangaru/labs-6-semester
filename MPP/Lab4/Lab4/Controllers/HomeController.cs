using System.Collections;
using System.Diagnostics;
using BL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Lab4.Models;

namespace Lab4.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IStudentManager _studentManager;

    public HomeController(ILogger<HomeController> logger, IStudentManager studentManager)
    {
        _logger = logger;
        _studentManager = studentManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        IEnumerable<Student> students = _studentManager.GetAllStudents();
        
        var model = new HomeIndexViewModel
        {
            Students = students
        };
        
        return View(model);
    }

    [HttpGet]
    public IActionResult Sort()
    {
        IEnumerable<Student> students = _studentManager.GetAllStudents().OrderBy(s => s.Name);
        var model = new HomeIndexViewModel()
        {
            Students = students
        };
        return View("Index", model);
    }

    [HttpGet]
    public IActionResult Filter(string filterName)
    {
        IEnumerable<Student> students = _studentManager.GetAllStudents().Where(s => s.Name!.Contains(filterName));
        var model = new HomeIndexViewModel
        {
            Students = students
        };
        return View("Index", model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }

    [HttpDelete]
    public IActionResult Delete(string id)
    {
        _studentManager.Delete(id);
        return RedirectToAction("Index");
    }
}