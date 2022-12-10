using David_Studio_Server.Database.Base;
using David_Studio_Server.Database.Models.Content.Translation;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace David_Studio_Server.Database.ModelConfigrations.Content.Translation
{
    public class LanguageConfigurationModel : IdentityModelConfiguration<Models.Content.Translation.Language>
    {
        protected override void AddBuilder(EntityTypeBuilder<Models.Content.Translation.Language> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(Configuration.ShortTextLength);
            builder.Property(x => x.Culture).HasMaxLength(Configuration.TinyTextLength);

            Language en_US = new() { Id = 1, Name = "English (US)", Culture = "en_US" };
            Language ru_RU = new() { Id = 2, Name = "Russian (RU)", Culture = "ru_RU" };
            Language hy_AM = new() { Id = 3, Name = "Armenian (AM)", Culture = "hy_AM" };

            builder.HasData(en_US, ru_RU, hy_AM);
        }

        protected override string TableName()
        {
            return nameof(Models.Content.Translation.Language) + "s";
        }
    }
}
