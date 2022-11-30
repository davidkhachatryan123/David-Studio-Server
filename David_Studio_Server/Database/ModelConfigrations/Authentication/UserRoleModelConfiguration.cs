using David_Studio_Server.Database.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace David_Studio_Server.Database.Models.Authentication
{
    public class UserRoleModelConfiguration : IdentityModelConfiguration<UserRole>
    {
        protected override void AddBuilder(EntityTypeBuilder<UserRole> builder)
        {
            builder.Property(x => x.Role).HasColumnType("VARCHAR").HasMaxLength(Configuration.TinyTextLength);

            builder.HasIndex(x => x.Role).IsUnique();
        }

        protected override string TableName()
        {
            return nameof(UserRole) + "s";
        }
    }
}
