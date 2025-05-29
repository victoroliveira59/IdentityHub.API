using IdentityHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityHub.Infrastructure.Configuration;

public class LoginHistoryConfiguration : IEntityTypeConfiguration<LoginHistory>
{
     public void Configure(EntityTypeBuilder<LoginHistory> entity)
    {
        entity.ToTable("HistoricoLogin");

        entity.HasKey(e => e.IdentificadorHistorico);

        entity.Property(e => e.IdentificadorHistorico)
            .IsRequired()
            .HasColumnType("uniqueidentifier");


        entity.Property(e => e.LoginDate)
            .IsRequired()
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()");

        entity.Property(e => e.IpAdress)
            .IsRequired()
            .HasColumnType("varchar(45)")
            .HasMaxLength(45);

        entity.Property(e => e.IsSuccessful)
            .IsRequired()
            .HasColumnType("bit")
            .HasDefaultValue(false);

        entity.HasOne(e => e.User)
            .WithMany(e => e.LoginHistories)
            .HasForeignKey(e => e.User)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_LoginHistory_User");


    }
}
