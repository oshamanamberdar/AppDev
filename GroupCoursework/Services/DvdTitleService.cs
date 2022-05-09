using GroupCoursework.Base;
using GroupCoursework.DbContext;
using GroupCoursework.Models;

namespace GroupCoursework.Services;

public class DvdTitleService : EntityBaseRepository<DvdTitle>, IDvdTitleService
{
    public DvdTitleService(ApplicationDbContext context) : base(context)
    {
    }
}