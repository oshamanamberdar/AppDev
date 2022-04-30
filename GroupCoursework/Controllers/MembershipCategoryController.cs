using GroupCoursework.DbContext;
using Microsoft.AspNetCore.Mvc;

namespace GroupCoursework.Controllers;

public class MembershipCategoryController : Controller
{
    private readonly ApplicationDbContext _context;

    public MembershipCategoryController(ApplicationDbContext context)
    {
        _context = context;

    }
    // GET
    public IActionResult Index()
    {
        var data = _context.MembershipCategories.ToList();
        return  View(data);
    }
}