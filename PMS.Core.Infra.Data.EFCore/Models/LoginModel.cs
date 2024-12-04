namespace PMS.Core.Infra.Data.EFCore.Models;

public class LoginModel
{
    #region Properties
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
    #endregion Properties
}
