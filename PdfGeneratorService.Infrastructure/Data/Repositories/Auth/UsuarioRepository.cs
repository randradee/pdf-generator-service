
using Microsoft.EntityFrameworkCore;
using PdfGeneratorService.Application.Interfaces.Auth;
using PdfGeneratorService.Domain.Entities.Auth;
using PdfGeneratorService.Infrastructure.Data.Context;

namespace PdfGeneratorService.Infrastructure.Data.Repositories.Auth;

public class UsuarioRepository(AppDbContext context) : IUsuarioRepository
{
    public async Task<Usuario?> GetUserAsync(string username, CancellationToken cancellationToken = default)
    {
        return await context.Usuarios
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Username == username && x.Ativo, cancellationToken);
    }
}