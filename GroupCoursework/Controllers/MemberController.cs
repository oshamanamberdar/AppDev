using GroupCoursework.DbContext;
using Microsoft.AspNetCore.Mvc;

namespace GroupCoursework.Controllers;

public class MemberController : Controller
{
    private readonly ApplicationDbContext _context;

    public MemberController(ApplicationDbContext context)
    {
        _context = context;

    }
    // GET
    public IActionResult Index()
    {
        var data = _context.Members.ToList();
        return  View(data);
    }
}