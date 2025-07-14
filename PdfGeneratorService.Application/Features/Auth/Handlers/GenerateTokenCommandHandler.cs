using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PdfGeneratorService.Application.Features.Auth.Commands;
using PdfGeneratorService.Application.Interfaces.Auth;
using PdfGeneratorService.Application.Utils.Auth;

namespace PdfGeneratorService.Application.Features.Auth.Handlers;

public class GenerateTokenCommandHandler(IConfiguration configuration, IUsuarioRepository usuarioRepository)
    : IRequestHandler<GenerateTokenCommand, string>
{
    public async Task<string> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await usuarioRepository.GetUserAsync(request.Username, cancellationToken);

        if (user == null || !Sha256PasswordHasher.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
            return string.Empty;

        var key = Encoding.ASCII.GetBytes(configuration["Jwt:Secret"]!);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            ]),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}