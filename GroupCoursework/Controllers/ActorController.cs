using GroupCoursework.DbContext;
using Microsoft.AspNetCore.Mvc;

namespace GroupCoursework.Controllers;

public class ActorController : Controller
{
    private readonly ApplicationDbContext _context;

    public ActorController(ApplicationDbContext context)
    {
        _context = context;

    }
    // GET
    public IActionResult Index()
    {
        var data = _context.Actors.ToList();
        return  View(data);
    }
}