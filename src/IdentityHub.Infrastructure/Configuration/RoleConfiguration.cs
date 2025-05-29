using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityHub.Infrastructure.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");

        builder.HasKey(r => r.IdentificadorRole);

        builder.Property(r => r.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(r => r.Descricao)
            .HasMaxLength(500);

        builder.HasMany(r => r.UserRoles)
            .WithOne(ur => ur.Role)
            .HasForeignKey(ur => ur.IdentificadorUserRole)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
