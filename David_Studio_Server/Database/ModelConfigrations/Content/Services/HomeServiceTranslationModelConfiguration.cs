using David_Studio_Server.Database.Base;
using David_Studio_Server.Database.Models.Content.Services;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace David_Studio_Server.Database.ModelConfigrations.Content.Services
{
    public class HomeServiceTranslationModelConfiguration : IdentityModelConfiguration<HomeServiceTranslation>
    {
        protected override void AddBuilder(EntityTypeBuilder<HomeServiceTranslation> builder)
        {

        }

        protected override string TableName()
        {
            return nameof(HomeServiceTranslation) + "s";
        }
    }
}
