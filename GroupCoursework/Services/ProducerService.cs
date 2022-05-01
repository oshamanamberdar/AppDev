using GroupCoursework.Base;
using GroupCoursework.DbContext;
using GroupCoursework.Models;

namespace GroupCoursework.Services;

public class ProducerService:  EntityBaseRepository<Producer>, IProducerService
{
    public ProducerService(ApplicationDbContext context) : base(context) { }
}