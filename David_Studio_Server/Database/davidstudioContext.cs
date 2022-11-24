using David_Studio_Server.Database.Base;
using David_Studio_Server.Database.Models.Contact;
using David_Studio_Server.Database.Models.Path;
using David_Studio_Server.Database.Models.Project;
using David_Studio_Server.Database.Models.Service;
using David_Studio_Server.Database.Models.Translation;
using Microsoft.EntityFrameworkCore;

namespace David_Studio_Server.Database
{
    public partial class davidstudioContext : DbContext
    {
        public davidstudioContext(DbContextOptions<davidstudioContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public virtual DbSet<Models.Path.Path> Paths { get; set; } = null!;
        public virtual DbSet<Jumbotron> Jumbotrons { get; set; } = null!;

        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<ProjectImage> ProjectImages { get; set; } = null!;
        public virtual DbSet<ProjectTag> ProjectsTags { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;

        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<CircleBlock> CircleBlocks { get; set; } = null!;
        public virtual DbSet<Circle> Circles { get; set; } = null!;

        public virtual DbSet<Contact> Contacts { get; set; } = null!;

        public virtual DbSet<Language> Languages { get; set; } = null!;
        public virtual DbSet<Translation> Translations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityModelConfiguration<Identity>).Assembly);
        }
    }
}
