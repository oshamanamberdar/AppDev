using GroupCoursework.DbContext;
using Microsoft.AspNetCore.Mvc;

namespace GroupCoursework.Controllers;

public class StudioController : Controller
{
    private readonly ApplicationDbContext _context;

    public StudioController(ApplicationDbContext context)
    {
        _context = context;

    }
    // GET
    public IActionResult Index()
    {
        var data = _context.Studios.ToList();
        return  View(data);
      
    }
}