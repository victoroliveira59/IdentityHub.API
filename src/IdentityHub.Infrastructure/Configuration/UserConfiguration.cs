using IdentityHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityHub.Infrastructure.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.ToTable("Usuario");

        entity.HasKey(e => e.IdentificadorUser);

        entity.Property(e => e.Email)
            .IsRequired()
            .HasColumnType("varchar(150)")
            .HasMaxLength(100);

        entity.Property(e => e.Nome)
            .IsRequired()
            .HasColumnType("varchar(150)")
            .HasMaxLength(100);

        entity.Property(e => e.PasswordHash)
            .IsRequired()
            .HasColumnType("varchar(50)")
            .HasMaxLength(100);

        entity.Property(e => e.PasswordSalt)
            .IsRequired()
            .HasColumnType("varchar(50)")
            .HasMaxLength(100);

        entity.Property(e => e.DataHoraCriacao)
            .IsRequired()
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()");

        entity.Property(e => e.DataHoraUltimaAlteracao)
            .IsRequired()
            .HasColumnType("datetime");

        entity.Property(e => e.DataHoraExclusao)
            .IsRequired()
            .HasColumnType("datetime");           

        entity.Property(e => e.IsActive)
            .IsRequired()
            .HasColumnType("bit")
            .HasDefaultValue(true);

        entity.HasMany(e => e.UserRoles)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.IdentificadorUserRole)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasMany(e => e.LoginHistories)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.User)
            .OnDelete(DeleteBehavior.Cascade);

        entity.ToTable("Usuario");

    }
}
