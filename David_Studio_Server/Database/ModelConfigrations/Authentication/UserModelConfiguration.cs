using David_Studio_Server.Database.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Authentication
{
    public class UserModelConfiguration : IdentityModelConfiguration<User>
    {
        protected override void AddBuilder(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Login).HasColumnType("VARCHAR").HasMaxLength(16);
            builder.Property(x => x.PasswordHash).HasColumnType("VARCHAR").HasMaxLength(256);
            builder.Property(x => x.Salt).HasColumnType("VARCHAR").HasMaxLength(32);

            builder.HasIndex(x => x.Login).IsUnique();
        }

        protected override string TableName()
        {
            return nameof(User) + "s";
        }
    }
}
