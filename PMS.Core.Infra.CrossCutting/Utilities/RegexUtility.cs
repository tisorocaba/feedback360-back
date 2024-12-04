using System.Text.RegularExpressions;

namespace PMS.Core.Infra.CrossCutting.Utilities;

public class RegexUtility
{
    #region Constants
    const string RegexConnectionStringKeyValuePairs = "(?<key>[^=;,]+)=(?<val>[^;,]+(,\\d+)?)";
    const string RegexEmail = "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])"; //"^\\S+@\\S+\\.\\S+$";
    const string RegexEmails = "\\S+@\\S+\\.\\S+";
    const string RegexKeyValuePairEqualSeparator = "(?<key>[^:]+)=(?<value>[^,]+);?";
    const string RegexOnlyNumbers = @"[^\d]";
    public const string RegexToSplitAlphabeticAndNumbericParts = @"(?<=\p{L})(?=\p{N})";
    #endregion Constants

    #region Methods
    public static string[] ExtractEmailsFromString(string? str)
    {
        Regex extractEmailsRegex = new Regex(RegexEmails);
        return extractEmailsRegex.Matches(str ?? string.Empty)
                                 .Cast<Match>()
                                 .Select(m => m.Value)
                                 .ToArray();
    }

    public static Dictionary<string, string?> ExtractKeyValuePairEqualSeparator(string? str)
    {
        Regex keyValuePairEqualSeparatorRegex = new Regex(RegexKeyValuePairEqualSeparator);
        var keyValuePairs = keyValuePairEqualSeparatorRegex.Match(str ?? string.Empty).Groups.Values
                                                           .Where(g => g.Value != str)
                                                           .Select(i => i.Value)
                                                           .ToArray();

        var dictionary = new Dictionary<string, string?>();
        if ((keyValuePairs.Length % 2) == 0)
        {
            string lastKey = string.Empty;
            for (int currentIndex = 0; currentIndex < keyValuePairs.Length; currentIndex++)
            {
                if ((currentIndex % 2) == 0)
                {
                    lastKey = keyValuePairs[currentIndex].ToLower().Trim();
                    if (!dictionary.ContainsKey(lastKey))
                        dictionary.Add(lastKey, null);
                }
                else
                {
                    if (dictionary.ContainsKey(lastKey))
                        dictionary[lastKey] = keyValuePairs[currentIndex];
                }
            }
        }
        return dictionary;
    }

    public static Match[] ExtractKeyValuePairsFromConnectionString(string? str)
    {
        Regex connectionStringKeyValuePairsRegex = new Regex(RegexConnectionStringKeyValuePairs);
        return connectionStringKeyValuePairsRegex.Matches(str ?? string.Empty)
                                                 .Cast<Match>()
                                                 .ToArray();
    }

    public static string ExtractOnlyNumbersFromString(string? str)
    {
        Regex extractOnlyNumbersRegex = new Regex(RegexOnlyNumbers);
        return extractOnlyNumbersRegex.Replace(str ?? string.Empty, string.Empty);
    }

    public static void SplitAlphabeticAndNumbericParts(string? str, out string alphabetic, out int numeric)
    {
        var splitted = Regex.Split(str ?? string.Empty, RegexToSplitAlphabeticAndNumbericParts);
        if (splitted?.Length >= 2)
        {
            alphabetic = (splitted[0] ?? string.Empty);
            int.TryParse(splitted[1], out numeric);
        }
        else
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            alphabetic = null;
            numeric = 0;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }
    }

    public static bool ValidateEmail(string? str)
    {
        Regex validateEmailRegex = new Regex(RegexEmail);
        return validateEmailRegex.IsMatch(str ?? string.Empty);
    }
    #endregion Methods
}
