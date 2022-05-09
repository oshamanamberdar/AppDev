using GroupCoursework.DbContext;
using GroupCoursework.Models;
using GroupCoursework.Services;
using GroupCoursework.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GroupCoursework.Controllers;

public class CastMemberController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ICastMemberService _service;

    public CastMemberController(ApplicationDbContext context, ICastMemberService service)
    {
        _context = context;
        _service = service;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        // var data = await _service.GetAllAsync();
        // return  View(data);
        var actors = _context.Actors.ToList();
        var dvdTitles = _context.DvdTitles.ToList();
        var castMembers = _context.CastMembers.ToList();
        var data = from a in actors
            join b in castMembers on a.Id equals b.ActorId into table1
            from b in table1.ToList()
            join c in dvdTitles on b.DvdId equals c.Id into table2
            from c in table2.ToList()
            select new TestView
            {
                Actor = a,
                DvdTitle = c,
                CastMember = b
            };
        return View(data);
    }

    public IActionResult Create()
    {
        LoadDvdDetails();
        LoadActor();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("ActorId,DvdId")] CastMember castMember)
    {
        try
        {
            _context.CastMembers.Add(castMember);
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
        LoadDvdDetails();
        LoadActor();
        var castMemberDetails = await _service.GetByIdAsync(id);
        if (castMemberDetails == null) return View("Error");
        return View(castMemberDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id, ActorId,DvdId")] CastMember castMember)
    {
        try
        {
            await _service.UpdateAsync(id, castMember);
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
        LoadDvdDetails();
        LoadActor();
        var castMemberDetails = await _service.GetByIdAsync(id);
        if (castMemberDetails == null) return View("Error");
        return View(castMemberDetails);
    }

    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        LoadDvdDetails();
        LoadActor();
        var castMemberDetails = await _service.GetByIdAsync(id);
        if (castMemberDetails == null) return View("Error");
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }


    private void LoadActor()
    {
        try
        {
            var actors = new List<Actor>();
            actors = _context.Actors.ToList();
            ViewBag.ListOfActors = actors;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void LoadDvdDetails()
    {
        try
        {
            var dvdTitles = new List<DvdTitle>();
            dvdTitles = _context.DvdTitles.ToList();
            ViewBag.ListOfDvdTitle = dvdTitles;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}