using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Restaurant
{
    public class AppDbContext : DbContext
    {
        public DbSet<Drink> Drinks { get; set; } = null!;
        public DbSet<Food> Foods { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder().AddJsonFile(@"C:\Users\omarm\Desktop\.Net\Restaurant\DataCenter\appsettings.json").Build();
            var connectionString = config.GetSection("constr").Value;
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
