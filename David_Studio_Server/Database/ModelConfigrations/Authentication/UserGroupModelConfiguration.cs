using David_Studio_Server.Database.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace David_Studio_Server.Database.Models.Authentication
{
    public class UserGroupModelConfiguration : IdentityModelConfiguration<UserGroup>
    {
        protected override void AddBuilder(EntityTypeBuilder<UserGroup> builder)
        {
            builder.Property(x => x.Role).HasColumnType("VARCHAR").HasMaxLength(Configuration.TinyTextLength);
        }

        protected override string TableName()
        {
            return nameof(UserGroup) + "s";
        }
    }
}
