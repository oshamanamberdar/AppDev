using GroupCoursework.Base;
using GroupCoursework.DbContext;
using GroupCoursework.Models;

namespace GroupCoursework.Services;

public class DvdCategoryService : EntityBaseRepository<DvdCategory>, IDvdCategoryService
{
    public DvdCategoryService(ApplicationDbContext context) : base(context)
    {
    }
}