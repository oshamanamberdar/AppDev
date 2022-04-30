using GroupCoursework.DbContext;
using Microsoft.AspNetCore.Mvc;

namespace GroupCoursework.Controllers;

public class DvdCopyController : Controller
{
    private readonly ApplicationDbContext _context;

    public DvdCopyController(ApplicationDbContext context)
    {
        _context = context;

    }
    // GET
    public IActionResult Index()
    {
        var data = _context.DvdCopies.ToList();
        return  View(data);
    }
}