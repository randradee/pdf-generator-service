using PdfGeneratorService.Domain.Entities.Base;

namespace PdfGeneratorService.Domain.Entities.Auth;

public class Usuario : EntityBase
{
    public string Username { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string PasswordSalt { get; set; } = null!;
}