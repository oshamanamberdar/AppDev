using GroupCoursework.Base;
using GroupCoursework.DbContext;
using GroupCoursework.Models;

namespace GroupCoursework.Services;

public class DvdCopyService: EntityBaseRepository<DvdCopy>, IDvdCopyService
{
    public DvdCopyService(ApplicationDbContext context) : base(context) { }
}