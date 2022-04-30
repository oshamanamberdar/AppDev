using GroupCoursework.DbContext;
using Microsoft.AspNetCore.Mvc;

namespace GroupCoursework.Controllers;

public class LoanTypeController : Controller
{
    private readonly ApplicationDbContext _context;

    public LoanTypeController(ApplicationDbContext context)
    {
        _context = context;

    }
    // GET
    public IActionResult Index()
    {
        var data = _context.LoanTypes.ToList();
        return  View(data);
    }
}