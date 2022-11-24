using David_Studio_Server.Database.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace David_Studio_Server.Database.ModelConfigrations.Path
{
    public class PathModelConfiguration : IdentityModelConfiguration<Models.Path.Path>
    {
        protected override void AddBuilder(EntityTypeBuilder<Models.Path.Path> builder)
        {
            builder.Property(x => x.Value).HasColumnType("VARCHAR").HasMaxLength(Configuration.TextLength);
        }

        protected override string TableName()
        {
            return nameof(Models.Path.Path) + "s";
        }
    }
}
