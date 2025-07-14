using PdfGeneratorService.Domain.Entities.Base;

namespace PdfGeneratorService.Domain.Entities.Auth;

public class Usuario : EntityBase
{
    public string Username { get; set; } = null!;
    public byte[] PasswordHash { get; set; } = null!;
    public byte[] PasswordSalt { get; set; } = null!;
}