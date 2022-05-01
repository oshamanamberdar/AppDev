using GroupCoursework.Base;
using GroupCoursework.DbContext;
using GroupCoursework.Models;

namespace GroupCoursework.Services;

public class StudioService:  EntityBaseRepository<Studio>, IStudioService
{
    public StudioService(ApplicationDbContext context) : base(context) { }
}