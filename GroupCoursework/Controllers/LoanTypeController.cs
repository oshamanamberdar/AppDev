using GroupCoursework.DbContext;
using GroupCoursework.Models;
using GroupCoursework.Services;
using Microsoft.AspNetCore.Mvc;

namespace GroupCoursework.Controllers;

public class LoanTypeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILoanTypeService _service;

    public LoanTypeController(ApplicationDbContext context, ILoanTypeService service)
    {
        _context = context;
        _service = service;

    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        var data = await _service.GetAllAsync();
        return  View(data);
        
        
    }
    
    // Add Loan Type
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("LoanTypes,LoanDurantion")] LoanType loanType )
    {
        
        await _service.AddAsync(loanType);
        return RedirectToAction(nameof(Index));
       
    }
    
    // Edit Loan Type
    
    public async  Task<IActionResult> Edit(int id)
    {
        var loanTypeDetails = await _service.GetByIdAsync(id);
        if (loanTypeDetails == null) return View("Error");
        return View(loanTypeDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind( "Id,LoanTypes,LoanDurantion")]LoanType loanType)
    {
        try
        {
            await _service.UpdateAsync(id,loanType);
            return RedirectToAction(nameof(Index));
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }
    
    // Delete Loan type
    
    public async Task<IActionResult> Delete(int id)
    {
        var loanTypeDetails = await _service.GetByIdAsync(id);
        if (loanTypeDetails == null) return View("Error");
        return View(loanTypeDetails);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var loanTypeDetails = await _service.GetByIdAsync(id);
        if (loanTypeDetails == null) return View("Error");

        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
    
    
}