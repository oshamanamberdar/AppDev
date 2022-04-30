using GroupCoursework.DbContext;
using Microsoft.AspNetCore.Mvc;

namespace GroupCoursework.Controllers;

public class DvdCategoryController : Controller
{
    private readonly ApplicationDbContext _context;

    public DvdCategoryController(ApplicationDbContext context)
    {
        _context = context;

    }
    // GET
    public IActionResult Index()
    {
        var data = _context.DvdCategories.ToList();
        return  View(data);
       
    }
}