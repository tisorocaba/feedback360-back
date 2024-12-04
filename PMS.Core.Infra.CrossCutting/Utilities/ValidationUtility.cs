namespace PMS.Core.Infra.CrossCutting.Utilities;

public class ValidationUtility
{
    public static bool ValidateHexadecimal(string str)
    {
        int hexadecimal;
        return int.TryParse(str, System.Globalization.NumberStyles.HexNumber, null, out hexadecimal);
    }
}
