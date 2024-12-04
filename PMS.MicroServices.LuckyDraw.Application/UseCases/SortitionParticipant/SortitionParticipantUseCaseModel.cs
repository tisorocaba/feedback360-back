using Newtonsoft.Json;
using PMS.Core.Application.Models.Base;
using PMS.Core.Infra.CrossCutting.Cryptography.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Application.UseCases;

namespace PMS.MicroServices.LuckyDraw.Application.Models;

public class SortitionParticipantUseCaseModel
    : AuditableUseCaseModelBase<Guid, SortitionParticipantUseCaseModel>
{
    #region Constants
    private const string ResultSeparator = " | ";
    #endregion Constants

    #region Methods
    public override void Bind(SortitionParticipantUseCaseModel source)
    {
        
    }

    public SortitionConsultResponseMessage ToConsultResponse()
    {
        var response = new SortitionConsultResponseMessage()
        {
            SortitionParticipantNumber = this.Number,
            AccessCounter = this.AccessCounter,
            IdSortition = this.IdSortition
        };

        if (this.Sortition != null)
        {
            response.IdTeam = this.Sortition.IdTeam;
            response.SortitionNumber = this.Sortition.Number;
            response.SortitionActive = this.Sortition.Active;
            this.ToConsultResponseResult(response);
        }

        return response;
    }

    private void ToConsultResponseResult(SortitionConsultResponseMessage response)
    {
        if ((response != null) && (this.Sortition != null))
        {
            var decryptedContent = this.Sortition.Content?.DecryptDES(DESExtensionMethods.Default_DES_Key, DESExtensionMethods.Default_DES_IV);
            if (!string.IsNullOrWhiteSpace(decryptedContent))
            {
                dynamic? deserializedObject = JsonConvert.DeserializeObject(decryptedContent);
                if (deserializedObject?.Items != null)
                {
                    foreach (var currentItem in deserializedObject.Items)
                    {
                        if (object.Equals(currentItem.Key?.Value?.ToString(), this.Number.ToString()))
                        {
                            var currentItemValues = new List<string>(currentItem.Values.Count);
                            foreach (var currentItemValue in currentItem.Values)
                                currentItemValues.Add(currentItemValue.Value.ToString());
                            response.Result = string.Join(ResultSeparator, currentItemValues);
                        }
                    }
                }
            }
        }
    }
    #endregion Methods

    #region Properties
    public Guid IdSortition { get; set; }
    public int Number { get; set; }
    public string Code { get; set; } = default!;
    public int AccessCounter { get; set; }

    public virtual SortitionUseCaseModel Sortition { get; set; } = default!;
    #endregion Properties
}
