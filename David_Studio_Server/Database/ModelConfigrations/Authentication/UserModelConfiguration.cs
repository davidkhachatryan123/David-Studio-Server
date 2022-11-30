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
            builder.Property(x => x.Password).HasColumnType("VARCHAR").HasMaxLength(512);
            builder.Property(x => x.Password).HasColumnType("VARCHAR").HasMaxLength(16);
        }

        protected override string TableName()
        {
            return nameof(User) + "s";
        }
    }
}
