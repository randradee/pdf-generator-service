using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PdfGeneratorService.Domain.Entities.Auth;
using PdfGeneratorService.Infrastructure.Mappings.Base;

namespace PdfGeneratorService.Infrastructure.Mappings.Auth;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuarios");
        
        EntityBaseMap.ConfigureBase(builder);

        builder.Property(u => u.Username)
            .HasColumnName("username")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.PasswordHash)
            .HasColumnName("password_hash")
            .IsRequired();
    }
}
