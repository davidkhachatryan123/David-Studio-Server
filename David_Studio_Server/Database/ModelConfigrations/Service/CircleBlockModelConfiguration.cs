using David_Studio_Server.Database.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace David_Studio_Server.Database.ModelConfigrations.Service
{
    public class CircleBlockModelConfiguration : IdentityModelConfiguration<Models.Service.CircleBlock>
    {
        protected override void AddBuilder(EntityTypeBuilder<Models.Service.CircleBlock> builder)
        {
            builder.Property(x => x.Title).HasColumnType("VARCHAR").HasMaxLength(Configuration.ShortTextLength);
        }

        protected override string TableName()
        {
            return nameof(Models.Service.CircleBlock) + "s";
        }
    }
}
