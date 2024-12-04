using Microsoft.AspNetCore.Identity;

namespace PMS.Core.Infra.Data.EFCore.SqlServer.Models;

public class ApplicationUser
    : IdentityUser<Guid>
{
    #region Properties
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiresAt { get; set; }
    #endregion Properties
}
