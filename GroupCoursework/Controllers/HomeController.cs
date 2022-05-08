using System.Diagnostics;
using GroupCoursework.DbContext;
using Microsoft.AspNetCore.Mvc;
using GroupCoursework.Models;
using GroupCoursework.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace GroupCoursework.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    public ActionResult Index()
    {
        try
        {
            List<Actor> actors = _context.Actors.ToList();
            List<DvdCategory> dvdCategories = _context.DvdCategories.ToList();
            List<DvdTitle> dvdTitles = _context.DvdTitles.ToList();
            List<Producer> producers = _context.Producers.ToList();
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


            return View(data);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }


    }

    public ActionResult FilterByAlphabeticalOrder()
    {
        try
        {
            List<Actor> actors = _context.Actors.ToList();
            List<DvdCategory> dvdCategories = _context.DvdCategories.ToList();
            List<DvdTitle> dvdTitles = _context.DvdTitles.ToList();
            List<Producer> producers = _context.Producers.ToList();
            List<CastMember> castMembers = _context.CastMembers.ToList();
            List<Studio> studios = _context.Studios.ToList();
            var data = from a in actors orderby a.ActorSurname ascending 
                join b in castMembers on a.Id equals b.ActorId into table1
                from b in table1.ToList()
                join c in dvdTitles on b.DvdId equals c.Id   
                join f in producers on c.ProducerNumber equals f.Id into table2
                from f in table2.ToList()
                join d in dvdCategories on c.CategoryNumber equals d.Id into table3
                from d in table3.ToList()
                join e in studios on c.StudioNumber equals e.Id into table4
                from e in table4.ToList() 
                

                select new TestView()
                {
                    Actor = a,
                    DvdTitle = c,
                    Producer = f,
                    DvdCategory = d,
                    Studio = e
                    
                };


            return View(data);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }

    public ActionResult Filter(string searchString)
    {
        try
        {
            
            List<Actor> actors = _context.Actors.ToList();
            List<DvdCategory> dvdCategories = _context.DvdCategories.ToList();
            List<DvdTitle> dvdTitles = _context.DvdTitles.ToList();
            List<Producer> producers = _context.Producers.ToList();
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
                    data = data.Where(n =>
                        string.Equals(n.Actor.ActorSurname, searchString, StringComparison.CurrentCultureIgnoreCase));
                }


            return View(data);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }


    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }

    public ActionResult SortData()
    {
        try
        {
            List<Actor> actors = _context.Actors.ToList();
            List<DvdCategory> dvdCategories = _context.DvdCategories.ToList();
            List<DvdTitle> dvdTitles = _context.DvdTitles.ToList();
            List<Producer> producers = _context.Producers.ToList();
            List<CastMember> castMembers = _context.CastMembers.ToList();
            List<Studio> studios = _context.Studios.ToList();
            var data = from a in actors 
                join b in castMembers on a.Id equals b.ActorId into table1
                from b in table1.ToList()
                join c in dvdTitles on b.DvdId equals c.Id orderby c.DateReleased ascending 
                join f in producers on c.ProducerNumber equals f.Id into table2
                from f in table2.ToList()
                join d in dvdCategories on c.CategoryNumber equals d.Id into table3
                from d in table3.ToList()
                join e in studios on c.StudioNumber equals e.Id into table4
                from e in table4.ToList() 
                

                select new TestView()
                {
                    Actor = a,
                    DvdTitle = c,
                    Producer = f,
                    DvdCategory = d,
                    Studio = e
                    
                };


            return View(data);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public ActionResult ShowDvdTitleNotLoaned()
    {
        try
        {
            List<DvdTitle> dvdTitles = _context.DvdTitles.ToList();
           List<Loan> loans = _context.Loans.ToList();
            List<DvdCopy> dvdCopies = _context.DvdCopies.ToList();
            var data = from a in loans
                join b in dvdCopies on a.LoanTypeNumber equals b.Id into table1
                from b in table1.ToList()
                join c in dvdTitles on b.DvdNumber equals c.Id into table2
                from c in table2.ToList()
                select new TestView()
                {
                    Loan = a,
                    DvdCopy = b,
                    DvdTitle = c
                };


            return View(data);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public ActionResult ViewMemberByMemberLastName(string searchString)
    {
        try
        {
            List<DvdTitle> dvdTitles = _context.DvdTitles.ToList();
            List<Member> members = _context.Members.ToList();
            List<Loan> loans = _context.Loans.ToList();
            List<DvdCopy> dvdCopies = _context.DvdCopies.ToList();
            var data = from a in members
                join b in loans on a.Id equals b.MemberNumber into table1
                from b in table1.ToList()
                join c in dvdCopies on b.CopyNumber equals c.Id into table2
                from c in table2.ToList()
                join d in dvdTitles on c.DvdNumber equals d.Id into table3
                from d in table3.ToList()
                
                

                select new TestView()
                {
                   Member = a,
                   Loan = b,
                   DvdCopy = c,
                   DvdTitle = d
                    
                };
            
            if (!string.IsNullOrEmpty(searchString))
            {
                data = data.Where(n =>
                    string.Equals(n.Member.MemberLastName, searchString, StringComparison.CurrentCultureIgnoreCase));
            }
            
            return View(data);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }
    
    
    public ActionResult SearchByCopyNumber(int copyNumber)
    {
        try
        {
            List<DvdTitle> dvdTitles = _context.DvdTitles.ToList();
            List<Member> members = _context.Members.ToList();
            List<Loan> loans = _context.Loans.ToList();
            List<DvdCopy> dvdCopies = _context.DvdCopies.ToList();
            var data = from a in members
                join b in loans on a.Id equals b.MemberNumber into table1
                from b in table1.ToList()
                join c in dvdCopies on b.CopyNumber equals c.Id into table2
                from c in table2.ToList()
                join d in dvdTitles on c.DvdNumber equals d.Id into table3
                from d in table3.ToList()
                
                select new TestView()
                {
                    Member = a,
                    Loan = b,
                    DvdCopy = c,
                    DvdTitle = d
                    
                };

            if (copyNumber != null)
            {
                data = data.Where(n =>
                    string.Equals(n.DvdCopy.Id, copyNumber));
            }
            return View(data);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }
    
    public ActionResult SearchMemberWithNoCurrentLoans()
    {
        try
        {
            List<DvdTitle> dvdTitles = _context.DvdTitles.ToList();
            List<Member> members = _context.Members.ToList();
            List<Loan> loans = _context.Loans.ToList();
            List<DvdCopy> dvdCopies = _context.DvdCopies.ToList();
            List<MembershipCategory> membershipCategories = _context.MembershipCategories.ToList();
            var data = from a in members orderby a.MemberFirstName ascending 
                join e in membershipCategories on a.MembershipCategoryNumber equals e.Id
                join b in loans on a.Id equals b.MemberNumber into table1
                from b in table1.ToList() 
                join c in dvdCopies on b.CopyNumber equals c.Id into table2
                from c in table2.ToList()
                join d in dvdTitles on c.DvdNumber equals d.Id into table3
                from d in table3.ToList()

                select new TestView()
                {
                    Member = a,
                    Loan = b,
                    DvdCopy = c,
                    DvdTitle = d,
                    MembershipCategory = e
                    
                };

            return View(data);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }
    
    public ActionResult ListOfAllDvdsExpiredCopy()
    {
        try
        {
            DateTime temp = DateTime.Now.AddYears(-1).AddDays(90);
            List<DvdTitle> dvdTitles = _context.DvdTitles.ToList();
            List<Member> members = _context.Members.ToList();
            List<Loan> loans = _context.Loans.ToList();
            List<DvdCopy> dvdCopies = _context.DvdCopies.ToList(); 
            List<MembershipCategory> membershipCategories = _context.MembershipCategories.ToList();
            var data = from a in dvdCopies
                join b in dvdTitles on a.DvdNumber equals b.Id into Table1
                from b in Table1.ToList()  where a.DatePurchased <= temp

                select new TestView()
                {
                    DvdTitle = b,
                    DvdCopy = a
                    
                };

            return View(data);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }
    
    
    // Task 11
    public ActionResult DvdCopyOnLoan()
    {
        try
        {
            List<DvdTitle> dvdTitles = _context.DvdTitles.ToList();
            List<Member> members = _context.Members.ToList();
            List<Loan> loans = _context.Loans.ToList();
            List<DvdCopy> dvdCopies = _context.DvdCopies.ToList();
            List<MembershipCategory> membershipCategories = _context.MembershipCategories.ToList();
            var data = from a in members orderby a.MemberFirstName ascending 
                join e in membershipCategories on a.MembershipCategoryNumber equals e.Id
                join b in loans on a.Id equals b.MemberNumber into table1
                from b in table1.ToList() where b.DateReturned == null
                join c in dvdCopies on b.CopyNumber equals c.Id into table2
                from c in table2.ToList()
                join d in dvdTitles on c.DvdNumber equals d.Id into table3
                from d in table3.ToList()

                select new TestView()
                {
                    Member = a,
                    Loan = b,
                    DvdCopy = c,
                    DvdTitle = d,
                    MembershipCategory = e
                    
                };

            return View(data);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }
    
    // Task 12
    public ActionResult LoanNotRaisedByMemberInPresentMonth()
    {
        try
        {
            DateTime temp = DateTime.Now.AddDays(-31);
            List<DvdTitle> dvdTitles = _context.DvdTitles.ToList();
            List<Member> members = _context.Members.ToList();
            List<Loan> loans = _context.Loans.ToList();
            List<DvdCopy> dvdCopies = _context.DvdCopies.ToList();
            List<MembershipCategory> membershipCategories = _context.MembershipCategories.ToList();
            var data = from a in members 
                join e in membershipCategories on a.MembershipCategoryNumber equals e.Id
                join b in loans on a.Id equals b.MemberNumber into table1
                from b in table1.ToList() orderby b.DateOut ascending where b.DateOut < temp
                join c in dvdCopies on b.CopyNumber equals c.Id into table2
                from c in table2.ToList()
                join d in dvdTitles on c.DvdNumber equals d.Id into table3
                from d in table3.ToList()

                select new TestView()
                {
                    Member = a,
                    Loan = b,
                    DvdCopy = c,
                    DvdTitle = d,
                    MembershipCategory = e
                    
                };

            return View(data);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        
       
    }
    
    public ActionResult DvdTitleNotListedOnLoanForInPresentMonth()
    {
        try
        {
            DateTime temp = DateTime.Now.AddDays(-31);
            List<DvdTitle> dvdTitles = _context.DvdTitles.ToList();
            List<Loan> loans = _context.Loans.ToList();
            List<DvdCopy> dvdCopies = _context.DvdCopies.ToList();
            var data = from a in dvdTitles
                join b in dvdCopies on a.Id equals b.DvdNumber into Table1
                from b in Table1.ToList()
                join c in loans on b.Id equals c.CopyNumber into Table2
                from c in Table2.ToList() where c.DateOut <= temp
                select new TestView()
                {
                   DvdTitle = a,
                   DvdCopy = b,
                   Loan = c
                    
                };

            return View(data);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        
       
    }
    
    
    
    

    
    
    
}
