using BL.Interfaces;
using DAL.Models;
using Lab4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers;

public class GroupController : Controller
{
    private readonly ILogger<GroupController> _logger;
    private readonly IFacultyManager _facultyManager;
    private readonly IGroupManager _groupManager;

    public GroupController(
        ILogger<GroupController> logger, 
        IFacultyManager facultyManager, 
        IGroupManager groupManager)
    {
        _logger = logger;
        _facultyManager = facultyManager;
        _groupManager = groupManager;
    }

    public IActionResult Index()
    {
        List<Faculty> allFaculties = _facultyManager.GetAllFaculties().ToList();
        
        var createGroupViewModel = new CreateGroupViewModel
        {
            Faculties = allFaculties
        };
        
        return View(createGroupViewModel);
    }

    [HttpPost]
    public IActionResult Index(CreateGroupViewModel groupViewModel)
    {
        groupViewModel.Faculties = _facultyManager.GetAllFaculties().ToList();
        if (!ModelState.IsValid)
        {
            return View(groupViewModel);
        }

        _groupManager.CreateGroup(groupViewModel.Name!, groupViewModel.SelectedFacultyId!);
        
        return View(groupViewModel);
    }
}