using GroupCoursework.DbContext;
using GroupCoursework.Models;
using GroupCoursework.Services;
using Microsoft.AspNetCore.Mvc;

namespace GroupCoursework.Controllers;

public class ProducerController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IProducerService _service;


    public ProducerController(ApplicationDbContext context, IProducerService service)
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

    // Add Producer 
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("ProducerName")] Producer producer)
    {
        await _service.AddAsync(producer);
        return RedirectToAction(nameof(Index));
    }


    // Edit Loan Type

    public async Task<IActionResult> Edit(int id)
    {
        var producerDetail = await _service.GetByIdAsync(id);
        if (producerDetail == null) return View("Error");
        return View(producerDetail);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id,ProducerName")] Producer producer)
    {
        try
        {
            await _service.UpdateAsync(id, producer);
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
        var producerDetail = await _service.GetByIdAsync(id);
        if (producerDetail == null) return View("Error");
        return View(producerDetail);
    }

    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var producerDetail = await _service.GetByIdAsync(id);
        if (producerDetail == null) return View("Error");

        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}