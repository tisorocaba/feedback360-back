using PMS.Core.Domain.DomainModels.Base;
using PMS.Core.Infra.CrossCutting.Utilities;
using PMS.MicroServices.LuckyDraw.Domain.Enums;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels.Base;

public abstract class EvaluatableDomainModelBase<TMeasurable>
    : DomainModelBase<Guid>
    where TMeasurable : struct, Enum
{
    #region Constructors
    public EvaluatableDomainModelBase()
    {
        this.QuestionsAndAnswers = new List<QuestionAnswer>(50);
        this._possibleEnumNames = this.GetPossibleEnumNames(Enum.GetValues(typeof(TMeasurable)));
    }
    #endregion Constructors

    #region Fields
    readonly Dictionary<string, TMeasurable> _possibleEnumNames;
    #endregion Fields

    #region Methods
    public void Calculate()
    {
        decimal average = 0;
        if (this.QuestionsAndAnswers.Any())
        {
            decimal accumulator = 0; int counter = 0;
            foreach (var currentAnswer in this.QuestionsAndAnswers)
            {
                var itemResult = this.GetItemResult(currentAnswer);
                if (itemResult > 0)
                {
                    accumulator += itemResult;
                    counter++;
                }
            }
            if (counter == 0)
                counter = 1;
            average = (accumulator / counter);
        }
        this.Average = Math.Round(average, 2);
    }

    public int GetItemResult(QuestionAnswer questionAnswer)
    {
        int result = default;
        if (typeof(TMeasurable) == typeof(AgreementEnum))
            result = this.GetCorrespondingAgreementValue(questionAnswer);
        if (typeof(TMeasurable) == typeof(AgreementAndSatisfactionEnum))
            result = this.GetCorrespondingAgreementAndSatisfactionValue(questionAnswer);
        if (typeof(TMeasurable) == typeof(SatisfactionEnum))
            result = this.GetCorrespondingSatisfactionValue(questionAnswer);
        return result;
    }

    public int GetCorrespondingAgreementValue(QuestionAnswer questionAnswer)
    {
        AgreementEnum value;
        var strValue = questionAnswer.Answer?.ToLower();
        if ((string.IsNullOrWhiteSpace(strValue)) || (!this._possibleEnumNames.ContainsKey(strValue)))
            value = AgreementEnum.NotSet;
        else
            value = EnumUtility.GetEnum<AgreementEnum>(this._possibleEnumNames[strValue].ToString());
        questionAnswer.Value = value;
        return (int)value;
    }

    public int GetCorrespondingAgreementAndSatisfactionValue(QuestionAnswer questionAnswer)
    {
        AgreementAndSatisfactionEnum value;
        var strValue = questionAnswer.Answer?.ToLower();
        if ((string.IsNullOrWhiteSpace(strValue)) || (!this._possibleEnumNames.ContainsKey(strValue)))
            value = AgreementAndSatisfactionEnum.NotSet;
        else
            value = EnumUtility.GetEnum<AgreementAndSatisfactionEnum>(this._possibleEnumNames[strValue].ToString());
        questionAnswer.Value = value;
        return (int)value;
    }

    public int GetCorrespondingSatisfactionValue(QuestionAnswer questionAnswer)
    {
        SatisfactionEnum value;
        var strValue = questionAnswer.Answer?.ToLower();
        if ((string.IsNullOrWhiteSpace(strValue)) || (!this._possibleEnumNames.ContainsKey(strValue)))
            value = SatisfactionEnum.NotSet;
        else
            value = EnumUtility.GetEnum<SatisfactionEnum>(this._possibleEnumNames[strValue].ToString());
        questionAnswer.Value = value;
        return (int)value;
    }

    public Dictionary<string, TMeasurable> GetPossibleEnumNames(Array values)
    {
        var customNames = new Dictionary<string, TMeasurable>();
        foreach (var currentValue in values)
        {
            var currentStringValue = currentValue?.ToString() ?? string.Empty;
            var localizedDescription = EnumUtility.GetLocalizedDescription<TMeasurable>(currentStringValue)?.ToLower();

            if ((!string.IsNullOrWhiteSpace(localizedDescription)) && (!customNames.ContainsKey(localizedDescription)))
                customNames.Add(localizedDescription, EnumUtility.GetEnum<TMeasurable>(currentStringValue));
        }
        return customNames;
    }
    #endregion Methods

    #region Properties
    public decimal Average { get; private set; }

    public List<QuestionAnswer> QuestionsAndAnswers { get; set; }
    #endregion Properties
}
