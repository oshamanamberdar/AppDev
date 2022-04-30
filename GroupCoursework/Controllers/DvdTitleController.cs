using GroupCoursework.DbContext;
using Microsoft.AspNetCore.Mvc;

namespace GroupCoursework.Controllers;

public class DvdTitleController : Controller
{
    private readonly ApplicationDbContext _context;

    public DvdTitleController(ApplicationDbContext context)
    {
        _context = context;

    }
    // GET
    public IActionResult Index()
    {
        var data = _context.DvdTitles.ToList();
        return  View(data);
    }
}