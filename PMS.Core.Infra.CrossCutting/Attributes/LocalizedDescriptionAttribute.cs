using System.Resources;

namespace PMS.Core.Infra.CrossCutting.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class LocalizedDescriptionAttribute : Attribute
{
    #region Constructors
    public LocalizedDescriptionAttribute(Type? resourceType = null, string? resourceName = null)
    {
        if ((resourceType != null) && (!string.IsNullOrWhiteSpace(resourceName)))
        {
            this._resourceManager = new ResourceManager(resourceType);
            this._resourceName = resourceName;
            if (!string.IsNullOrWhiteSpace(this._resourceName))
                this.Description = this._resourceManager.GetString(this._resourceName);
            else
                this.Description = string.Empty;
        }
    }
    #endregion Constructors

    #region Fields
    ResourceManager? _resourceManager;
    string? _resourceName;
    public string? Description { get; }
    #endregion Fields
}
