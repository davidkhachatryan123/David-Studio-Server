using David_Studio_Server.Database.Base;
using David_Studio_Server.Database.Models.Content.Services;
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

            builder.HasIndex(u => u.GroupName).IsUnique();

            /*Service web = new() { Id = 1, GroupName = "Web", ButtonColor = "#449d44", Href = "/services/web", ImageId = 40 };
            Service desktop = new() { Id = 2, GroupName = "Desktop", ButtonColor = "#ec971f", Href = "/services/desktop", ImageId = 36 };
            Service arduino = new() { Id = 3, GroupName = "Arduino", ButtonColor = "#31b0d5", Href = "/services/arduino", ImageId = 34 };
            Service hosting = new() { Id = 4, GroupName = "Hosting", ButtonColor = "#c9302c", Href = "/services/hosting", ImageId = 38 };

            builder.HasData(web, desktop, arduino, hosting);*/
        }

        protected override string TableName()
        {
            return nameof(Models.Content.Services.Service) + "s";
        }
    }
}
