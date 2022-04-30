using GroupCoursework.DbContext;
using Microsoft.AspNetCore.Mvc;

namespace GroupCoursework.Controllers;

public class ProducerController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProducerController(ApplicationDbContext context)
    {
        _context = context;

    }
    // GET
    public IActionResult Index()
    {
        var data = _context.Producers.ToList();
        return  View(data);
    }
}