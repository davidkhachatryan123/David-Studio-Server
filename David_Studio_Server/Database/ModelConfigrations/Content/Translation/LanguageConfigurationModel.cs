using David_Studio_Server.Database.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace David_Studio_Server.Database.ModelConfigrations.Content.Translation
{
    public class LanguageConfigurationModel : IdentityModelConfiguration<Models.Content.Translation.Language>
    {
        protected override void AddBuilder(EntityTypeBuilder<Models.Content.Translation.Language> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(Configuration.ShortTextLength);
            builder.Property(x => x.Culture).HasMaxLength(Configuration.TinyTextLength);
        }

        protected override string TableName()
        {
            return nameof(Models.Content.Translation.Language) + "s";
        }
    }
}
