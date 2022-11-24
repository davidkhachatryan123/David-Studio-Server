using David_Studio_Server.Database.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace David_Studio_Server.Database.ModelConfigrations.Project
{
    public class ProjectImageModelConfiuration : IdentityModelConfiguration<Models.Project.ProjectImage>
    {
        protected override void AddBuilder(EntityTypeBuilder<Models.Project.ProjectImage> builder)
        {
            builder.Property(x => x.Url).HasColumnType("VARCHAR").HasMaxLength(Configuration.UrlLength);
        }

        protected override string TableName()
        {
            return nameof(Models.Project.ProjectImage) + "s";
        }
    }
}
