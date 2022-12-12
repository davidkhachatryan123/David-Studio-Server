using David_Studio_Server.Database.Base;
using David_Studio_Server.Database.Models.Content.Services;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace David_Studio_Server.Database.ModelConfigrations.Content.Services
{
    public class HomeServiceConfigurationModel : IdentityModelConfiguration<HomeService>
    {
        protected override void AddBuilder(EntityTypeBuilder<HomeService> builder)
        {
            builder.Property(x => x.ButtonColor).HasMaxLength(Configuration.TinyTextLength);
        }

        protected override string TableName()
        {
            return nameof(HomeService) + "s";
        }
    }
}
