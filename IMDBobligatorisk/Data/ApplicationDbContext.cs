using IMDBobligatorisk.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMDBobligatorisk.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Title> Titles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Tconst as the primary key using Fluent API
            modelBuilder.Entity<Title>()
                .HasKey(t => t.Tconst);
        }
    }
}
