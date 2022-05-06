using GroupCoursework.DbContext;
using GroupCoursework.Models;
using GroupCoursework.Services;
using Microsoft.AspNetCore.Mvc;

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