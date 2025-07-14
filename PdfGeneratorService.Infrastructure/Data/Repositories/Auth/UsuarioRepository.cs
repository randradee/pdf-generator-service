
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
    
    public async Task CreateUserAsync(Usuario usuario, CancellationToken cancellationToken = default)
    {
        await context.Usuarios.AddAsync(usuario, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

}