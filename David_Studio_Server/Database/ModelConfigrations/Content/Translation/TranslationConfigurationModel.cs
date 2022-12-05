using David_Studio_Server.Database.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using David_Studio_Server.Database.Models.Content.Translation;

namespace David_Studio_Server.Database.ModelConfigrations.Content.Translation
{
    public class TranslationConfigurationModel : IdentityModelConfiguration<Models.Content.Translation.Translation>
    {
        protected override void AddBuilder(EntityTypeBuilder<Models.Content.Translation.Translation> builder)
        {
            builder.HasMany(x => x.ServiceTitleTranslations)
                .WithOne(x => x.TitleTranslation)
                .HasForeignKey(x => x.TitleTranslationId);

            builder.HasMany(x => x.ServiceDescriptionTranslations)
                .WithOne(x => x.DescriptionTranslation)
                .HasForeignKey(x => x.DescriptionTranslationId);

            builder.Property(x => x.Text).HasMaxLength(Configuration.LongTextLength);
        }

        protected override string TableName()
        {
            return nameof(Models.Content.Translation.Translation) + "s";
        }
    }
}
