using Microsoft.EntityFrameworkCore;
using RestaurantApp.Models;
using System.Collections.Generic;

namespace RestaurantApp.Data
{
    public class ApplicationDbContext : DbContext
    {
       


        public ApplicationDbContext(
            DbContextOptions options) : base(options)
        {
        }

        public DbSet<Restoran> Restorani { get; set; }

        public DbSet<Jelo> Jela{ get; set; }

    }
}
