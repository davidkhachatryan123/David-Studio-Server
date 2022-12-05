using David_Studio_Server.Database.Base;
using David_Studio_Server.Database.Models.Authentication;
using David_Studio_Server.Database.Models.Content.Services;
using David_Studio_Server.Database.Models.Content.Translation;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace David_Studio_Server.Database
{
    public partial class DavidStudioContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<ServiceTranslation> ServiceTranslations  { get; set; } = null!;

        public DbSet<Translation> Translations { get; set; } = null!;
        public DbSet<Language> Languages { get; set; } = null!;

        public DavidStudioContext(DbContextOptions<DavidStudioContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityModelConfiguration<Identity>).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
