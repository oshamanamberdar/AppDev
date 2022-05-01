using GroupCoursework.Base;
using GroupCoursework.DbContext;
using GroupCoursework.Models;

namespace GroupCoursework.Services;

public class LoanService: EntityBaseRepository<Loan>, ILoanService
{
    public LoanService(ApplicationDbContext context) : base(context) { }
}