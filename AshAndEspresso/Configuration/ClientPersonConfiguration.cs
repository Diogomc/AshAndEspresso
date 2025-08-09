using AshAndEspresso.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AshAndEspresso.Configuration;

public class ClientPersonConfiguration : IEntityTypeConfiguration<ClientPerson>
{
    public void Configure(EntityTypeBuilder<ClientPerson> builder)
    {
        builder.HasKey(p => p.ClientId);
        builder.ToTable("ClientPerson");
        builder.Property(p => p.Name).HasMaxLength(150).IsRequired();
        builder.Property(p => p.LastName).HasMaxLength(150).IsRequired();
        builder.Property(p => p.Email).HasMaxLength(300).IsRequired();
        builder.Property(p => p.Password).HasMaxLength(100).IsRequired();
        builder.Property(p => p.BirthDate).IsRequired();
    }
}
