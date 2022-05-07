using GroupCoursework.DbContext;
using GroupCoursework.Models;
using GroupCoursework.Services;
using Microsoft.AspNetCore.Mvc;
using NuGet.LibraryModel;

namespace GroupCoursework.Controllers;

public class DvdTitleController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IDvdTitleService _service;

    public DvdTitleController(ApplicationDbContext context, IDvdTitleService service)
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
    
    
    // Load  Producer

    private void LoadProducer()
    {
        try
        {
            List<Producer> producers = new List<Producer>();
            producers = _context.Producers.ToList();
            ViewBag.ListOfProducer = producers;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void LoadDvdCategory()
    {
        try
        {
            List<DvdCategory> categories = new List<DvdCategory>();
            categories = _context.DvdCategories.ToList();
            ViewBag.ListOfDvdCategories = categories;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    private void LoadStudio()
    {
        try
        {
            List<Studio> studios = new List<Studio>();
            studios = _context.Studios.ToList();
            ViewBag.ListOfStudio = studios;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    
    // Add New Dvd Title
    
    public IActionResult Create()
    {
        LoadProducer();
        LoadStudio();
        LoadDvdCategory();
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(DvdTitle dvdTitle)
    {
        _context.DvdTitles.Add(dvdTitle);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    
    
    
    public async Task<IActionResult> Edit(int id)
    {
        LoadProducer();
        LoadStudio();
        LoadDvdCategory();
        var dvdTitleDetails = await _service.GetByIdAsync(id);
        if (dvdTitleDetails == null) return View("Error");
        return View(dvdTitleDetails);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id,DateReleased,StandardCharge,PenaltyCharge,ProducerNumber,StudioNumber,CategoryNumber  ")] DvdTitle dvdTitle )
    {
        try
        { 
            await _service.UpdateAsync(id,dvdTitle);
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
        LoadProducer();
        LoadStudio();
        LoadDvdCategory();
        var dvdTitleDetails = await _service.GetByIdAsync(id);
        if (dvdTitleDetails == null) return View("Error");
        return View(dvdTitleDetails);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        LoadProducer();
        LoadStudio();
        LoadDvdCategory();
        var dvdTitleDetails = await _service.GetByIdAsync(id);
        if (dvdTitleDetails == null) return View("Error");
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
    
    
    
}