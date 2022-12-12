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

            builder.HasIndex(u => u.Name).IsUnique();

            Service web = new() { Id = 1, Name = "Web" };
            Service desktop = new() { Id = 2, Name = "Desktop" };
            Service arduino = new() { Id = 3, Name = "Arduino" };
            Service hosting = new() { Id = 4, Name = "Hosting" };

            builder.HasData(web, desktop, arduino, hosting);
        }

        protected override string TableName()
        {
            return nameof(Service) + "s";
        }
    }
}
