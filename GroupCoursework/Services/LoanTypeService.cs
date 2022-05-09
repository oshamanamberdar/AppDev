using GroupCoursework.Base;
using GroupCoursework.DbContext;
using GroupCoursework.Models;

namespace GroupCoursework.Services;

public class LoanTypeService : EntityBaseRepository<LoanType>, ILoanTypeService
{
    public LoanTypeService(ApplicationDbContext context) : base(context)
    {
    }
}