using Microsoft.VisualBasic;
using PMS.Core.Infra.CrossCutting.Constants;

namespace PMS.Core.Infra.CrossCutting.ExtensionMethods;

public static class StringExtensionMethods
{
    public static string Left(this string str, int length)
    {
        int len = str.Length > Math.Abs(length) ? length : str.Length;
        return Strings.Left(str, len);
    }

    public static string RemovePunctuationPoints(this string str)
    {
        return str.Replace(CoreInfraCrossCuttingConstants.Dot, string.Empty)
                  .Replace(CoreInfraCrossCuttingConstants.Hyphen, string.Empty);
    }

    public static string ToFirstUpperChar(this string str)
    {
        var lowerStr = str.ToLower();
        if (lowerStr.Length > 0)
            return string.Concat(lowerStr[0].ToString().ToUpper(), Strings.Right(lowerStr, lowerStr.Length - 1));
        else
            return lowerStr;
    }

    public static Guid ToGuid32HexadecimalDigits(this string str)
    {
        string hexDigits = str.PadLeft(32, CoreInfraCrossCuttingConstants.ZeroChar)
                              .Insert(8, CoreInfraCrossCuttingConstants.Hyphen)
                              .Insert(13, CoreInfraCrossCuttingConstants.Hyphen)
                              .Insert(18, CoreInfraCrossCuttingConstants.Hyphen)
                              .Insert(23, CoreInfraCrossCuttingConstants.Hyphen);
        Guid value;
        Guid.TryParse(hexDigits, out value);
        return value;
    }

    public static string ToLowerCaseFirstChar(this string str)
    {
        return $"{Strings.Left(str, 1).ToLower()}{Strings.Right(str, str.Length - 1)}";
    }
}
