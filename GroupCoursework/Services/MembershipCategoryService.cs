using GroupCoursework.DbContext;
using GroupCoursework.Models;
using Microsoft.EntityFrameworkCore;

namespace GroupCoursework.Services;

public class MembershipCategoryService: IMembershipCategoryService
{
    private readonly ApplicationDbContext _context;

    public MembershipCategoryService(ApplicationDbContext context)
    {
        _context = context;
    }
    public List<MembershipCategory> GetAll()
    {
        var result = _context.MembershipCategories.ToList();
        return result;
    }

    public async Task<MembershipCategory> GetByIdAsync(int id)
    {
        var result = await _context.MembershipCategories.FirstOrDefaultAsync(n => n.MembershipCategoryNumber == id);
        return result;
    }

    public async Task AddAsync(MembershipCategory membershipCategory)
    {
       await _context.MembershipCategories.AddAsync(membershipCategory);
        await _context.SaveChangesAsync();
    }

    public async Task<MembershipCategory> UpdateAsync(int id, MembershipCategory membershipCategory)
    {
        _context.Update(membershipCategory);
        await _context.SaveChangesAsync();
        return membershipCategory;
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}