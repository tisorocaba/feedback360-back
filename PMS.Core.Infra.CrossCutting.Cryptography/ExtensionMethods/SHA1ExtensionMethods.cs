using PMS.Core.Infra.CrossCutting.Cryptography.Contents;
using System.Security.Cryptography;
using System.Text;

namespace PMS.Core.Infra.CrossCutting.Cryptography.ExtensionMethods;

public static class SHA1ExtensionMethods
{
    public static string HashContent(string content)
    {
        if (!string.IsNullOrWhiteSpace(content))
            return string.Concat(CryptographyConstants.SHACryptographyPrefix, Convert.ToBase64String(SHA1.HashData(Encoding.UTF8.GetBytes(content))));
        else
            return string.Empty;
    }
}
