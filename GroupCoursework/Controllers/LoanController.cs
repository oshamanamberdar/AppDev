using GroupCoursework.DbContext;
using GroupCoursework.Models;
using GroupCoursework.Services;
using GroupCoursework.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroupCoursework.Controllers;

public class LoanController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILoanService _service;

    public LoanController(ApplicationDbContext context, ILoanService service)
    {
        _context = context;
        _service = service;

    }
    // GET
    public  async Task<IActionResult> Index()
    {
        try
        {
            List<Actor> actors = _context.Actors.ToList();
            List<DvdCategory> dvdCategories = _context.DvdCategories.ToList();
            List<DvdTitle> dvdTitles = _context.DvdTitles.ToList();
            List<Producer> producers = _context.Producers.ToList();
            List<CastMember> castMembers = _context.CastMembers.ToList();
            List<Loan> loans = _context.Loans.ToList();
            List<DvdCopy> dvdCopies = _context.DvdCopies.ToList();
            List<Member> members = _context.Members.ToList();
            var data = from a in members
                join b in loans on a.Id equals  b.MemberNumber into table1
                from b in table1.ToList()
                join c in dvdCopies on b.CopyNumber equals c.Id into table2
                from c in table2.ToList()
                join d in dvdTitles on c.DvdNumber equals d.Id into table3
                from d in table3.ToList()
                select new TestView()
                {
                    Member = a,
                    Loan = b,
                    DvdCopy = c,
                    DvdTitle = d

                };
            return View(data);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        
    }

    public IActionResult Create()
    {
        LoadLoanType();
        LoadMemberList();
        LoadDvdCopy();
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Loan loan)
    {
        _context.Loans.Add(loan);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }








    
    
    
    // Load Loan Type
    private void LoadLoanType()
    {
        try
        {
            List<LoanType> loanTypes = new List<LoanType>();
            loanTypes = _context.LoanTypes.ToList();
            loanTypes.Insert(0, new LoanType{Id = 0, LoanTypes = "Please Select"});
            ViewBag.ListOfLoanType = loanTypes;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    
    // Load Member
    
    private void LoadMemberList()
    {
        try
        {
            List<Member> members = new List<Member>();
            members = _context.Members.ToList();
            members.Insert(0, new Member{Id = 0, MemberLastName = "Please Select"});
            ViewBag.ListOfMembers = members;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    // Load Copy Number
    
    private void LoadDvdCopy()
    {
        try
        {
            List<DvdCopy> dvdCopies = new List<DvdCopy>();
            dvdCopies = _context.DvdCopies.ToList();
            // dvdCopies.Insert(0, new DvdCopy{Id = 0, D = "Please Select"});
            ViewBag.ListOfDvdCopy = dvdCopies;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    
    // Edit Loan
    
    
    public async Task<IActionResult> Edit(int id)
    {
        LoadLoanType();
        LoadMemberList();
        LoadDvdCopy();
        var loanDetails = await _service.GetByIdAsync(id);
        if (loanDetails == null) return View("Error");
        return View(loanDetails);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id,DateOut,DateDue,DateReturned,MemberNumber,LoanTypeNumber, CopyNumber ")] Loan loan )
    {
        try
        { 
            await _service.UpdateAsync(id,loan);
            return RedirectToAction(nameof(Index));

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        LoadLoanType();
        LoadMemberList();
        LoadDvdCopy();
        var loanDetails = await _service.GetByIdAsync(id);
        if (loanDetails == null) return View("Error");
        return View(loanDetails);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        LoadLoanType();
        LoadMemberList();
        LoadDvdCopy();
        var loanDetails = await _service.GetByIdAsync(id);
        if (loanDetails == null) return View("Error");
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }



    
}