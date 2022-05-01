using GroupCoursework.Models;

namespace GroupCoursework.Services;

public interface IMembershipCategoryService
{
    List<MembershipCategory> GetAll();
    
    Task<MembershipCategory> GetByIdAsync(int id);

    Task AddAsync(MembershipCategory membershipCategory);

    Task<MembershipCategory> UpdateAsync(int id, MembershipCategory membershipCategory);

    void Delete(int id);

}