using GroupCoursework.Base;
using GroupCoursework.DbContext;
using GroupCoursework.Models;

namespace GroupCoursework.Services;

public class ActorService: EntityBaseRepository<Actor>, IActorService
{
    public ActorService(ApplicationDbContext context) : base(context) { }
}