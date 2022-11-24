using David_Studio_Server.Database.Base;
using David_Studio_Server.Database.Models.Contact;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace David_Studio_Server.Database.ModelConfigrations.Contact
{
    public class ContactModelConfiguration : IdentityModelConfiguration<Models.Contact.Contact>
    {
        protected override void AddBuilder(EntityTypeBuilder<Models.Contact.Contact> builder)
        {
            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(Configuration.ShortTextLength);
            builder.Property(x => x.Email).HasColumnType("VARCHAR").HasMaxLength(Configuration.TextLength);
            builder.Property(x => x.PhoneNumber).HasColumnType("VARCHAR").HasMaxLength(Configuration.ShortTextLength);
            builder.Property(x => x.Message).HasColumnType("VARCHAR").HasMaxLength(Configuration.LongTextLength);
        }

        protected override string TableName()
        {
            return nameof(Contact) + "s";
        }
    }
}
