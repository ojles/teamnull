using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;

namespace Task3.Repository
{
    class ApplicationContext : DbContext
    {
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealGroup> MealGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=ojles.pp.ua;UserId=root;Password=deadl1ne;database=sushi_ordering;");
        }
    }
}
