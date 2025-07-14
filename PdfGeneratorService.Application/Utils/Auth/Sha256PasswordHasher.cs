using System.Security.Cryptography;
using System.Text;

namespace PdfGeneratorService.Application.Utils.Auth;

public static class Sha256PasswordHasher
{
    public static (string hashBase64, string saltBase64) HashPassword(string password)
    {
        var saltBytes = RandomNumberGenerator.GetBytes(16);
        var saltedPassword = Encoding.UTF8.GetBytes(password).Concat(saltBytes).ToArray();
        var hashBytes = SHA256.HashData(saltedPassword);

        return (
            Convert.ToBase64String(hashBytes),
            Convert.ToBase64String(saltBytes)
        );
    }

    public static bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
    {
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        var passwordWithSalt = new byte[passwordBytes.Length + storedSalt.Length];

        Buffer.BlockCopy(passwordBytes, 0, passwordWithSalt, 0, passwordBytes.Length);
        Buffer.BlockCopy(storedSalt, 0, passwordWithSalt, passwordBytes.Length, storedSalt.Length);

        using var sha256 = SHA256.Create();
        var computedHash = sha256.ComputeHash(passwordWithSalt);
        Console.WriteLine($"Comparando senha...");
        Console.WriteLine($"Senha digitada: {password}");
        Console.WriteLine($"Salt (Base64): {Convert.ToBase64String(storedSalt)}");
        Console.WriteLine($"Hash esperado: {Convert.ToBase64String(storedHash)}");
        Console.WriteLine($"Hash calculado: {Convert.ToBase64String(computedHash)}");
        
        return CryptographicOperations.FixedTimeEquals(computedHash, storedHash);
    }



}