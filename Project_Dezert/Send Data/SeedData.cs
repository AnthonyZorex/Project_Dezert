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

                if (context.Users.Any())
                {
                    return;   
                }
                if (context.Photos.Any())
                {
                    return;
                }
                context.Users.AddRange(
                   new Users
                   {
                       Login = "Admin",
                       Password = "Admin",
                       Age = 20,
                       PhoneNumber = "+420773771111",
                       Name = "Anthony",
                       Sername = "Bonetta",
                       City = "Praha",
                       Country = "Czech Republic",
                       ImageName = "220157.png"
                   }
                );
                context.SaveChanges();
            }
        }
    }
}
