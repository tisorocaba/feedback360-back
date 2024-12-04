namespace PMS.Core.Infra.Data.EFCore.Models;

public class TokenModel
{
    #region Properties
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    #endregion Properties
}
