using GroupCoursework.DbContext;
using GroupCoursework.Models;
using GroupCoursework.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GroupCoursework.Controllers;

public class DashboardController : Controller
{
    private readonly ApplicationDbContext _context;

    public DashboardController(ApplicationDbContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }
    


}