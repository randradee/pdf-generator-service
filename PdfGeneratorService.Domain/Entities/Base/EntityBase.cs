namespace PdfGeneratorService.Domain.Entities.Base;

public abstract class EntityBase
{
    public Guid Id { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    public DateTime? AtualizadoEm { get; set; }
    public bool Ativo { get; set; } = true;
}