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

    public static bool VerifyPassword(string password, string storedHashBase64, string storedSaltBase64)
    {
        byte[] saltBytes = Convert.FromBase64String(storedSaltBase64);
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

        byte[] passwordWithSalt = new byte[passwordBytes.Length + saltBytes.Length];
        Buffer.BlockCopy(passwordBytes, 0, passwordWithSalt, 0, passwordBytes.Length);
        Buffer.BlockCopy(saltBytes, 0, passwordWithSalt, passwordBytes.Length, saltBytes.Length);

        using (var sha256 = SHA256.Create())
        {
            byte[] computedHash = sha256.ComputeHash(passwordWithSalt);
            string computedHashBase64 = Convert.ToBase64String(computedHash);
            return computedHashBase64 == storedHashBase64;
        }
    }


}