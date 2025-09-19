using System.Security.Cryptography;
using System.Text;

namespace Fanap.Shop.Domain.Common.Extensions;

public static class PasswordHelper
{
    public static string HashMd5(string password)
    {
        using var md5 = MD5.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hashBytes = md5.ComputeHash(bytes);
        return Convert.ToHexString(hashBytes); 
    }
}
