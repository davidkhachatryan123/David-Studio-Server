using David_Studio_Server.Database.Base;
using David_Studio_Server.Database.Models.Content.Services;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace David_Studio_Server.Database.ModelConfigrations.Content.Services
{
    public class ServiceConfigurationModel : IdentityModelConfiguration<Service>
    {
        protected override void AddBuilder(EntityTypeBuilder<Service> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(Configuration.ShortTextLength);
            builder.Property(x => x.Path).HasMaxLength(Configuration.TextLength);

            builder.HasIndex(u => u.Name).IsUnique();

            Service web = new() { Id = 1, Name = "Web", Path = "/services/web" };
            Service desktop = new() { Id = 2, Name = "Desktop", Path = "/services/desktop" };
            Service arduino = new() { Id = 3, Name = "Arduino", Path = "/services/arduino" };
            Service hosting = new() { Id = 4, Name = "Hosting", Path = "/services/hosting" };

            builder.HasData(web, desktop, arduino, hosting);
        }

        protected override string TableName()
        {
            return nameof(Service) + "s";
        }
    }
}
