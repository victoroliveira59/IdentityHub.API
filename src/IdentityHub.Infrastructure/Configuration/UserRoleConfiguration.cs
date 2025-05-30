using IdentityHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityHub.Infrastructure.Configuration;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
     public void Configure(EntityTypeBuilder <UserRole> entity)
    {
        entity.ToTable("UsuarioPerfil");

        entity.HasKey(e => new { IdentificadorUser = e.IdentificadorUserRole, e.RoleId });

        entity.Property(e => e.IdentificadorUserRole)
            .IsRequired()
            .HasColumnType("uniqueidentifier");

        entity.Property(e => e.RoleId)
            .IsRequired()
            .HasColumnType("uniqueidentifier");

        entity.HasOne(e => e.User)
            .WithMany(e => e.UserRoles)
            .HasForeignKey(e => e.IdentificadorUserRole)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(e => e.Role)
            .WithMany(e => e.UserRoles)
            .HasForeignKey(e => e.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
