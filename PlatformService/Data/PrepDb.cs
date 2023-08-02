using PlatformService.Models;

namespace PlatformService.Data;

public static class PrepDb
{
    public static void PrepPolulation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }
    }

    private static void SeedData(AppDbContext context)
    {
        if (!context.Platforms.Any())
        {
            context.Platforms.AddRange(
                new Platform
                {
                    Name = "Dot Net",
                    Cost = "Free",
                    Publisher = "Microsoft"
                },
                new Platform
                {
                    Name = "Sql Server",
                    Cost = "A lot",
                    Publisher = "Microsoft"
                },
                new Platform
                {
                    Name = "Kubernetes",
                    Cost = "A whole lot",
                    Publisher = "Other"
                });

            context.SaveChanges();

            Console.WriteLine("Seeding data...");

            return;
        }

        Console.WriteLine("Data already inserted!");
    }
}
