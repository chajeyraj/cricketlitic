using Microsoft.EntityFrameworkCore;
using TutorialProject.Models;

namespace TutorialProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<social_links> social_links { get; set; }  // Added SocialLinks table
    }
}
