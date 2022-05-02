using GroupCoursework.Base;
using GroupCoursework.DbContext;
using GroupCoursework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Licenses;

namespace GroupCoursework.Services;

public class MembershipCategoryService: EntityBaseRepository<MembershipCategory>, IMembershipCategoryService
{
    
    public MembershipCategoryService(ApplicationDbContext context) : base(context)
    {
      
    }

  

   



}