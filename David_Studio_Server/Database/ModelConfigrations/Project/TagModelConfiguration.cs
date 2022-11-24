using David_Studio_Server.Database.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace David_Studio_Server.Database.ModelConfigrations.Project
{
    public class TagModelConfiguration : IdentityModelConfiguration<Models.Project.Tag>
    {
        protected override void AddBuilder(EntityTypeBuilder<Models.Project.Tag> builder)
        {
            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(Configuration.TinyTextLength);
            builder.Property(x => x.LongName).HasColumnType("VARCHAR").HasMaxLength(Configuration.ShortTextLength);
        }

        protected override string TableName()
        {
            return nameof(Models.Project.Tag) + "s";
        }
    }
}
