using EnterpriseApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnterpriseApi.Persistence.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.ClientId);

            builder.Property(x => x.ClientName)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.ClientKey)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.HasIndex(x => x.ClientKey)
                   .IsUnique();
        }
    }
}