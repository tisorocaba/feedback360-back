namespace PMS.Core.UnitTest.Fixtures.Base;

public abstract class FixtureBase
    : IDisposable
{
    #region Methods
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
    #endregion Methods
}
