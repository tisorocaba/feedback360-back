using PMS.Core.Infra.CrossCutting.Constants;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.Core.Infra.CrossCutting.Utilities;
using PMS.Core.Service.Base;
using PMS.MicroServices.LuckyDraw.BoundedContexts.SharedKernel.Enums;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;

namespace PMS.MicroServices.LuckyDraw.Service.Models;

public class GeneralAssessmentServiceModel
    : ServiceModelBase<Guid>
{
    #region Fields
    private decimal? _coWorker1AnswerValue;
    private decimal? _coWorker2AnswerValue;
    private decimal? _coWorker3AnswerValue;
    private decimal? _coWorkersAverageAnswerValue;
    private decimal? _extraCoWorkersAnswerValue;
    private decimal? _immediateLeaderAverageAnswerValue;
    private decimal? _mediateLeaderAverageAnswerValue;
    private decimal? _otherImmediateLeadersAverageAnswerValue;
    private decimal? _otherMediateLeadersAverageAnswerValue;
    private decimal? _selfAssessmentAnswerValue;
    private decimal? _subordinateAnswerValue;
    private decimal? _subordinateAverageAnswerValue;
    #endregion Fields

    #region Methods
    private AssessmentResultBarChartServiceModel? BindAssessmentResultBarChartServiceModel(List<string>? answers, string? questionKey)
    {
        AssessmentResultBarChartServiceModel? chartData;
        if (answers?.Any() ?? false)
        {
            chartData = new AssessmentResultBarChartServiceModel() { TargetName = questionKey ?? string.Empty };
            List<string> values = new List<string>(1000);
            foreach (var currentAnswer in answers)
            {
                if (!string.IsNullOrWhiteSpace(currentAnswer))
                {
                    var currentAnswerParts = currentAnswer.Trim().Split(CoreInfraCrossCuttingConstants.CommaChar);
                    foreach (var currentAnswerPart in currentAnswerParts)
                    {
                        if (!string.IsNullOrWhiteSpace(currentAnswerPart))
                            values.Add(currentAnswerPart.Trim().ToLower().ToFirstUpperChar());
                    }
                }
            }
            values.Sort();
            var occurrences = (from item in values
                               group item by item into keysGroup
                               orderby keysGroup.Key
                               select new ItemValueServiceModel()
                               {
                                    Key = keysGroup.Key,
                                    Value = keysGroup.Count()
                               }).ToList() ?? new List<ItemValueServiceModel>(0);
            var occurrencesLength = occurrences.Count;
            if (occurrencesLength > 0)
                chartData.Color.AddRange(AssessmentResultChartHelper.HexColors.Take(occurrencesLength));

            int counter = 0;
            foreach (var currentOccurrence in occurrences)
            {
                var currentLegend = currentOccurrence.Key;
                chartData.Legend.Data.Add(currentLegend);
                chartData.XAxis.Data.Add(currentLegend);
                var currentSerie = new AssessmentResultBarChartSerieServiceModel(occurrencesLength) { Name = currentLegend };
                currentSerie.Data[counter] = currentOccurrence.Value;
                chartData.Series.Add(currentSerie);
                counter++;
            }
        }
        else
            chartData = null;
        return chartData;
    }

    private AssessmentResultGaugeChartSerieServiceModel BindAssessmentResultGaugeChartSerieServiceModel(List<QuestionAnswer>? questions, string? serieName = null)
    {
        var serieData = new AssessmentResultGaugeChartSerieServiceModel();
        serieData.Name = serieName;
        if (questions?.Any() ?? false)
        {
            Dictionary<string, int> answerOccurrences = new Dictionary<string, int>();
            foreach (var currentQuestion in questions)
            {
                if ((currentQuestion != null) && (!string.IsNullOrWhiteSpace(currentQuestion.Answer)))
                {
                    var adjustedAnswer = currentQuestion.Answer.ToFirstUpperChar();
                    if (!answerOccurrences.ContainsKey(adjustedAnswer))
                        answerOccurrences.Add(adjustedAnswer, 1);
                    else
                        answerOccurrences[adjustedAnswer] = (answerOccurrences[adjustedAnswer] + 1);
                }
            }
            foreach (var currentKey in answerOccurrences.Keys)
                serieData.Data.Add(new AssessmentResultGaugeChartSerieItemDataServiceModel() { Name = currentKey, Value = answerOccurrences[currentKey].ToString() });
        }
        return serieData;
    }

    private AssessmentResultGaugeChartServiceModel BindAssessmentResultGaugeChartServiceModel(List<QuestionAnswer>? questions, string? titleText = null,
                                                                                              string? titleSubtext = null, string? serieName = null)
    {
        var chartData = new AssessmentResultGaugeChartServiceModel();
        chartData.Title.Text = titleText;
        chartData.Title.Subtext = this.GetTitleSubtext(titleSubtext);
        chartData.Series.Add(this.BindAssessmentResultGaugeChartSerieServiceModel(questions, serieName));
        return chartData;
    }

    private decimal? GetPercentualValue(decimal? value)
    {
        decimal? percentual = 0;
        if (value.HasValue)
        {
            switch (value.Value)
            {
                case 2:
                    percentual = 16.7M;
                    break;
                case 3:
                    percentual = 33.3M;
                    break;
                case 4:
                    percentual = 50M;
                    break;
                case 5:
                    percentual = 66.7M;
                    break;
                case 6:
                    percentual = 83.3M;
                    break;
                case 7:
                    percentual = 100M;
                    break;
                default:
                    break;
            }
        }
        return percentual;
    }

    private string? GetTitleSubtext(string? titleSubtext = null)
    {
        string? text;
        if (string.IsNullOrWhiteSpace(titleSubtext))
        {
            string alphabetic; int numeric;
            RegexUtility.SplitAlphabeticAndNumbericParts(this.Key, out alphabetic, out numeric);
            text = $"Pergunta {numeric}";
        }
        else
            text = titleSubtext?.Trim();
        return text;
    }

    public void SetCoWorkersAverageChartData(List<QuestionAnswer>? questions)
    {
        this.CoWorkersAverageChartData = this.BindAssessmentResultGaugeChartServiceModel(questions, Resources.LuckyDrawServiceResource.CHART_COWORKERS_AVERAGE, null,
                                                                                         Resources.LuckyDrawServiceResource.CHART_EVALUATED_AS);
    }

    public void SetExtraCoWorkersChartData(List<QuestionAnswer>? questions)
    {
        this.ExtraCoWorkersChartData = this.BindAssessmentResultGaugeChartServiceModel(questions, Resources.LuckyDrawServiceResource.CHART_EXTRA_COWORKERS, null,
                                                                                       Resources.LuckyDrawServiceResource.CHART_EVALUATED_AS);
    }

    public void SetImmediateLeaderAverageChartData(List<QuestionAnswer>? questions)
    {
        this.ImmediateLeaderAverageChartData = this.BindAssessmentResultGaugeChartServiceModel(questions, Resources.LuckyDrawServiceResource.CHART_IMMEDIATE_LEADER_AVERAGE,
                                                                                               null, Resources.LuckyDrawServiceResource.CHART_EVALUATED_AS);
    }

    public void SetMediateLeaderAverageChartData(List<QuestionAnswer>? questions)
    {
        this.MediateLeaderAverageChartData = this.BindAssessmentResultGaugeChartServiceModel(questions, Resources.LuckyDrawServiceResource.CHART_MEDIATE_LEADER_AVERAGE,
                                                                                             null, Resources.LuckyDrawServiceResource.CHART_EVALUATED_AS);
    }

    public void SetMultipleChoiceChartData(List<string>? answers, string? questionKey)
    {
        this.MultipleChoiceChartData = this.BindAssessmentResultBarChartServiceModel(answers, questionKey);
    }

    public void SetOtherImmediateLeadersAverageChartData(List<QuestionAnswer>? questions)
    {
        this.OtherImmediateLeadersAverageChartData = this.BindAssessmentResultGaugeChartServiceModel(questions,
                                                                                                     Resources.LuckyDrawServiceResource.CHART_OTHER_IMMEDIATE_LEADER_AVERAGE,
                                                                                                     null, Resources.LuckyDrawServiceResource.CHART_EVALUATED_AS);
    }

    public void SetOtherMediateLeadersAverageChartData(List<QuestionAnswer>? questions)
    {
        this.OtherMediateLeadersAverageChartData = this.BindAssessmentResultGaugeChartServiceModel(questions,
                                                                                                   Resources.LuckyDrawServiceResource.CHART_OTHER_MEDIATE_LEADER_AVERAGE,
                                                                                                   null, Resources.LuckyDrawServiceResource.CHART_EVALUATED_AS);
    }

    public void SetSubordinateAverageChartData(List<QuestionAnswer>? questions)
    {
        this.SubordinateAverageChartData = this.BindAssessmentResultGaugeChartServiceModel(questions, Resources.LuckyDrawServiceResource.CHART_LEADERSHIP_AVERAGE, null,
                                                                                           Resources.LuckyDrawServiceResource.CHART_EVALUATED_AS);
    }
    #endregion Methods

    #region Properties
    public bool AccessedAsManager { get; set; }
    public bool IsMultipleChoiceQuestion { get; set; }
    public bool Measurable { get { return QuestionType == QuestionTypeEnum.Measurable; } }
    public string? Name { get; set; }
    public string? NickName { get; set; }
    public string? Key { get; set; }
    public char? KeyType { get; set; }
    public string? Question { get; set; }
    public QuestionTypeEnum QuestionType { get; set; }
    public string? SelfAssessmentAnswerText { get; set; }
    public decimal? SelfAssessmentAnswerValue
    {
        get { return this.GetPercentualValue(this._selfAssessmentAnswerValue); }
        set
        {
            if (value.HasValue)
                this._selfAssessmentAnswerValue = Math.Abs(value.Value);
            else
                this._selfAssessmentAnswerValue = null;
        }
    }
    public string? SubordinateAnswerText { get; set; }
    public decimal? SubordinateAnswerValue
    {
        get { return this.GetPercentualValue(this._subordinateAnswerValue); }
        set
        {
            if (value.HasValue)
                this._subordinateAnswerValue = Math.Abs(value.Value);
            else
                this._subordinateAnswerValue = null;
        }
    }
    public string? SubordinateAverageAnswerText { get; set; }
    public decimal? SubordinateAverageAnswerValue
    {
        get { return this.GetPercentualValue(this._subordinateAverageAnswerValue); }
        set
        {
            if (value.HasValue)
                this._subordinateAverageAnswerValue = Math.Abs(value.Value);
            else
                this._subordinateAverageAnswerValue = null;
        }
    }
    public string? CoWorker1AnswerText { get; set; }
    public decimal? CoWorker1AnswerValue
    {
        get { return this.GetPercentualValue(this._coWorker1AnswerValue); }
        set
        {
            if (value.HasValue)
                this._coWorker1AnswerValue = Math.Abs(value.Value);
            else
                this._coWorker1AnswerValue = null;
        }
    }
    public string? CoWorker2AnswerText { get; set; }
    public decimal? CoWorker2AnswerValue
    {
        get { return this.GetPercentualValue(this._coWorker2AnswerValue); }
        set
        {
            if (value.HasValue)
                this._coWorker2AnswerValue = Math.Abs(value.Value);
            else
                this._coWorker2AnswerValue = null;
        }
    }
    public string? CoWorker3AnswerText { get; set; }
    public decimal? CoWorker3AnswerValue
    {
        get { return this.GetPercentualValue(this._coWorker3AnswerValue); }
        set
        {
            if (value.HasValue)
                this._coWorker3AnswerValue = Math.Abs(value.Value);
            else
                this._coWorker3AnswerValue = null;
        }
    }
    public string? CoWorkersAverageAnswerText { get; set; }
    public decimal? CoWorkersAverageAnswerValue
    {
        get { return this.GetPercentualValue(this._coWorkersAverageAnswerValue); }
        set
        {
            if (value.HasValue)
                this._coWorkersAverageAnswerValue = Math.Abs(value.Value);
            else
                this._coWorkersAverageAnswerValue = null;
        }
    }
    public string? ExtraCoWorkersAnswerText { get; set; }
    public decimal? ExtraCoWorkersAnswerValue
    {
        get { return this.GetPercentualValue(this._extraCoWorkersAnswerValue); }
        set
        {
            if (value.HasValue)
                this._extraCoWorkersAnswerValue = Math.Abs(value.Value);
            else
                this._extraCoWorkersAnswerValue = null;
        }
    }

    public string? ImmediateLeaderAverageAnswerText { get; set; }
    public decimal? ImmediateLeaderAverageAnswerValue
    {
        get { return this.GetPercentualValue(this._immediateLeaderAverageAnswerValue); }
        set
        {
            if (value.HasValue)
                this._immediateLeaderAverageAnswerValue = Math.Abs(value.Value);
            else
                this._immediateLeaderAverageAnswerValue = null;
        }
    }

    public string? MediateLeaderAverageAnswerText { get; set; }
    public decimal? MediateLeaderAverageAnswerValue
    {
        get { return this.GetPercentualValue(this._mediateLeaderAverageAnswerValue); }
        set
        {
            if (value.HasValue)
                this._mediateLeaderAverageAnswerValue = Math.Abs(value.Value);
            else
                this._mediateLeaderAverageAnswerValue = null;
        }
    }

    public string? OtherImmediateLeadersAverageAnswerText { get; set; }
    public decimal? OtherImmediateLeadersAverageAnswerValue
    {
        get { return this.GetPercentualValue(this._otherImmediateLeadersAverageAnswerValue); }
        set
        {
            if (value.HasValue)
                this._otherImmediateLeadersAverageAnswerValue = Math.Abs(value.Value);
            else
                this._otherImmediateLeadersAverageAnswerValue = null;
        }
    }

    public string? OtherMediateLeadersAverageAnswerText { get; set; }
    public decimal? OtherMediateLeadersAverageAnswerValue
    {
        get { return this.GetPercentualValue(this._otherMediateLeadersAverageAnswerValue); }
        set
        {
            if (value.HasValue)
                this._otherMediateLeadersAverageAnswerValue = Math.Abs(value.Value);
            else
                this._otherMediateLeadersAverageAnswerValue = null;
        }
    }

    public AssessmentResultBarChartServiceModel? MultipleChoiceChartData { get; set; }
    public AssessmentResultGaugeChartServiceModel? CoWorkersAverageChartData { get; set; }
    public AssessmentResultGaugeChartServiceModel? ExtraCoWorkersChartData { get; set; }
    public AssessmentResultGaugeChartServiceModel? ImmediateLeaderAverageChartData { get; set; }
    public AssessmentResultGaugeChartServiceModel? MediateLeaderAverageChartData { get; set; }
    public AssessmentResultGaugeChartServiceModel? OtherImmediateLeadersAverageChartData { get; set; }
    public AssessmentResultGaugeChartServiceModel? OtherMediateLeadersAverageChartData { get; set; }
    public AssessmentResultGaugeChartServiceModel? SubordinateAverageChartData { get; set; }
    #endregion Properties
}
