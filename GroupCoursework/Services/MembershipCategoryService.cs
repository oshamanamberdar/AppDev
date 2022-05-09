using GroupCoursework.Base;
using GroupCoursework.DbContext;
using GroupCoursework.Models;

namespace GroupCoursework.Services;

public class MembershipCategoryService : EntityBaseRepository<MembershipCategory>, IMembershipCategoryService
{
    public MembershipCategoryService(ApplicationDbContext context) : base(context)
    {
    }
}