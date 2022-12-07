using David_Studio_Server.Database.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace David_Studio_Server.Database.ModelConfigrations.Content.Uploads
{
    public class FileModelConfiguration : IdentityModelConfiguration<Models.Content.Uploads.File>
    {
        protected override void AddBuilder(EntityTypeBuilder<Models.Content.Uploads.File> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(Configuration.TextLength);
            builder.Property(x => x.Path).HasMaxLength(Configuration.LongTextLength);
        }

        protected override string TableName()
        {
            return nameof(Models.Content.Uploads.File) + "s";
        }
    }
}
