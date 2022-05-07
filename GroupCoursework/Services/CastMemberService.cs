using GroupCoursework.Base;
using GroupCoursework.DbContext;
using GroupCoursework.Models;

namespace GroupCoursework.Services;

public class CastMemberService: EntityBaseRepository<CastMember>, ICastMemberService
{
    public CastMemberService(ApplicationDbContext context) : base(context) { }
}