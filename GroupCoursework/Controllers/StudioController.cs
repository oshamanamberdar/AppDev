using GroupCoursework.DbContext;
using GroupCoursework.Models;
using GroupCoursework.Services;
using Microsoft.AspNetCore.Mvc;

namespace GroupCoursework.Controllers;

public class StudioController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IStudioService _service;

    public StudioController(ApplicationDbContext context, IStudioService service)
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
    
    // Add Producer 
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("StudioName")] Studio studio )
    {
        
        await _service.AddAsync(studio);
        return RedirectToAction(nameof(Index));
       
    }
    
    
    // Edit Loan Type
    
    public async  Task<IActionResult> Edit(int id)
    {
        var studioDetail = await _service.GetByIdAsync(id);
        if (studioDetail == null) return View("Error");
        return View(studioDetail);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind( "Id,StudioName")]Studio studio)
    {
        try
        {
            await _service.UpdateAsync(id,studio);
            return RedirectToAction(nameof(Index));
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }

    // Delete Producer 

    public async Task<IActionResult> Delete(int id)
    {
        var studioDetail = await _service.GetByIdAsync(id);
        if (studioDetail == null) return View("Error");
        return View(studioDetail);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var studioDetail = await _service.GetByIdAsync(id);
        if (studioDetail == null) return View("Error");

        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}