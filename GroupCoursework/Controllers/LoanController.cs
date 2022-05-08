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
        var data = await _service.GetAllAsync();
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
        int membercategoryId = 0;
        var categoryList = _context.Members.Include("MembershipCategory").Where(x =>
            x.Id == loan.MemberNumber).Select(
            x => x.MembershipCategoryNumber).ToList();
        foreach (var val in categoryList)
        {
            membercategoryId = val;
        }

        var dob = loan.Member.MemberDob;
        int age = 18;

        var loanedCopiesCount = int.Parse(_context.Loans.Include("Member").Where(
            x => x.Member.Id == loan.MemberNumber).Where(
            x => x.DateReturned == null).Count().ToString());

        var categoryLimitList = _context.Members.Include("MembershipCategory").Where(
            x => x.MembershipCategory.Id == membercategoryId).Select(
            x => x.MembershipCategory.MembershipCategoryTotalLoans).ToList();
        
        int totalLimit = 0;
        
        foreach (var val in categoryLimitList)
        {
            totalLimit = int.Parse(val.ToString());
        }

        if (loanedCopiesCount >= totalLimit)
        {
            ViewBag.Message = String.Format("Member not eligible to loan more DVD");
            LoadLoanType();
            LoadMemberList();
            LoadDvdCopy();
            return View(loan);
            
        }

        string agerestricted = "yes";

        if (age < 18 && agerestricted == "yes" )
        {
            Console.WriteLine("You a");
        }
            
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