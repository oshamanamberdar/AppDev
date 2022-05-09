using GroupCoursework.DbContext;
using GroupCoursework.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GroupCoursework.Controllers;

public class ReturnDvdController : Controller
{
    private readonly ApplicationDbContext _context;

    public ReturnDvdController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET
    public IActionResult Index()
    {
        var actors = _context.Actors.ToList();
        var dvdCategories = _context.DvdCategories.ToList();
        var dvdTitles = _context.DvdTitles.ToList();
        var producers = _context.Producers.ToList();
        var castMembers = _context.CastMembers.ToList();
        var loans = _context.Loans.ToList();
        var dvdCopies = _context.DvdCopies.ToList();
        var members = _context.Members.ToList();
        var data = from a in loans
            where a.DateReturned == null
            join b in members on a.MemberNumber equals b.Id into table1
            from b in table1.ToList()
            select new TestView
            {
                Loan = a,
                Member = b
            };
        return View(data);
    }
}