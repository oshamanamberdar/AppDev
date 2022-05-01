using GroupCoursework.Base;
using GroupCoursework.DbContext;
using GroupCoursework.Models;
using Microsoft.EntityFrameworkCore;

namespace GroupCoursework.Services;

public class MembershipCategoryService: EntityBaseRepository<MembershipCategory>, IMembershipCategoryService
{
    public MembershipCategoryService(ApplicationDbContext context) : base(context)
    {
    }

    public List<MembershipCategory> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<MembershipCategory> UpdateAsync(int id, MembershipCategory membershipCategory)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}