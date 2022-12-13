using Microsoft.EntityFrameworkCore;
using TaskWebApi.Models;

namespace TaskWebApi.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> option) : base(option)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Task>()
                .Property(c => c.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Project>()
                .Property(s => s.Status)
                .HasConversion<string>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
