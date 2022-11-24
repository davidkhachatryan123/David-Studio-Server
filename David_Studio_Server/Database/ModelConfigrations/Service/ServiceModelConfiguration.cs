using David_Studio_Server.Database.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace David_Studio_Server.Database.ModelConfigrations.Service
{
    public class ServiceModelConfiguration : IdentityModelConfiguration<Models.Service.Service>
    {
        protected override void AddBuilder(EntityTypeBuilder<Models.Service.Service> builder)
        {
            builder.Property(x => x.ImgUrl).HasColumnType("VARCHAR").HasMaxLength(Configuration.UrlLength);
        }

        protected override string TableName()
        {
            return nameof(Models.Service.Service) + "s";
        }
    }
}
