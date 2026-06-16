using EnterpriseApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnterpriseApi.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.RoleId);

            builder.Property(x => x.RoleName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.HasIndex(x => x.RoleName)
                   .IsUnique();
        }
    }
}