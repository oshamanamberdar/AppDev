using GroupCoursework.DbContext;
using GroupCoursework.Models;
using GroupCoursework.Services;
using GroupCoursework.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GroupCoursework.Controllers;

public class MemberController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IMemberService _memberService;

    public MemberController(ApplicationDbContext context, IMemberService service )
    {
        _context = context;
        _memberService = service;

    }
    // GET
    public  async Task<IActionResult> Index()
    {
        var data = await _memberService.GetAllAsync();
        return  View(data);
        
    }
    
    //Get 

    public ActionResult MemberView()
    {
        try
        {
            List<MembershipCategory> membershipCategories = _context.MembershipCategories.ToList();
            List<Member> members = _context.Members.ToList();
    
            var data = from a in membershipCategories
                join b in members on a.Id equals b.MembershipCategoryNumber into table1
                from b in table1.ToList()
                select new MemberView()
                {
                    MembershipCategory = a,
                    Member = b
    
                };
            return View(data);
    
    
    
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public IActionResult Create()
    {
        LoadMembershipCategoryList();
        return View();
        
    }

    [HttpPost]
    public async Task<IActionResult> Create(Member member)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                if (member.Id == 0)
                {
                    _context.Members.Add(member);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("Index");
            }

            return View(member);

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
            List<MembershipCategory> membershipCategories = new List<MembershipCategory>();
            membershipCategories = _context.MembershipCategories.ToList();
            membershipCategories.Insert(0, new MembershipCategory {Id = 0, MembershipCategoryDescription = "Please Select"});
            ViewBag.ListOfMembershipCategory = membershipCategories;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    
    
}