using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PdfGeneratorService.Domain.Entities.Base;

namespace PdfGeneratorService.Infrastructure.Mappings.Base;

public static class EntityBaseMap
{
    public static void ConfigureBase<TEntity>(EntityTypeBuilder<TEntity> builder) where TEntity : EntityBase
    {
        builder.Property(e => e.CriadoEm)
            .HasColumnName("criado_em")
            .IsRequired();

        builder.Property(e => e.AtualizadoEm)
            .HasColumnName("atualizado_em");

        builder.Property(e => e.Ativo)
            .HasColumnName("ativo")
            .IsRequired();
    }
}