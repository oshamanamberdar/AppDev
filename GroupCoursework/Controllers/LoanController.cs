using GroupCoursework.DbContext;
using Microsoft.AspNetCore.Mvc;

namespace GroupCoursework.Controllers;

public class LoanController : Controller
{
    private readonly ApplicationDbContext _context;

    public LoanController(ApplicationDbContext context)
    {
        _context = context;

    }
    // GET
    public IActionResult Index()
    {
        var data = _context.Loans.ToList();
        return  View(data);
    }
}