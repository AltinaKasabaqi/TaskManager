using Microsoft.EntityFrameworkCore;
using TaskManager.Data.Entities;

namespace TaskManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<List> Lists { get; set; }

        public DbSet<Entities.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureList(modelBuilder);
            
        }

        private void ConfigureList(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Task>()
                .HasOne(t => t.list)
                .WithMany()
                .HasForeignKey(t => t.ListID);
        }
    }

    
}
