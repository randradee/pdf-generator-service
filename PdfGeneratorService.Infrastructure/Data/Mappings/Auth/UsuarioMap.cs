using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PdfGeneratorService.Domain.Entities.Auth;
using PdfGeneratorService.Infrastructure.Data.Mappings.Base;

namespace PdfGeneratorService.Infrastructure.Data.Mappings.Auth;

public class UsuarioMap : EntityBaseMap<Usuario>
{
    public override void Configure(EntityTypeBuilder<Usuario> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("usuarios");

        builder.Property(u => u.Username)
            .HasColumnName("username")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.PasswordHash)
            .HasColumnName("password_hash")
            .HasColumnType("bytea")
            .IsRequired();

        builder.Property(u => u.PasswordSalt)
            .HasColumnName("password_salt")
            .HasColumnType("bytea")
            .IsRequired();
    }
}