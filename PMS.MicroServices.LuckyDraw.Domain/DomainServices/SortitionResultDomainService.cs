using PMS.Core.Infra.CrossCutting.Cryptography.ExtensionMethods;
using PMS.Core.Infra.CrossCutting.Utilities;
using PMS.MicroServices.LuckyDraw.BoundedContexts.SharedKernel.Enums;
using PMS.MicroServices.LuckyDraw.Domain.Constants;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.Enums;
using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices;

public class SortitionResultDomainService
    : ISortitionResultDomainService
{
    #region Constructors
    public SortitionResultDomainService(IAssessmentResultDomainService assessmentResultDomainService, IAuthorDomainService authorDomainService,
                                        ICoWorkerDomainService coWorkerDomainService, IGeneralQuestionDomainService generalQuestionDomainService,
                                        IImmediateLeaderDomainService immediateLeaderDomainService, ILeadershipQuestionDomainService leadershipQuestionDomainService,
                                        IManagementQuestionDomainService managementQuestionDomainService, IManagementTeamDomainService managementTeamDomainService,
                                        IMediateLeaderDomainService mediateLeaderDomainService, IQuestionDomainService questionDomainService,
                                        ISelfAssessmentDomainService selfAssessmentDomainService, ISubordinateDomainService subordinateDomainService)
    {
        this._assessmentResultDomainService = assessmentResultDomainService;
        this._authorDomainService = authorDomainService;
        this._coWorkerDomainService = coWorkerDomainService;
        this._generalQuestionDomainService = generalQuestionDomainService;
        this._immediateLeaderDomainService = immediateLeaderDomainService;
        this._leadershipQuestionDomainService = leadershipQuestionDomainService;
        this._managementQuestionDomainService = managementQuestionDomainService;
        this._managementTeamDomainService = managementTeamDomainService;
        this._mediateLeaderDomainService = mediateLeaderDomainService;
        this._questionDomainService = questionDomainService;
        this._selfAssessmentDomainService = selfAssessmentDomainService;
        this._subordinateDomainService = subordinateDomainService;
    }
    #endregion Constructors

    #region Constants
    const string CoWorkerTypeA = "A", CoWorkerTypeB = "B", CoWorkerTypeC = "C", CoWorkerTypeX = "X";
    public const string CoWorkerTypeI = "I", CoWorkerTypeM = "M", CoWorkerTypeP = "P", CoWorkerTypeS = "S";
    #endregion Constants

    #region Fields
    readonly IAuthorDomainService _authorDomainService;
    readonly IAssessmentResultDomainService _assessmentResultDomainService;
    readonly ICoWorkerDomainService _coWorkerDomainService;
    readonly IGeneralQuestionDomainService _generalQuestionDomainService;
    readonly IImmediateLeaderDomainService _immediateLeaderDomainService;
    readonly ILeadershipQuestionDomainService _leadershipQuestionDomainService;
    readonly IManagementQuestionDomainService _managementQuestionDomainService;
    readonly IManagementTeamDomainService _managementTeamDomainService;
    readonly IMediateLeaderDomainService _mediateLeaderDomainService;
    readonly IQuestionDomainService _questionDomainService;
    readonly ISelfAssessmentDomainService _selfAssessmentDomainService;
    readonly ISubordinateDomainService _subordinateDomainService;
    #endregion Fields

    #region Methods
    private void AppendCoWorkersAverageResult(GeneralAssessment generalAssessment, List<CoWorker> coWorkers)
    {
        if ((generalAssessment != null) && (!string.IsNullOrWhiteSpace(generalAssessment.Key)))
        {
            int average = 0;
            decimal accumulator = 0; int counter = 0;
            if (coWorkers?.Any() ?? false)
            {
                var dictionaryQuestions = new Dictionary<QuestionAnswer, int>();
                foreach (var currentCoWorker in coWorkers)
                {
                    var selectedCurrentCoWorkerQuestion = currentCoWorker.QuestionsAndAnswers.FirstOrDefault(q => q.Key == generalAssessment.Key);
                    if (selectedCurrentCoWorkerQuestion != null)
                    {
                        selectedCurrentCoWorkerQuestion.QuestionType = generalAssessment.QuestionType;
                        if (selectedCurrentCoWorkerQuestion.IsMeasurableQuestion)
                        {
                            var currentItemResult = currentCoWorker.GetItemResult(selectedCurrentCoWorkerQuestion);
                            if (!dictionaryQuestions.ContainsKey(selectedCurrentCoWorkerQuestion))
                                dictionaryQuestions.Add(selectedCurrentCoWorkerQuestion, currentItemResult);

                            accumulator += Math.Abs(currentItemResult);
                            counter += 1;
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(selectedCurrentCoWorkerQuestion.Answer))
                            {
                                if (selectedCurrentCoWorkerQuestion.IsMultipleChoiceQuestion)
                                    generalAssessment.AddMultipleChoiceQuestion(selectedCurrentCoWorkerQuestion);
                            }
                        }
                    }
                }
                generalAssessment.CoWorkersAverageData = dictionaryQuestions.Keys.ToList();

                if (counter == 0)
                    counter = 1;
                decimal roundedAverage = Math.Round((accumulator / counter), 2);
                average = Convert.ToInt32(roundedAverage);
            }

            var coWorkersAverageQuestion = new QuestionAnswer()
            {
                Key = (generalAssessment.Key ?? string.Empty),
                KeyType = generalAssessment.KeyType,
                Question = (generalAssessment.SelfAssessmentQuestion?.Question ?? string.Empty),
                QuestionType = generalAssessment.QuestionType
            };
            var agreementAndSatisfaction = EnumUtility.GetEnum<AgreementAndSatisfactionEnum>(Enum.GetName(typeof(AgreementAndSatisfactionEnum), average));
            if (coWorkersAverageQuestion.IsMeasurableQuestion)
            {
                coWorkersAverageQuestion.Answer = EnumUtility.GetLocalizedDescription<AgreementAndSatisfactionEnum>(agreementAndSatisfaction.ToString());
                coWorkersAverageQuestion.Value = agreementAndSatisfaction;
            }

            generalAssessment.CoWorkersAverageQuestion = coWorkersAverageQuestion;
        }
    }

    private void AppendCoWorkersResult(GeneralAssessment generalAssessment, CoWorker? coWorker)
    {
        if ((generalAssessment != null) && (coWorker != null) && (!string.IsNullOrWhiteSpace(generalAssessment.Key)))
        {
            QuestionAnswer? correspondingQuestion = coWorker.QuestionsAndAnswers.FirstOrDefault(q => q.Key == generalAssessment.Key);
            if (correspondingQuestion != null)
            {
                switch (coWorker.CoWorkerType)
                {
                    case CoWorkerTypeA:
                        generalAssessment.CoWorker1Question = correspondingQuestion;
                        break;
                    case CoWorkerTypeB:
                        generalAssessment.CoWorker2Question = correspondingQuestion;
                        break;
                    case CoWorkerTypeC:
                        generalAssessment.CoWorker3Question = correspondingQuestion;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void AppendCoWorkersResult(GeneralAssessment generalAssessment, List<CoWorker> coWorkers)
    {
        if ((generalAssessment != null) && (coWorkers?.Any() ?? false))
        {
            this.AppendCoWorkersResult(generalAssessment, coWorkers.FirstOrDefault(c => c.CoWorkerType == CoWorkerTypeA));
            this.AppendCoWorkersResult(generalAssessment, coWorkers.FirstOrDefault(c => c.CoWorkerType == CoWorkerTypeB));
            this.AppendCoWorkersResult(generalAssessment, coWorkers.FirstOrDefault(c => c.CoWorkerType == CoWorkerTypeC));

            var extraCoWorkers = coWorkers.Where(e => (e.CoWorkerType ?? string.Empty).ToUpper() == CoWorkerTypeX).ToList();
            this.AppendExtraCoWorkersResult(generalAssessment, extraCoWorkers);
            this.AppendCoWorkersAverageResult(generalAssessment, coWorkers);
        }
    }

    private List<GeneralAssessment> AppendEvaluatedPersonQuestions(List<Question> questions, AssessmentResult requestingAssessmentResult,
                                                                   AssessmentResult evaluatedPersonAssessmentResult, string name, string? nickname)
    {
        List<GeneralAssessment> generalAssessments;
        if ((questions?.Any() ?? false) && (requestingAssessmentResult != null) && (evaluatedPersonAssessmentResult != null))
        {
            int listLength = 42;
            if (evaluatedPersonAssessmentResult.HasMediateSubordinates)
                listLength += 42;
            if (evaluatedPersonAssessmentResult.HasImmediateSubordinates)
                listLength += 42;

            generalAssessments = new List<GeneralAssessment>(listLength);
            var generalQuestions = questions.Where(q => q.PurposeType == PurposeTypeEnum.General).OrderBy(o => o.Abbreviation).ToList();
            foreach (var currentQuestion in generalQuestions)
                generalAssessments.Add(this.AppendGeneralAssessmentByQuestion(currentQuestion, LuckyDrawDomainConstants.NormalEvaluatedPersonChar, name, nickname,
                                                                              requestingAssessmentResult.BelongsToManagementTeam));
            if (evaluatedPersonAssessmentResult.BelongsToManagementTeam)
            {
                var mediateLeaderQuestions = questions.Where(q => q.PurposeType == PurposeTypeEnum.MediateLeadership).OrderBy(o => o.Abbreviation).ToList();
                if (evaluatedPersonAssessmentResult.HasMediateSubordinates)
                {
                    foreach (var currentMediateLeaderQuestion in mediateLeaderQuestions)
                        generalAssessments.Add(this.AppendGeneralAssessmentByQuestion(currentMediateLeaderQuestion,
                                                                                      LuckyDrawDomainConstants.MediateLeaderEvaluatedPersonChar, name, nickname,
                                                                                      requestingAssessmentResult.BelongsToManagementTeam));
                }
                var immediateLeaderQuestions = questions.Where(q => q.PurposeType == PurposeTypeEnum.ImmediateLeadership).OrderBy(o => o.Abbreviation).ToList();
                if (evaluatedPersonAssessmentResult.HasImmediateSubordinates)
                {
                    foreach (var currentImmediateLeaderQuestion in immediateLeaderQuestions)
                        generalAssessments.Add(this.AppendGeneralAssessmentByQuestion(currentImmediateLeaderQuestion,
                                                                                      LuckyDrawDomainConstants.ImmediateLeaderEvaluatedPersonChar, name, nickname,
                                                                                      requestingAssessmentResult.BelongsToManagementTeam));
                }
            }
        }
        else
            generalAssessments = new List<GeneralAssessment>(0);
        return generalAssessments;
    }

    private GeneralAssessment AppendGeneralAssessmentByQuestion(Question question, char keyType, string name, string? nickname, bool belongsToManagementTeam)
    {
        return new GeneralAssessment()
        {
            Key  = question.Abbreviation,
            KeyType = keyType,
            Question = question.SelfAssessmentContent ?? question.Content,
            QuestionType = question.QuestionType,
            Name = name,
            NickName = nickname ?? string.Empty,
            AccessedAsManager = belongsToManagementTeam
        };
    }

    private void AppendExtraCoWorkersResult(GeneralAssessment generalAssessment, List<CoWorker> coWorkers)
    {
        if ((generalAssessment != null) && (!string.IsNullOrWhiteSpace(generalAssessment.Key)))
        {
            int average = 0;
            decimal accumulator = 0; int counter = 0;
            if (coWorkers?.Any() ?? false)
            {
                var dictionaryQuestions = new Dictionary<QuestionAnswer, int>();
                foreach (var currentCoWorker in coWorkers)
                {
                    var selectedCurrentCoWorkerQuestion = currentCoWorker.QuestionsAndAnswers.FirstOrDefault(q => q.Key == generalAssessment.Key);
                    if (selectedCurrentCoWorkerQuestion != null)
                    {
                        selectedCurrentCoWorkerQuestion.QuestionType = generalAssessment.QuestionType;
                        if (selectedCurrentCoWorkerQuestion.IsMeasurableQuestion)
                        {
                            var currentItemResult = currentCoWorker.GetItemResult(selectedCurrentCoWorkerQuestion);
                            if (!dictionaryQuestions.ContainsKey(selectedCurrentCoWorkerQuestion))
                                dictionaryQuestions.Add(selectedCurrentCoWorkerQuestion, currentItemResult);

                            accumulator += Math.Abs(currentItemResult);
                            counter += 1;
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(selectedCurrentCoWorkerQuestion.Answer))
                            {
                                if (selectedCurrentCoWorkerQuestion.IsFreeWritingQuestion)
                                    generalAssessment.AddFreeWritingQuestion(selectedCurrentCoWorkerQuestion);
                            }
                        }
                    }
                }
                generalAssessment.ExtraCoWorkersData = dictionaryQuestions.Keys.ToList();

                if (counter == 0)
                    counter = 1;
                decimal roundedAverage = Math.Round((accumulator / counter), 2);
                average = Convert.ToInt32(roundedAverage);
            }

            var extraCoWorkersQuestion = new QuestionAnswer()
            {
                Key = (generalAssessment.Key ?? string.Empty),
                KeyType = generalAssessment.KeyType,
                Question = (generalAssessment.SelfAssessmentQuestion?.Question ?? string.Empty),
                QuestionType = generalAssessment.QuestionType
            };
            var agreementAndSatisfaction = EnumUtility.GetEnum<AgreementAndSatisfactionEnum>(Enum.GetName(typeof(AgreementAndSatisfactionEnum), average));
            if (extraCoWorkersQuestion.IsMeasurableQuestion)
            {
                extraCoWorkersQuestion.Answer = EnumUtility.GetLocalizedDescription<AgreementAndSatisfactionEnum>(agreementAndSatisfaction.ToString());
                extraCoWorkersQuestion.Value = agreementAndSatisfaction;
            }
            if (extraCoWorkersQuestion.IsFreeWritingQuestion)
                extraCoWorkersQuestion.Answer = generalAssessment.ToFreeWritingHtmlCode();

            generalAssessment.ExtraCoWorkersQuestion = extraCoWorkersQuestion;
        }
    }

    private void AppendSelfAssessmentResult(GeneralAssessment generalAssessment, SelfAssessment? selfAssessment)
    {
        if ((generalAssessment != null) && (selfAssessment != null))
        {
            var correspondingQuestion = selfAssessment.QuestionsAndAnswers.FirstOrDefault(q => q.Key == generalAssessment.Key);
            if (correspondingQuestion != null)
            {
                correspondingQuestion.QuestionType = generalAssessment.QuestionType;
                generalAssessment.SelfAssessmentQuestion = correspondingQuestion;
                generalAssessment.Key = generalAssessment.SelfAssessmentQuestion.Key;
                generalAssessment.Question = generalAssessment.SelfAssessmentQuestion.Question;

                if (!correspondingQuestion.IsMeasurableQuestion)
                {
                    if (!string.IsNullOrWhiteSpace(correspondingQuestion.Answer))
                    {
                        if (generalAssessment.IsFreeWritingQuestion)
                            generalAssessment.AddFreeWritingQuestion(correspondingQuestion);
                        if (generalAssessment.IsMultipleChoiceQuestion)
                            generalAssessment.AddMultipleChoiceQuestion(correspondingQuestion);
                    }
                }
            }
        }
    }

    private void AppendSubordinateAverageResult(GeneralAssessment generalAssessment, List<Subordinate> subordinates)
    {
        if ((generalAssessment != null) && (!string.IsNullOrWhiteSpace(generalAssessment.Key)))
        {
            int average = 0;
            decimal accumulator = 0; int counter = 0;
            if (subordinates?.Any() ?? false)
            {
                var dictionaryQuestions = new Dictionary<QuestionAnswer, int>();
                foreach (var currentSubordinate in subordinates)
                {
                    var selectedCurrentSubordinateQuestion = currentSubordinate.QuestionsAndAnswers.FirstOrDefault(q => q.Key == generalAssessment.Key);
                    if (selectedCurrentSubordinateQuestion != null)
                    {
                        selectedCurrentSubordinateQuestion.QuestionType = generalAssessment.QuestionType;
                        if (selectedCurrentSubordinateQuestion.IsMeasurableQuestion)
                        {
                            var currentItemResult = currentSubordinate.GetItemResult(selectedCurrentSubordinateQuestion);
                            if (!dictionaryQuestions.ContainsKey(selectedCurrentSubordinateQuestion))
                                dictionaryQuestions.Add(selectedCurrentSubordinateQuestion, currentItemResult);

                            accumulator += Math.Abs(currentItemResult);
                            counter += 1;
                        }
                    }
                }
                generalAssessment.SubordinateAverageData = dictionaryQuestions.Keys.ToList();

                if (counter == 0)
                    counter = 1;
                decimal roundedAverage = Math.Round((accumulator / counter), 2);
                average = Convert.ToInt32(roundedAverage);
            }

            var subordinateAverageQuestion = new QuestionAnswer()
            {
                Key = (generalAssessment.Key ?? string.Empty),
                KeyType = generalAssessment.KeyType,
                Question = (generalAssessment.SelfAssessmentQuestion?.Question ?? string.Empty),
                QuestionType = generalAssessment.QuestionType
            };
            var agreementAndSatisfaction = EnumUtility.GetEnum<AgreementAndSatisfactionEnum>(Enum.GetName(typeof(AgreementAndSatisfactionEnum), average));
            if (subordinateAverageQuestion.IsMeasurableQuestion)
            {
                subordinateAverageQuestion.Answer = EnumUtility.GetLocalizedDescription<AgreementAndSatisfactionEnum>(agreementAndSatisfaction.ToString());
                subordinateAverageQuestion.Value = agreementAndSatisfaction;
            }

            generalAssessment.SubordinateAverageQuestion = subordinateAverageQuestion;
        }
    }

    private void AppendSubordinateResult(GeneralAssessment generalAssessment, Subordinate? subordinate, string? questionKey)
    {
        if ((generalAssessment != null) && (subordinate != null) && (!string.IsNullOrWhiteSpace(questionKey)))
        {
            QuestionAnswer? correspondingQuestion = subordinate.QuestionsAndAnswers.FirstOrDefault(q => q.Key == questionKey);
            if (correspondingQuestion != null)
                generalAssessment.SubordinateQuestion = correspondingQuestion;
        }
    }

    private void GetQueryingNames(AssessmentResult assessmentResult, string personName, string personNickname, out string name, out string nickname,
                                  string? evaluatedPersonName = null)
    {
        string? na, ni;
        if (assessmentResult != null)
        {
            if ((assessmentResult.BelongsToManagementTeam) && (!string.IsNullOrWhiteSpace(evaluatedPersonName)))
            {
                na = evaluatedPersonName;
                ni = string.Empty;
            }
            else
            {
                na = assessmentResult.Name;
                ni = personNickname;
            }
        }
        else
        {
            na = personName;
            ni = personNickname;
        }
        name = na;
        nickname = ni;
    }

    private void LoadManagementData(AssessmentResult? assessmentResult, List<LeadershipQuestion> leadershipQuestions, out List<ImmediateLeader> immediateLeaders,
                                    out List<ImmediateLeader> otherImmediateLeaders, out List<MediateLeader> mediateLeaders,
                                    out List<MediateLeader> otherMediateLeaders, ref int count)
    {
        List<ImmediateLeader> listOfImmediateLeaders = default!, listOfOtherImmediateLeaders = default!;
        List<MediateLeader> listOfMediateLeaders = default!, listOfOtherMediateLeaders = default!;
        if ((assessmentResult != null) && assessmentResult.BelongsToManagementTeam)
        {
            var lowerLeader = assessmentResult.Name.Trim().ToLower();
            var otherLeaders = this._authorDomainService.GetAllAsync().GetAwaiter().GetResult();
            var currentLeader = otherLeaders.FirstOrDefault(l => (l.Name ?? string.Empty).Trim().ToLower() == lowerLeader);
            if (currentLeader != null)
            {
                otherLeaders = otherLeaders.Where(l => (l.HasImmediateSubordinates || l.HasMediateSubordinates)).ToList();

                var otherImmediateLeaderNames = otherLeaders.Where(i => i.HasImmediateSubordinates && (!string.IsNullOrEmpty(i.Name)))
                                                            .Select(l => (l.Name ?? string.Empty).Trim().ToLower())
                                                            .ToArray();
                var otherMediateLeaderNames = otherLeaders.Where(i => i.HasMediateSubordinates && (!string.IsNullOrEmpty(i.Name)))
                                                          .Select(l => (l.Name ?? string.Empty).Trim().ToLower())
                                                          .ToArray();

                if (assessmentResult.HasImmediateSubordinates)
                {
                    this._immediateLeaderDomainService.SetLeadershipQuestions(leadershipQuestions);
                    listOfImmediateLeaders = this._immediateLeaderDomainService.FindAsync(i => (i.Leader ?? string.Empty).Trim().ToLower() == lowerLeader)
                                                                               .GetAwaiter().GetResult();
                    listOfOtherImmediateLeaders = this._immediateLeaderDomainService.FindAsync(i => otherImmediateLeaderNames.Contains((i.Leader ?? string.Empty).Trim().ToLower()))
                                                                                    .GetAwaiter().GetResult();
                    count += leadershipQuestions.Count;
                }

                if (assessmentResult.HasMediateSubordinates)
                {
                    this._mediateLeaderDomainService.SetLeadershipQuestions(leadershipQuestions);
                    listOfMediateLeaders = this._mediateLeaderDomainService.FindAsync(i => (i.Leader ?? string.Empty).Trim().ToLower() == lowerLeader)
                                                                           .GetAwaiter().GetResult();
                    listOfOtherMediateLeaders = this._mediateLeaderDomainService.FindAsync(i => otherMediateLeaderNames.Contains((i.Leader ?? string.Empty).Trim().ToLower()))
                                                                                .GetAwaiter().GetResult();
                    count += leadershipQuestions.Count;
                }
            }
        }
        immediateLeaders = listOfImmediateLeaders;
        otherImmediateLeaders = listOfOtherImmediateLeaders;
        mediateLeaders = listOfMediateLeaders;
        otherMediateLeaders = listOfOtherMediateLeaders;
    }

    private void RegisterImmediateMeasurableToDictionary(Dictionary<QuestionAnswer, int> dictionaryQuestions, ImmediateLeader immediateLeader,
                                                         QuestionAnswer? questionWithAnswer)
    {
        if ((dictionaryQuestions != null) && (immediateLeader != null))
        {
            if ((questionWithAnswer != null) && (!dictionaryQuestions.ContainsKey(questionWithAnswer)))
                dictionaryQuestions.Add(questionWithAnswer, immediateLeader.GetItemResult(questionWithAnswer));
        }
    }

    private void RegisterMediateMeasurableToDictionary(Dictionary<QuestionAnswer, int> dictionaryQuestions, MediateLeader mediateLeader,
                                                       QuestionAnswer? questionWithAnswer)
    {
        if ((dictionaryQuestions != null) && (mediateLeader != null))
        {
            if ((questionWithAnswer != null) && (!dictionaryQuestions.ContainsKey(questionWithAnswer)))
                dictionaryQuestions.Add(questionWithAnswer, mediateLeader.GetItemResult(questionWithAnswer));
        }
    }

    private void ToResult(List<GeneralAssessment> generalAssessments, SelfAssessment? selfAssessment, List<CoWorker> coWorkers, Subordinate? subordinate,
                          List<Subordinate> subordinates)
    {
        if (generalAssessments?.Any() ?? false)
        {
            foreach (var currentGeneralAssessment in generalAssessments)
            {
                if ((currentGeneralAssessment != null) && (!string.IsNullOrWhiteSpace(currentGeneralAssessment.Key)))
                {
                    this.AppendSelfAssessmentResult(currentGeneralAssessment, selfAssessment);
                    this.AppendCoWorkersResult(currentGeneralAssessment, coWorkers);
                    this.AppendSubordinateResult(currentGeneralAssessment, subordinate, currentGeneralAssessment.Key);
                    this.AppendSubordinateAverageResult(currentGeneralAssessment, subordinates);
                }
            }
        }
    }

    private void ToResultImmediateLeader(string nickname, string name, bool belongsToManagementTeam, List<GeneralAssessment> generalAssessments,
                                         List<Question> immediateLeaderQuestions, List<ImmediateLeader> immediateLeaders,
                                         List<ImmediateLeader> otherImmediateLeaders)
    {
        if ((generalAssessments != null) && belongsToManagementTeam)
        {
            if (immediateLeaderQuestions?.Any() ?? false)
            {
                var immediateLeaderQuestionKeys = immediateLeaderQuestions.Where(e => (!string.IsNullOrEmpty(e.Abbreviation)) && 
                                                                                      (e.PurposeType == PurposeTypeEnum.ImmediateLeadership))
                                                                          .Select(i => (i.Abbreviation ?? string.Empty).Trim())
                                                                          .ToList();
                immediateLeaderQuestionKeys.Sort();

                foreach (var currentImmediateLeaderQuestionKey in immediateLeaderQuestionKeys)
                {
                    if (!string.IsNullOrWhiteSpace(currentImmediateLeaderQuestionKey))
                    {
                        var currentImmediateLeaderQuestionByKey = immediateLeaderQuestions.FirstOrDefault(q => q.Abbreviation == currentImmediateLeaderQuestionKey);
                        var currentGeneralAssessment = generalAssessments.FirstOrDefault(q => q.Key == currentImmediateLeaderQuestionKey);
                        if (currentGeneralAssessment == null)
                        {
                            currentGeneralAssessment = new GeneralAssessment()
                            {
                                NickName = nickname,
                                Name = name,
                                AccessedAsManager = belongsToManagementTeam,
                                Key = currentImmediateLeaderQuestionKey,
                                KeyType = LuckyDrawDomainConstants.ImmediateLeaderEvaluatedPersonChar,
                                Question = currentImmediateLeaderQuestionByKey?.Content?.Trim(),
                                QuestionType = currentImmediateLeaderQuestionByKey?.QuestionType ?? QuestionTypeEnum.NotSet
                            };
                            generalAssessments.Add(currentGeneralAssessment);
                        }

                        Dictionary<QuestionAnswer, int> dictionaryQuestions = new Dictionary<QuestionAnswer, int>();
                        int averageImmediate = 0;
                        decimal accumulatorImmediate = 0; int counterImmediate = 0;
                        var questionsAndAnswersImmediate = new List<QuestionAnswer>();

                        if (immediateLeaders?.Any() ?? false)
                        {
                            foreach (var currentImmediateLeader in immediateLeaders)
                            {
                                var currentImmediateLeaderQuestion = currentImmediateLeader.QuestionsAndAnswers.FirstOrDefault(q => q.Key == currentImmediateLeaderQuestionKey);
                                if (currentImmediateLeaderQuestion != null)
                                {
                                    currentImmediateLeaderQuestion.QuestionType = currentGeneralAssessment.QuestionType;
                                    if (currentImmediateLeaderQuestion.IsMeasurableQuestion)
                                    {
                                        accumulatorImmediate += Math.Abs(currentImmediateLeader.GetItemResult(currentImmediateLeaderQuestion));
                                        counterImmediate += 1;
                                        this.RegisterImmediateMeasurableToDictionary(dictionaryQuestions, currentImmediateLeader, currentImmediateLeaderQuestion);
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrWhiteSpace(currentImmediateLeaderQuestion.Answer))
                                        {
                                            if (currentGeneralAssessment.IsFreeWritingQuestion)
                                                currentGeneralAssessment.AddFreeWritingQuestion(currentImmediateLeaderQuestion);
                                            if (currentGeneralAssessment.IsMultipleChoiceQuestion)
                                                currentGeneralAssessment.AddMultipleChoiceQuestion(currentImmediateLeaderQuestion);
                                        }
                                    }
                                }
                            }
                        }
                        currentGeneralAssessment.ImmediateLeaderAverageData = dictionaryQuestions.Keys.ToList();

                        if (counterImmediate == 0)
                            counterImmediate = 1;
                        decimal roundedAverageImmediate = Math.Round((accumulatorImmediate / counterImmediate), 2);
                        averageImmediate = Convert.ToInt32(roundedAverageImmediate);

                        var immediateLeaderAverageQuestion = new QuestionAnswer()
                        {
                            Key = currentGeneralAssessment.Key ?? string.Empty,
                            KeyType = currentGeneralAssessment.KeyType,
                            Question = currentGeneralAssessment.Question ?? string.Empty,
                            QuestionType = currentGeneralAssessment.QuestionType
                        };
                        var agreementAndSatisfaction = EnumUtility.GetEnum<AgreementAndSatisfactionEnum>(Enum.GetName(typeof(AgreementAndSatisfactionEnum), averageImmediate));
                        if (immediateLeaderAverageQuestion.IsMeasurableQuestion)
                        {
                            immediateLeaderAverageQuestion.Answer = EnumUtility.GetLocalizedDescription<AgreementAndSatisfactionEnum>(agreementAndSatisfaction.ToString());
                            immediateLeaderAverageQuestion.Value = agreementAndSatisfaction;
                        }
                        if (immediateLeaderAverageQuestion.IsFreeWritingQuestion)
                            immediateLeaderAverageQuestion.Answer = currentGeneralAssessment.ToFreeWritingHtmlCode();

                        currentGeneralAssessment.ImmediateLeaderAverageQuestion = immediateLeaderAverageQuestion;
                        this.ToResultOtherImmediateLeaders(currentGeneralAssessment, currentImmediateLeaderQuestionKey, otherImmediateLeaders);
                    }
                }
            }
        }
    }

    private void ToResultOtherImmediateLeaders(GeneralAssessment generalAssessment, string questionKey, List<ImmediateLeader> otherImmediateLeaders)
    {
        if ((generalAssessment != null) && (!string.IsNullOrWhiteSpace(questionKey)) && (otherImmediateLeaders?.Any() ?? false))
        {
            Dictionary<QuestionAnswer, int> dictionaryQuestions = new Dictionary<QuestionAnswer, int>();
            int averageOtherImmediate = 0;
            decimal accumulatorOtherImmediate = 0; int counterOtherImmediate = 0;
            var questionsAndAnswersOtherImmediate = new List<QuestionAnswer>();
            foreach (var currentOtherImmediateLeader in otherImmediateLeaders)
            {
                var currentOtherImmediateLeaderQuestion = currentOtherImmediateLeader.QuestionsAndAnswers.FirstOrDefault(q => q.Key == questionKey);
                if (currentOtherImmediateLeaderQuestion != null)
                {
                    currentOtherImmediateLeaderQuestion.QuestionType = generalAssessment.QuestionType;
                    if (currentOtherImmediateLeaderQuestion.IsMeasurableQuestion)
                    {
                        accumulatorOtherImmediate += Math.Abs(currentOtherImmediateLeader.GetItemResult(currentOtherImmediateLeaderQuestion));
                        counterOtherImmediate += 1;
                        this.RegisterImmediateMeasurableToDictionary(dictionaryQuestions, currentOtherImmediateLeader, currentOtherImmediateLeaderQuestion);
                    }
                }
            }
            generalAssessment.OtherImmediateLeadersAverageData = dictionaryQuestions.Keys.ToList();

            if (counterOtherImmediate == 0)
                counterOtherImmediate = 1;
            decimal roundedAverageOtherImmediate = Math.Round((accumulatorOtherImmediate / counterOtherImmediate), 2);
            averageOtherImmediate = Convert.ToInt32(roundedAverageOtherImmediate);

            var otherImmediateLeaderAverageQuestion = new QuestionAnswer()
            {
                Key = generalAssessment.Key ?? string.Empty,
                KeyType = generalAssessment.KeyType,
                Question = generalAssessment.Question ?? string.Empty,
                QuestionType = generalAssessment.QuestionType
            };
            var agreementAndSatisfaction = EnumUtility.GetEnum<AgreementAndSatisfactionEnum>(Enum.GetName(typeof(AgreementAndSatisfactionEnum), averageOtherImmediate));
            if (otherImmediateLeaderAverageQuestion.IsMeasurableQuestion)
            {
                otherImmediateLeaderAverageQuestion.Answer = EnumUtility.GetLocalizedDescription<AgreementAndSatisfactionEnum>(agreementAndSatisfaction.ToString());
                otherImmediateLeaderAverageQuestion.Value = agreementAndSatisfaction;
            }

            generalAssessment.OtherImmediateLeadersAverageQuestion = otherImmediateLeaderAverageQuestion;
        }
    }

    private void ToResultMediateLeader(string nickname, string name, bool belongsToManagementTeam, List<GeneralAssessment> generalAssessments,
                                       List<Question> mediateLeaderQuestions, List<MediateLeader> mediateLeaders, List<MediateLeader> otherMediateLeaders)
    {
        if ((generalAssessments != null) && belongsToManagementTeam)
        {
            if (mediateLeaderQuestions?.Any() ?? false)
            {
                var mediateLeaderQuestionKeys = mediateLeaderQuestions.Where(e => (!string.IsNullOrEmpty(e.Abbreviation)) &&
                                                                                  (e.PurposeType == PurposeTypeEnum.MediateLeadership))
                                                                      .Select(i => (i.Abbreviation ?? string.Empty).Trim())
                                                                      .ToList();
                mediateLeaderQuestionKeys.Sort();

                foreach (var currentMediateLeaderQuestionKey in mediateLeaderQuestionKeys)
                {
                    if (!string.IsNullOrWhiteSpace(currentMediateLeaderQuestionKey))
                    {
                        var currentMediateLeaderQuestionByKey = mediateLeaderQuestions.FirstOrDefault(q => q.Abbreviation == currentMediateLeaderQuestionKey);
                        var currentGeneralAssessment = generalAssessments.FirstOrDefault(q => q.Key == currentMediateLeaderQuestionKey);
                        if (currentGeneralAssessment == null)
                        {
                            currentGeneralAssessment = new GeneralAssessment()
                            {
                                NickName = nickname,
                                Name = name,
                                AccessedAsManager = belongsToManagementTeam,
                                Key = currentMediateLeaderQuestionKey,
                                KeyType = LuckyDrawDomainConstants.MediateLeaderEvaluatedPersonChar,
                                Question = currentMediateLeaderQuestionByKey?.Content?.Trim(),
                                QuestionType = currentMediateLeaderQuestionByKey?.QuestionType ?? QuestionTypeEnum.NotSet
                            };
                            generalAssessments.Add(currentGeneralAssessment);
                        }

                        Dictionary<QuestionAnswer, int> dictionaryQuestions = new Dictionary<QuestionAnswer, int>();
                        int averageMediate = 0;
                        decimal accumulatorMediate = 0; int counterMediate = 0;
                        var questionsAndAnswersMediate = new List<QuestionAnswer>();

                        if (mediateLeaders?.Any() ?? false)
                        {
                            foreach (var currentMediateLeader in mediateLeaders)
                            {
                                var currentMediateLeaderQuestion = currentMediateLeader.QuestionsAndAnswers.FirstOrDefault(q => q.Key == currentMediateLeaderQuestionKey);
                                if (currentMediateLeaderQuestion != null)
                                {
                                    currentMediateLeaderQuestion.QuestionType = currentGeneralAssessment.QuestionType;
                                    if (currentMediateLeaderQuestion.IsMeasurableQuestion)
                                    {
                                        accumulatorMediate += Math.Abs(currentMediateLeader.GetItemResult(currentMediateLeaderQuestion));
                                        counterMediate += 1;
                                        this.RegisterMediateMeasurableToDictionary(dictionaryQuestions, currentMediateLeader, currentMediateLeaderQuestion);
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrWhiteSpace(currentMediateLeaderQuestion.Answer))
                                        {
                                            if (currentGeneralAssessment.IsFreeWritingQuestion)
                                                currentGeneralAssessment.AddFreeWritingQuestion(currentMediateLeaderQuestion);
                                            if (currentGeneralAssessment.IsMultipleChoiceQuestion)
                                                currentGeneralAssessment.AddMultipleChoiceQuestion(currentMediateLeaderQuestion);
                                        }
                                    }
                                }
                            }
                        }

                        currentGeneralAssessment.MediateLeaderAverageData = dictionaryQuestions.Keys.ToList();

                        if (counterMediate == 0)
                            counterMediate = 1;
                        decimal roundedAverageMediate = Math.Round((accumulatorMediate / counterMediate), 2);
                        averageMediate = Convert.ToInt32(roundedAverageMediate);

                        var mediateLeaderAverageQuestion = new QuestionAnswer()
                        {
                            Key = currentGeneralAssessment.Key ?? string.Empty,
                            KeyType = currentGeneralAssessment.KeyType,
                            Question = currentGeneralAssessment.Question ?? string.Empty,
                            QuestionType = currentGeneralAssessment.QuestionType
                        };
                        var agreementAndSatisfaction = EnumUtility.GetEnum<AgreementAndSatisfactionEnum>(Enum.GetName(typeof(AgreementAndSatisfactionEnum), averageMediate));
                        if (mediateLeaderAverageQuestion.IsMeasurableQuestion)
                        {
                            mediateLeaderAverageQuestion.Answer = EnumUtility.GetLocalizedDescription<AgreementAndSatisfactionEnum>(agreementAndSatisfaction.ToString());
                            mediateLeaderAverageQuestion.Value = agreementAndSatisfaction;
                        }
                        if (mediateLeaderAverageQuestion.IsFreeWritingQuestion)
                            mediateLeaderAverageQuestion.Answer = currentGeneralAssessment.ToFreeWritingHtmlCode();

                        currentGeneralAssessment.MediateLeaderAverageQuestion = mediateLeaderAverageQuestion;
                        this.ToResultOtherMediateLeaders(currentGeneralAssessment, currentMediateLeaderQuestionKey, otherMediateLeaders);
                    }
                }
            }
        }
    }

    private void ToResultOtherMediateLeaders(GeneralAssessment generalAssessment, string questionKey, List<MediateLeader> otherMediateLeaders)
    {
        if ((generalAssessment != null) && (!string.IsNullOrWhiteSpace(questionKey)) && (otherMediateLeaders?.Any() ?? false))
        {
            Dictionary<QuestionAnswer, int> dictionaryQuestions = new Dictionary<QuestionAnswer, int>();
            int averageOtherMediate = 0;
            decimal accumulatorOtherMediate = 0; int counterOtherMediate = 0;
            var questionsAndAnswersOtherMediate = new List<QuestionAnswer>();
            foreach (var currentOtherMediateLeader in otherMediateLeaders)
            {
                var currentOtherMediateLeaderQuestion = currentOtherMediateLeader.QuestionsAndAnswers.FirstOrDefault(q => q.Key == questionKey);
                if (currentOtherMediateLeaderQuestion != null)
                {
                    currentOtherMediateLeaderQuestion.QuestionType = generalAssessment.QuestionType;
                    if (currentOtherMediateLeaderQuestion.IsMeasurableQuestion)
                    {
                        accumulatorOtherMediate += Math.Abs(currentOtherMediateLeader.GetItemResult(currentOtherMediateLeaderQuestion));
                        counterOtherMediate += 1;
                        this.RegisterMediateMeasurableToDictionary(dictionaryQuestions, currentOtherMediateLeader, currentOtherMediateLeaderQuestion);
                    }
                }
            }
            generalAssessment.OtherMediateLeadersAverageData = dictionaryQuestions.Keys.ToList();

            if (counterOtherMediate == 0)
                counterOtherMediate = 1;
            decimal roundedAverageOtherImmediate = Math.Round((accumulatorOtherMediate / counterOtherMediate), 2);
            averageOtherMediate = Convert.ToInt32(roundedAverageOtherImmediate);

            var otherMediateLeaderAverageQuestion = new QuestionAnswer()
            {
                Key = generalAssessment.Key ?? string.Empty,
                KeyType = generalAssessment.KeyType,
                Question = generalAssessment.Question ?? string.Empty,
                QuestionType = generalAssessment.QuestionType
            };
            var agreementAndSatisfaction = EnumUtility.GetEnum<AgreementAndSatisfactionEnum>(Enum.GetName(typeof(AgreementAndSatisfactionEnum), averageOtherMediate));
            if (otherMediateLeaderAverageQuestion.IsMeasurableQuestion)
            {
                otherMediateLeaderAverageQuestion.Answer = EnumUtility.GetLocalizedDescription<AgreementAndSatisfactionEnum>(agreementAndSatisfaction.ToString());
                otherMediateLeaderAverageQuestion.Value = agreementAndSatisfaction;
            }

            generalAssessment.OtherMediateLeadersAverageQuestion = otherMediateLeaderAverageQuestion;
        }
    }
    #endregion Methods

    #region Tasks
    public async Task<List<GeneralAssessment>> FindOutAsync(string nickname, string userNameOrEmail, string code, string? evaluatedPersonName = null)
    {
        AssessmentResult? requestingAssessmentResult = default;
        if ((!string.IsNullOrWhiteSpace(userNameOrEmail)) && (!string.IsNullOrWhiteSpace(code)))
        {
            var encryptedCode = code.EncryptDES(DESExtensionMethods.Default_DES_Key, DESExtensionMethods.Default_DES_IV);
            Expression<Func<AssessmentResult, bool>> expression = x => (((x.Email == userNameOrEmail) || (x.Name == userNameOrEmail)) &&
                                                                         (x.Code == encryptedCode));
            requestingAssessmentResult = await this._assessmentResultDomainService.FindOneAsync(expression);
        }

        List<GeneralAssessment> generalAssessments;
        if (requestingAssessmentResult != null)
        {
            var generalQuestions = await this._generalQuestionDomainService.GetAllAsync();
            var leadershipQuestions = await this._leadershipQuestionDomainService.GetAllAsync();
            var managementQuestions = await this._managementQuestionDomainService.GetAllAsync();

            string queryingName, queryingNickName;
            this.GetQueryingNames(requestingAssessmentResult, requestingAssessmentResult.Name, nickname, out queryingName, out queryingNickName, evaluatedPersonName);

            AssessmentResult? evaluatedPersonAssessmentResult;
            if (queryingName == requestingAssessmentResult.Name)
                evaluatedPersonAssessmentResult = requestingAssessmentResult;
            else
                evaluatedPersonAssessmentResult = await this._assessmentResultDomainService.FindOneAsync(x => x.Name.ToLower() == queryingName.ToLower());

            if (evaluatedPersonAssessmentResult != null)
            {
                var questions = await this._questionDomainService.GetAllAsync();
                generalAssessments = this.AppendEvaluatedPersonQuestions(questions, requestingAssessmentResult, evaluatedPersonAssessmentResult, 
                                                                         queryingName, queryingNickName);

                string nameLower = queryingName.ToLower();

                this._coWorkerDomainService.SetGeneralQuestions(generalQuestions);
                var coWorkers = await this._coWorkerDomainService.FindAsync(x => (x.EvaluatedCoWorker != null) && (x.EvaluatedCoWorker.ToLower() == nameLower));

                //this._managementTeamDomainService.SetManagementQuestions(managementQuestions);
                //var managementTeams = await this._managementTeamDomainService.GetAllAsync();

                var nicknameLower = nickname.ToLower();
                this._selfAssessmentDomainService.SetGeneralQuestions(generalQuestions);
                var selfAssessment = await this._selfAssessmentDomainService.FindOneAsync(x => (x.Author != null) && (x.Author.ToLower() == nicknameLower));

                this._subordinateDomainService.SetGeneralQuestions(generalQuestions);
                var subordinate = await this._subordinateDomainService.FindOneAsync(x => (x.SubordinateName != null) && (x.SubordinateName.ToLower() == nameLower));

                string leadershipAuthor = (subordinate?.LeadershipAuthor ?? string.Empty).ToLower();
                var subordinates = await this._subordinateDomainService.FindAsync(x => (x.LeadershipAuthor != null) && (x.LeadershipAuthor.ToLower() == leadershipAuthor));

                int count = 50;

                List<ImmediateLeader> immediateLeaders, otherImmediateLeaders; List<MediateLeader> mediateLeaders, otherMediateLeaders;
                this.LoadManagementData(evaluatedPersonAssessmentResult, leadershipQuestions, out immediateLeaders, out otherImmediateLeaders, out mediateLeaders,
                                        out otherMediateLeaders, ref count);
                this.ToResult(generalAssessments, selfAssessment, coWorkers, subordinate, subordinates);
                this.ToResultImmediateLeader(queryingNickName, queryingName, evaluatedPersonAssessmentResult.BelongsToManagementTeam, generalAssessments, questions,
                                             immediateLeaders, otherImmediateLeaders);
                this.ToResultMediateLeader(queryingNickName, queryingName, evaluatedPersonAssessmentResult.BelongsToManagementTeam, generalAssessments, questions,
                                           mediateLeaders, otherMediateLeaders);
            }
            else
                generalAssessments = new List<GeneralAssessment>(0);
        }
        else
            generalAssessments = new List<GeneralAssessment>(0);

        return generalAssessments;
    }
    #endregion Tasks
}
