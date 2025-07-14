using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PdfGeneratorService.Domain.Entities.Base;

namespace PdfGeneratorService.Infrastructure.Data.Mappings.Base;

public abstract class EntityBaseMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(e => e.Id)
            .HasColumnName("id")
            .IsRequired();

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
