using System.Security.Cryptography;
using System.Text;

namespace PMS.Core.Infra.CrossCutting.Cryptography.ExtensionMethods;

public static class DESExtensionMethods
{
    #region Fields
    public static byte[] Default_DES_Key = new byte[] { 83, 79, 82, 84, 69, 65, 68, 79 };
    public static byte[] Default_DES_IV = new byte[] { 65, 86, 65, 76, 73, 65, 68, 79 };
    #endregion Fields

    #region Methods
    private static DES CreateDES(byte[] key, byte[] iv)
    {
        var des = DES.Create();
        des.Key = key;
        des.IV = iv;
        return des;
    }

    public static string DecryptDES(this string text, byte[] key, byte[] iv)
    {
        using (DES des = CreateDES(key, iv))
        {
            var buffer = Convert.FromBase64String(text);
            var sourceStream = new MemoryStream(buffer);
            using (ICryptoTransform decryptor = des.CreateDecryptor(key, iv))
            {
                using (var cryptoStream = new CryptoStream(sourceStream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader reader = new StreamReader(cryptoStream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
    }

    public static string EncryptDES(this string text, byte[] key, byte[] iv)
    {
        using (DES des = CreateDES(key, iv))
        {
            using (ICryptoTransform encryptor = des.CreateEncryptor(key, iv))
            {
                MemoryStream targetStream = new MemoryStream();
                var cryptoStream = new CryptoStream(targetStream, encryptor, CryptoStreamMode.Write);
                // Convert the provided string to a byte array.
                byte[] toEncrypt = Encoding.UTF8.GetBytes(text);

                // Write the byte array to the crypto stream.
                cryptoStream.Write(toEncrypt, 0, toEncrypt.Length);
                cryptoStream.FlushFinalBlock();

                targetStream.Position = 0;
                byte[] buffer = targetStream.ToArray();
                var encrypted = Convert.ToBase64String(buffer);

                targetStream.Flush();
                targetStream.Close();

                return encrypted;
            }
        }
    }
    #endregion Methods
}
