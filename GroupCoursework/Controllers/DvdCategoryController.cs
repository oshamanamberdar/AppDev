using GroupCoursework.DbContext;
using GroupCoursework.Models;
using GroupCoursework.Services;
using Microsoft.AspNetCore.Mvc;

namespace GroupCoursework.Controllers;

public class DvdCategoryController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IDvdCategoryService _service;

    public DvdCategoryController(ApplicationDbContext context, IDvdCategoryService service)
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
    
    // Add DVD Category
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("DvdCategoryName,CategoryDescription,AgeRestricted")] DvdCategory dvdCategory )
    {
        
        await _service.AddAsync(dvdCategory);
        return RedirectToAction(nameof(Index));
       
    }
    
    // Edit Dvd Category
    
    public async  Task<IActionResult> Edit(int id)
    {
        var categoryDetails = await _service.GetByIdAsync(id);
        if (categoryDetails == null) return View("Error");
        return View(categoryDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind( "Id,DvdCategoryName,CategoryDescription,AgeRestricted")]DvdCategory dvdCategory)
    {
        try
        {
            await _service.UpdateAsync(id,dvdCategory);
            return RedirectToAction(nameof(Index));
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }
    
    // Delete DVD Category
    
    public async Task<IActionResult> Delete(int id)
    {
        var categoryDetails = await _service.GetByIdAsync(id);
        if (categoryDetails == null) return View("Error");
        return View(categoryDetails);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var categoryDetails = await _service.GetByIdAsync(id);
        if (categoryDetails == null) return View("Error");

        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}