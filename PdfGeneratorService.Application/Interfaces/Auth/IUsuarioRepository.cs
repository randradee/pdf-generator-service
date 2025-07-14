
using PdfGeneratorService.Domain.Entities.Auth;

namespace PdfGeneratorService.Application.Interfaces.Auth;

public interface IUsuarioRepository
{
    Task<Usuario?> GetUserAsync(string username, CancellationToken cancellationToken = default);
}