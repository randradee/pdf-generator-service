using PdfGeneratorService.Application.Abstractions;

namespace PdfGeneratorService.Application.Features.Auth.Commands;

public class GenerateTokenCommand : CommandBase<string>
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}