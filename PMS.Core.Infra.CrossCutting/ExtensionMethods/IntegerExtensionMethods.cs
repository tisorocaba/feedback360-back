namespace PMS.Core.Infra.CrossCutting.ExtensionMethods;

public static class IntegerExtensionMethods
{
    public static bool IsBetween(this int number, int start, int end)
    {
        return (number >= start) && (number <= end);
    }
}
