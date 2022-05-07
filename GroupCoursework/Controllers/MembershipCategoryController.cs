using GroupCoursework.DbContext;
using GroupCoursework.Models;
using GroupCoursework.Services;
using GroupCoursework.ViewModel;
using Microsoft.AspNetCore.Mvc;
using PagedList;
namespace GroupCoursework.Controllers;

public class MembershipCategoryController : Controller
{
    private readonly IMembershipCategoryService _service;
    private readonly ApplicationDbContext _context;

    public MembershipCategoryController(IMembershipCategoryService service, ApplicationDbContext context)
    {
        _service = service;
        _context = context;
    }

   
    // GET
    public  async Task<IActionResult> Index()
    {
        var data = await _service.GetAllAsync();
        return  View(data);
        
        
    }

  

    public IActionResult Filter(string searchString)
    {
        List<Actor> actors = _context.Actors.ToList();
        List<DvdCategory> dvdCategories = _context.DvdCategories.ToList();
        List<DvdTitle> dvdTitles  = _context.DvdTitles.ToList();
        List<Producer> producers  = _context.Producers.ToList();
        List<CastMember> castMembers = _context.CastMembers.ToList();
        var data = from a in actors 
            join b in castMembers on a.Id equals b.ActorId into table1
            from b in table1.ToList()
            join c in dvdTitles on b.DvdId equals c.Id
            join f in producers on c.ProducerNumber equals f.Id into table2
            from f in table2.ToList()
            join d in dvdCategories on c.CategoryNumber equals d.Id into table3
            from d in table3.ToList()

            select new TestView()
            {
                Actor = a,
                DvdTitle = c,
                Producer = f,
                DvdCategory = d
            };
        if (!string.IsNullOrEmpty(searchString))
        {
            var filteredResultNew = data.Where(n => string.Equals(n.Actor.ActorSurname, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Actor.ActorFirstName, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
            return View("List", filteredResultNew);
        }

        return View("List", data);


    }

    
    //Get: MembershipCategory/Create

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("CategoryName, MembershipCategoryTotalLoans,MembershipCategoryDescription")]MembershipCategory membershipCategory)
    {
        
            await _service.AddAsync(membershipCategory);
            return RedirectToAction(nameof(Index));
       
    }
    
    //Get: MembershipCategory/Details/id

    public async Task<IActionResult> Details(int id)
    {
        var membershipCategoryDetails = await _service.GetByIdAsync(id);
        if (membershipCategoryDetails == null) return View("Error");
        return View(membershipCategoryDetails);
        
      
    }
    
    
    
    //Get: MembershipCategory/Edit/id
    public async  Task<IActionResult> Edit(int id)
    {
        var membershipCategoryDetails = await _service.GetByIdAsync(id);
        if (membershipCategoryDetails == null) return View("Error");
        return View(membershipCategoryDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind( "Id,CategoryName,MembershipCategoryDescription,MembershipCategoryTotalLoans")]MembershipCategory membershipCategory)
    {
        try
        {
            await _service.UpdateAsync(id,membershipCategory);
                return RedirectToAction(nameof(Index));
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }
    
    //Get: MembershipCategory/Delete/id
    public async Task<IActionResult> Delete(int id)
    {
        var membershipCategoryDetails = await _service.GetByIdAsync(id);
        if (membershipCategoryDetails == null) return View("Error");
        return View(membershipCategoryDetails);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var membershipCategoryDetails = await _service.GetByIdAsync(id);
        if (membershipCategoryDetails == null) return View("Error");

        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpPost]
    public string List(string searchString, bool notUsed)
    {
        return "From [HttpPost]List: filter on " + searchString;
    }
    
    
    
}