using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_Dezert.Models;

namespace Project_Dezert.Data
{
    public class Project_DezertContext : DbContext
    {
        public Project_DezertContext (DbContextOptions<Project_DezertContext> options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Project_Dezert.Models.Friends> Friends { get; set; } = default!;

    }
}
