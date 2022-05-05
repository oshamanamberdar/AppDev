using GroupCoursework.DbContext;
using GroupCoursework.Models;
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
    

    
}