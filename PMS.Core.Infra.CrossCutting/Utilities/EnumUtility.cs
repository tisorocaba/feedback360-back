using PMS.Core.Infra.CrossCutting.Attributes;

namespace PMS.Core.Infra.CrossCutting.Utilities;

public class EnumUtility
{
    public static TEnum GetEnum<TEnum>(string? input)
        where TEnum : struct, Enum
    {
        TEnum output;
        if (!string.IsNullOrWhiteSpace(input))
            Enum.TryParse(input, out output);
        else
            output = default;
        return output;
    }

    public static string? GetLocalizedDescription<TEnum>(string? input)
        where TEnum : struct, Enum
    {
        string? description = default;
        var currentInput = input?.ToString() ?? string.Empty;
        var enumMemberInfo = typeof(TEnum).GetMember(currentInput).FirstOrDefault();
        if (enumMemberInfo != null)
        {
            var localizedDescription = (LocalizedDescriptionAttribute?)enumMemberInfo.GetCustomAttributes(typeof(LocalizedDescriptionAttribute), false)
                                                                                     .FirstOrDefault();
            if (localizedDescription != null)
                description = localizedDescription.Description;
        }
        return description;
    }
}
