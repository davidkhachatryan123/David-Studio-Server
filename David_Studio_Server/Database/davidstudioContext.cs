using David_Studio_Server.Database.Base;
using David_Studio_Server.Database.Models.Authentication;
using David_Studio_Server.Services.Authentication;
using Microsoft.EntityFrameworkCore;

namespace David_Studio_Server.Database
{
    public partial class davidstudioContext : DbContext
    {
        public davidstudioContext(DbContextOptions<davidstudioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserGroups { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityModelConfiguration<Identity>).Assembly);

            Cryptography cryptography = new Cryptography();
            string salt = cryptography.CreateSalt(16);
            string password = cryptography.HashPassword(cryptography.CombinePasswordWithSalt("admin", salt));

            UserRole admin_role = new UserRole() { Id = 1, Role = "admin" };
            User admin_user = new User()
            { 
                Id = 1,
                Login = "admin",
                PasswordHash = password,
                Salt = salt,
                UserRoleId = admin_role.Id,
            };

            modelBuilder.Entity<UserRole>().HasData(admin_role);
            modelBuilder.Entity<User>().HasData(admin_user);
        }
    }
}
