using GroupCoursework.DbContext;
using GroupCoursework.Models;
using GroupCoursework.Services;
using Microsoft.AspNetCore.Mvc;

namespace GroupCoursework.Controllers;

public class MembershipCategoryController : Controller
{
    private readonly IMembershipCategoryService _service;

    public MembershipCategoryController(IMembershipCategoryService service)
    {
        _service = service;
    }

   
    // GET
    public IActionResult Index()
    {
        var data = _service.GetAllAsync();
        return  View(null);
    }
    //Get: MembershipCategory/Create

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind( "MembershipCategoryTotalLoans", "MembershipCategoryDescription")]MembershipCategory membershipCategory)
    {
        if (ModelState.IsValid)
        {
            await _service.AddAsync(membershipCategory);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return View("Error");
        }

    }
    
    //Get: MembershipCategory/Details/1

    public async Task<IActionResult> Details(int id)
    {
        var membershipCategoryDetails = await _service.GetByIdAsync(id);
        return View(membershipCategoryDetails);
        
      
    }
    
    public async  Task<IActionResult> Edit(int id)
    {
        var membershipCategoryDetails = await _service.GetByIdAsync(id);
        return View(membershipCategoryDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind( "MembershipCategoryNumber","MembershipCategoryTotalLoans", "MembershipCategoryDescription")]MembershipCategory membershipCategory)
    {
        await _service.UpdateAsync(id, membershipCategory);
        return RedirectToAction(nameof(Index));
    }
    
    
}