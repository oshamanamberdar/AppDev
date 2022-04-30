using GroupCoursework.Models;

namespace GroupCoursework.DbContext;

public class AppDbInitializer
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            
            //Actor
            if (!context.Actors.Any())
            {
                context.Actors.AddRange(new List<Actor>()
                {
                    new Actor()
                    {
                        ActorSurname = "Namberdar",
                        ActorFirstName = "Oshama"
                    }
                    
                });
                context.SaveChanges();

            }
            

        }
    }
}