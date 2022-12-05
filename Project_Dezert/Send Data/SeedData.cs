using Microsoft.EntityFrameworkCore;
using Project_Dezert.Data;
using Project_Dezert.Models;
using System.Diagnostics.Metrics;

namespace Project_Dezert.Send_Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Project_DezertContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Project_DezertContext>>()))
            {
                // Look for any movies.
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }
                context.Users.AddRange(
                   new Users
                   {
                       Login = "German",
                       Password = "German",
                       Age = 20,
                       PhoneNumber = "+420773771111",
                       Name = "German",
                       Sername = "Chaban",
                       City = "Odessa",
                       Country = "Ukraina"
                   }
                );
                context.SaveChanges();
            }
        }
    }
}
