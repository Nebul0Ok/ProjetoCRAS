using System.Security.Cryptography;
using System.Text;

namespace AbasteceCRAS.Core;

public class HashSenha
{
    public static string HashSenhas(string senha)
    {
        if (string.IsNullOrEmpty(senha))
        {
            return string.Empty;
        }

        byte[] inputBytes = Encoding.UTF8.GetBytes(senha);

        byte[] hashBytes = SHA256.HashData(inputBytes);

        return Convert.ToHexString(hashBytes).ToLower();

    }
}
