using Microsoft.AspNetCore.Mvc;

namespace GroupCoursework.Controllers;

public class DashboardController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}