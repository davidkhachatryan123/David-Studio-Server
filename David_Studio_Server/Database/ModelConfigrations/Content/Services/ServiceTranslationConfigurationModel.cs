using David_Studio_Server.Database.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace David_Studio_Server.Database.ModelConfigrations.Content.Services
{
    public class ServiceTranslationConfigurationModel : IdentityModelConfiguration<Models.Content.Services.ServiceTranslation>
    {
        protected override void AddBuilder(EntityTypeBuilder<Models.Content.Services.ServiceTranslation> builder)
        {
            
        }

        protected override string TableName()
        {
            return nameof(Models.Content.Services.ServiceTranslation) + "s";
        }
    }
}
