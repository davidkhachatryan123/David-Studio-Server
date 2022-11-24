
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace David_Studio_Server.Database.Base
{
    public abstract class IdentityModelConfiguration<T> : IEntityTypeConfiguration<T> where T : Identity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(TableName());
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();

            AddBuilder(builder);
        }

        protected abstract void AddBuilder(EntityTypeBuilder<T> builder);

        protected abstract string TableName();
    }
}
