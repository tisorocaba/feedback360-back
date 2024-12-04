namespace PMS.Core.Infra.CrossCutting.ExtensionMethods;

public static class DecimalExtensionMethods
{
    public static bool IsBetween(this decimal number, decimal start, decimal end)
    {
        return (number >= start) && (number <= end);
    }
}
