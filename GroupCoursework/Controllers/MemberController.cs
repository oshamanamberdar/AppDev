using GroupCoursework.DbContext;
using GroupCoursework.Models;
using GroupCoursework.Services;
using Microsoft.AspNetCore.Mvc;

namespace GroupCoursework.Controllers;

public class MemberController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IMemberService _service;

    public MemberController(ApplicationDbContext context, IMemberService service)
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

    public IActionResult Create()
    {
        LoadMembershipCategoryList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [Bind("MemberFirstName,MemberLastName,MemberAddress,MemberDob,MembershipCategoryNumber ")] Member member)
    {
        try
        {
            _context.Members.Add(member);
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
        LoadMembershipCategoryList();
        var memberDetails = await _service.GetByIdAsync(id);
        if (memberDetails == null) return View("Error");
        return View(memberDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id,
        [Bind("Id,MemberFirstName,MemberLastName,MemberAddress,MemberDob,MembershipCategoryNumber ")] Member member)
    {
        try
        {
            await _service.UpdateAsync(id, member);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void LoadMembershipCategoryList()
    {
        try
        {
            var membershipCategories = new List<MembershipCategory>();
            membershipCategories = _context.MembershipCategories.ToList();
            membershipCategories.Insert(0,
                new MembershipCategory {Id = 0, MembershipCategoryDescription = "Please Select"});
            ViewBag.ListOfMembershipCategory = membershipCategories;
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
        LoadMembershipCategoryList();
        var memberDetails = await _service.GetByIdAsync(id);
        if (memberDetails == null) return View("Error");
        return View(memberDetails);
    }

    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        LoadMembershipCategoryList();
        var memberDetails = await _service.GetByIdAsync(id);
        if (memberDetails == null) return View("Error");
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}