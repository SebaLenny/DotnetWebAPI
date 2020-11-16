using Microsoft.EntityFrameworkCore;

namespace DotnetWebAPI.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Joke> Jokes { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql();
        }
    }
}