using David_Studio_Server.Database.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace David_Studio_Server.Database.ModelConfigrations.Content.Uploads
{
    public class ImageModelConfiguration : IdentityModelConfiguration<Models.Content.Uploads.Image>
    {
        protected override void AddBuilder(EntityTypeBuilder<Models.Content.Uploads.Image> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(Configuration.TextLength);
            builder.Property(x => x.Url).HasMaxLength(Configuration.LongTextLength);
        }

        protected override string TableName()
        {
            return nameof(Models.Content.Uploads.Image) + "s";
        }
    }
}
