using David_Studio_Server.Database.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace David_Studio_Server.Database.ModelConfigrations.Content.Services
{
    public class ServiceConfigurationModel : IdentityModelConfiguration<Models.Content.Services.Service>
    {
        protected override void AddBuilder(EntityTypeBuilder<Models.Content.Services.Service> builder)
        {
            builder.Property(x => x.GroupName).HasMaxLength(Configuration.ShortTextLength);
            builder.Property(x => x.ButtonColor).HasMaxLength(Configuration.TinyTextLength);
            builder.Property(x => x.Href).HasMaxLength(Configuration.LongTextLength);
        }

        protected override string TableName()
        {
            return nameof(Models.Content.Services.Service) + "s";
        }
    }
}
