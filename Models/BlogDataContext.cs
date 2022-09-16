using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.Models
{
    public class BlogDataContext:DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public BlogDataContext(DbContextOptions<BlogDataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public IQueryable<MonthlySpecial> MonthlySpecials
        {
            get 
            {
                return new[]
                {
                    new MonthlySpecial
                    {
                        Key= "calm",
                        Name= "California Calm Package",
                        Type= "Day Spa Package",
                        Price= 250,
                    },
                    new MonthlySpecial
                    {
                        Key= "desert",
                        Name= "From Desert To Sea",
                        Type= "2 Day Salton Sea",
                        Price= 350,
                    },
                    new MonthlySpecial
                    {
                        Key= "backpack",
                        Name= "Backpack Cali",
                        Type= "Big Sur Retreat",
                        Price= 620,
                    },
                }.AsQueryable();
            }
            
        }
    }
}
