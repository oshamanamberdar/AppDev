using GroupCoursework.Base;
using GroupCoursework.DbContext;
using GroupCoursework.Models;

namespace GroupCoursework.Services;

public class MemberService : EntityBaseRepository<Member>, IMemberService
{
    public MemberService(ApplicationDbContext context) : base(context)
    {
    }
}