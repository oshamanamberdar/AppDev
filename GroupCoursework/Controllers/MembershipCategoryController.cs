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
    public  async Task<IActionResult> Index()
    {
        var data = await _service.GetAllAsync();
        return  View(data);
    }
    //Get: MembershipCategory/Create

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("MembershipCategoryTotalLoans,MembershipCategoryDescription")]MembershipCategory membershipCategory)
    {
        if (!ModelState.IsValid)
        {
            await _service.AddAsync(membershipCategory);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return View(membershipCategory);
        }
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
    public async Task<IActionResult> Edit(int id, [Bind( "MembershipCategoryNumber,MembershipCategoryTotalLoans", "MembershipCategoryDescription")]MembershipCategory membershipCategory)
    {
        if (!ModelState.IsValid)
        {
            return View(membershipCategory);
        }
        else
        {
            await _service.UpdateAsync(id,membershipCategory);
            return RedirectToAction(nameof(Index));
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
    
    
}