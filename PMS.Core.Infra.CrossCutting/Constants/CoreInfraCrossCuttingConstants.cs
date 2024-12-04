namespace PMS.Core.Infra.CrossCutting.Constants;

public class CoreInfraCrossCuttingConstants
{
    public const string AppSettingsDefaultJsonFile = "appsettings.json";
    public const char CommaChar = ',';
    public const string CulturePortugueseBrazil = "pt-BR";
    public const string DateTimeDefaultFormat = "yyyy-MM-dd HH:mm:ss.mmm";
    public const string DecimalDefaultFormat = "n2";
    public const string Dot = ".";
    public const string NullValue = "null";
    public const string Hyphen = "-";
    public const string Password = "Password";
    public const string PasswordAllowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+";
    public const char PipelineChar = '|';
    public const string RegexForEmail = "/^[a-z0-9.]+@[a-z0-9]+\\.[a-z]+\\.([a-z]+)?$/i";
    public const string RegexForEmailDomainWithTLD = "^(?<Email>.*@)?(?<Protocol>\\w+:\\/\\/)?(?<SubDomain>(?:[\\w-]{2,63}\\.){0,127}?)?(?<DomainWithTLD>(?<Domain>[\\w-]{2,63})\\.(?<TopLevelDomain>[\\w-]{2,63}?)(?:\\.(?<CountryCode>[a-z]{2}))?)(?:[:](?<Port>\\d+))?(?<Path>(?:[\\/]\\w*)+)?(?<QString>(?<QSParams>(?:[?&=][\\w-]*)+)?(?:[#](?<Anchor>\\w*))*)?$";
    public const string Space = " ";
    public const string UpperPortugueseYes = "SIM";
    public const char ZeroChar = '0';
}
