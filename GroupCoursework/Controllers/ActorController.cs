using GroupCoursework.DbContext;
using GroupCoursework.Models;
using GroupCoursework.Services;
using Microsoft.AspNetCore.Mvc;

namespace GroupCoursework.Controllers;

public class ActorController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IActorService _service;

    public ActorController(ApplicationDbContext context, IActorService service)
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
    public async Task<IActionResult> Create([Bind("ActorFirstName,ActorSurname")] Actor actor )
    {
        
        await _service.AddAsync(actor);
        return RedirectToAction(nameof(Index));
       
    }
    
    // Edit Loan Type
    
    public async  Task<IActionResult> Edit(int id)
    {
        var actorDetails = await _service.GetByIdAsync(id);
        if (actorDetails == null) return View("Error");
        return View(actorDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind( "Id,ActorSurname,ActorFirstName")]Actor actor)
    {
        try
        {
            await _service.UpdateAsync(id,actor);
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
        var actorDetails = await _service.GetByIdAsync(id);
        if (actorDetails == null) return View("Error");
        return View(actorDetails);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var actorDetails = await _service.GetByIdAsync(id);
        if (actorDetails == null) return View("Error");

        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }


}