using Microsoft.EntityFrameworkCore;
using TutorialProject.Models;

namespace TutorialProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Configurations for the model, if needed
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // You can configure additional things here if needed
            // For example:
            // builder.Entity<social_links>().HasKey(x => x.Id);
        }

        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<social_links> social_links { get; set; }  // Corrected naming to PascalCase
    }
}
