using GroupCoursework.DbContext;
using GroupCoursework.Models;
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
       

            List<Actor> actors = _context.Actors.ToList();
            List<DvdCategory> dvdCategories = _context.DvdCategories.ToList();
            List<DvdTitle> dvdTitles = _context.DvdTitles.ToList();
            List<Producer> producers = _context.Producers.ToList();
            List<CastMember> castMembers = _context.CastMembers.ToList();
            List<Loan> loans = _context.Loans.ToList();
            List<DvdCopy> dvdCopies = _context.DvdCopies.ToList();
            List<Member> members = _context.Members.ToList();
            var data = from a in loans
                where a.DateReturned == null
                join b in members on a.MemberNumber equals b.Id into table1
                from b in table1.ToList()


                select new TestView()
                {
                    Loan = a,
                    Member = b

                };
            return View(data);


        }
    

}
