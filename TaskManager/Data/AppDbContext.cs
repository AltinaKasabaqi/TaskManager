using Microsoft.EntityFrameworkCore;
using TaskManager.Data.Entities;

namespace TaskManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<UserStory> UserStories { get; set; }

        public DbSet<Entities.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureStory(modelBuilder);
            
        }

        private void ConfigureStory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Task>()
                .HasOne(t => t.Story)
                .WithMany()
                .HasForeignKey(t => t.StoryId);
        }

       
    }

    
}
