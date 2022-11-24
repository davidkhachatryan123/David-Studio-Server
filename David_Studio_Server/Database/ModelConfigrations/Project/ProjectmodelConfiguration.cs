using David_Studio_Server.Database.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace David_Studio_Server.Database.ModelConfigrations.Project
{
    public class ProjectmodelConfiguration : IdentityModelConfiguration<Models.Project.Project>
    {
        protected override void AddBuilder(EntityTypeBuilder<Models.Project.Project> builder)
        {
            builder.Property(x => x.Title).HasColumnType("VARCHAR").HasMaxLength(Configuration.ShortTextLength);
            builder.Property(x => x.ImgUrl).HasColumnType("VARCHAR").HasMaxLength(Configuration.UrlLength);
        }

        protected override string TableName()
        {
            return nameof(Models.Project.Project) + "s";
        }
    }
}
