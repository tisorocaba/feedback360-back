using PMS.Core.Infra.CrossCutting.Constants;

namespace PMS.Core.Infra.CrossCutting.Security;

public class PasswordGenerator
{
    #region Constructors
    public PasswordGenerator()
    {
        this._random = new Random();
    }
    #endregion Constructors

    #region Constants
    private const int DefaultLength = 10;
    private const string FormatX = "X", FormatX2 = "X2";
    #endregion Constants

    #region Fields
    private readonly Random _random;
    #endregion Fields

    #region Methods
    public string GenerateHexadecimal(int pDigits = DefaultLength)
    {
        int digits = Math.Abs(pDigits);
        byte[] buffer = new byte[digits / 2];
        this._random.NextBytes(buffer);
        string result = string.Concat(buffer.Select(x => x.ToString(FormatX2)).ToArray());
        if (digits % 2 == 0)
            return result;
        return result + this._random.Next(16).ToString(FormatX);
    }

    public string GeneratePassword(int pLength = DefaultLength)
    {
        int length = Math.Abs(pLength);
        string password = new string(Enumerable.Repeat(CoreInfraCrossCuttingConstants.PasswordAllowedCharacters, length)
                                               .Select(s => s[this._random.Next(s.Length)]).ToArray());
        return password;
    }
    #endregion Methods
}
