using GroupCoursework.DbContext;
using GroupCoursework.Models;
using GroupCoursework.Services;
using GroupCoursework.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;

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

    // public IActionResult Data()
    // {
    //     var data = from a in _context.Members
    //                                 select a.MemberDob;
    //     var data1 = Convert.ToDateTime(data);
    //     int age = 0;  
    //     age = DateTime.Now.Subtract(data1).Days;  
    //     age = age / 365;
    //
    //     List<DvdCategory> dvdCategories = _context.DvdCategories.ToList();
    //     List<DvdTitle> dvdTitles  = _context.DvdTitles.ToList();
    //     List<Member> members = _context.Members.ToList();
    //     List<DvdCopy> dvdCopies = _context.DvdCopies.ToList();
    //     List<Loan> loans = _context.Loans.ToList();
    //     var data3 = from a in members
    //         join b in loans on a.Id equals b.MemberNumber into Table1
    //         from b in Table1.ToList()
    //         join c in dvdCopies on b.CopyNumber equals c.Id into Table2
    //         from c in Table2.ToList()
    //         join d in dvdTitles on c.DvdNumber equals d.Id into Table3
    //         from d in Table3.ToList()
    //         select new TestView()
    //         {
    //             Member = a,
    //             Loan = b,
    //             DvdCopy = c,
    //             DvdTitle = d,
    //
    //
    //         };
    //     return View(data);
    //
    //
    //
    //
    //
    // }

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