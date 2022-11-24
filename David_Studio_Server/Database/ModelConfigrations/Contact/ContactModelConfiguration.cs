using David_Studio_Server.Database.Base;
using David_Studio_Server.Database.Models.Contact;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace David_Studio_Server.Database.ModelConfigrations.Contact
{
    public class ContactModelConfiguration : IdentityModelConfiguration<Models.Contact.Contact>
    {
        protected override void AddBuilder(EntityTypeBuilder<Models.Contact.Contact> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(64);
            builder.Property(x => x.Email).HasMaxLength(256);
            builder.Property(x => x.PhoneNumber).HasMaxLength(64);
            builder.Property(x => x.Message).HasMaxLength(1000);
        }

        protected override string TableName()
        {
            return nameof(Contact);
        }
    }
}
