using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PMS.Core.Infra.Data.EFCore.Mappings.Interfaces;

public interface IEFCoreDataModelMap
{
    #region Methods
    void Configure(EntityTypeBuilder builder);
    #endregion Methods
}
