using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rajwinder_shopping_centre.Models;

namespace Rajwinder_shopping_centre.Data
{
    public class Rajwinder_shopping_centreDatabase : DbContext
    {
        public Rajwinder_shopping_centreDatabase (DbContextOptions<Rajwinder_shopping_centreDatabase> options)
            : base(options)
        {
        }

        public DbSet<Rajwinder_shopping_centre.Models.Brand> Brand { get; set; }

        public DbSet<Rajwinder_shopping_centre.Models.Category> Category { get; set; }

        public DbSet<Rajwinder_shopping_centre.Models.Order> Order { get; set; }

        public DbSet<Rajwinder_shopping_centre.Models.Product> Product { get; set; }

        public DbSet<Rajwinder_shopping_centre.Models.Signup> Signup { get; set; }
    }
}
