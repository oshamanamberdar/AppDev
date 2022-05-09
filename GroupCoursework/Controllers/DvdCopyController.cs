using GroupCoursework.DbContext;
using GroupCoursework.Models;
using GroupCoursework.Services;
using Microsoft.AspNetCore.Mvc;

namespace GroupCoursework.Controllers;

public class DvdCopyController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IDvdCopyService _service;

    public DvdCopyController(ApplicationDbContext context, IDvdCopyService service)
    {
        _context = context;
        _service = service;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var data = await _service.GetAllAsync();
        return View(data);
    }

    // Save Dvd Copy

    public IActionResult Create()
    {
        LoadDvdTitleList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("DatePurchased, DvdNumber")] DvdCopy dvdCopy)
    {
        try
        {
            _context.DvdCopies.Add(dvdCopy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<IActionResult> Edit(int id)
    {
        LoadDvdTitleList();
        var dvdCopyDetails = await _service.GetByIdAsync(id);
        if (dvdCopyDetails == null) return View("Error");
        return View(dvdCopyDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id, DatePurchased, DvdNumber ")] DvdCopy dvdCopy)
    {
        try
        {
            await _service.UpdateAsync(id, dvdCopy);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void LoadDvdTitleList()
    {
        try
        {
            var dvdTitles = new List<DvdTitle>();
            dvdTitles = _context.DvdTitles.ToList();
            dvdTitles.Insert(0, new DvdTitle {Id = 0, StandardCharge = 0});
            ViewBag.ListOfDvdTitle = dvdTitles;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IActionResult> Delete(int id)
    {
        LoadDvdTitleList();
        var dvdCopyDetails = await _service.GetByIdAsync(id);
        if (dvdCopyDetails == null) return View("Error");
        return View(dvdCopyDetails);
    }

    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        LoadDvdTitleList();
        var dvdCopyDetails = await _service.GetByIdAsync(id);
        if (dvdCopyDetails == null) return View("Error");
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}