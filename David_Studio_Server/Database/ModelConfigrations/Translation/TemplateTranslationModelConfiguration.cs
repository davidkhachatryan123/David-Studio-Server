using David_Studio_Server.Database.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace David_Studio_Server.Database.ModelConfigrations.Translation
{
    public class TemplateTranslationModelConfiguration : IdentityModelConfiguration<Models.Translation.TemplateTranslation>
    {
        protected override void AddBuilder(EntityTypeBuilder<Models.Translation.TemplateTranslation> builder)
        {
            builder.Property(x => x.Title).HasColumnType("VARCHAR").HasMaxLength(Configuration.ShortTextLength);
            builder.Property(x => x.Description).HasColumnType("VARCHAR").HasMaxLength(Configuration.TextLength);
        }

        protected override string TableName()
        {
            return nameof(Models.Translation.TemplateTranslation) + "s";
        }
    }
}
