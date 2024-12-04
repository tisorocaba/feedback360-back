using PMS.Core.Infra.CrossCutting.Cryptography.ExtensionMethods;
using PMS.Core.Infra.CrossCutting.Utilities;
using PMS.MicroServices.LuckyDraw.Domain.Constants;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.Enums;
using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices;

internal class SortitionResultDomainServiceOld
    : ISortitionResultDomainService
{
    #region Constructors
    public SortitionResultDomainServiceOld(IAssessmentResultDomainService assessmentResultDomainService, IAuthorDomainService authorDomainService,
                                           ICoWorkerDomainService coWorkerDomainService, IGeneralQuestionDomainService generalQuestionDomainService,
                                           IImmediateLeaderDomainService immediateLeaderDomainService, ILeadershipQuestionDomainService leadershipQuestionDomainService,
                                           IManagementQuestionDomainService managementQuestionDomainService, IManagementTeamDomainService managementTeamDomainService,
                                           IMediateLeaderDomainService mediateLeaderDomainService, ISelfAssessmentDomainService selfAssessmentDomainService,
                                           ISubordinateDomainService subordinateDomainService)
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
        this._selfAssessmentDomainService = selfAssessmentDomainService;
        this._subordinateDomainService = subordinateDomainService;
    }
    #endregion Constructors

    #region Constants
    const string CoWorkerTypeA = "A", CoWorkerTypeB = "B", CoWorkerTypeC = "C", CoWorkerTypeX = "X";
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
    readonly ISelfAssessmentDomainService _selfAssessmentDomainService;
    readonly ISubordinateDomainService _subordinateDomainService;
    #endregion Fields

    #region Methods
    private void AppendCoWorkersAverageResult(GeneralAssessment generalAssessment, List<CoWorker> coWorkers, string? questionKey)
    {
        if ((generalAssessment != null) && (!string.IsNullOrWhiteSpace(questionKey)))
        {
            bool addedMultipleChoice = false;
            int average = 0;
            decimal accumulator = 0; int counter = 0;
            if (coWorkers?.Any() ?? false)
            {
                var dictionaryQuestions = new Dictionary<QuestionAnswer, int>();
                foreach (var currentCoWorker in coWorkers)
                {
                    var selectedCurrentCoWorkerQuestion = currentCoWorker.QuestionsAndAnswers.FirstOrDefault(q => q.Key == questionKey);
                    if (selectedCurrentCoWorkerQuestion != null)
                    {
                        if (!object.Equals(selectedCurrentCoWorkerQuestion.Value, AgreementAndSatisfactionEnum.NotSet))
                        {
                            var currentItemResult = currentCoWorker.GetItemResult(selectedCurrentCoWorkerQuestion);
                            if (!dictionaryQuestions.ContainsKey(selectedCurrentCoWorkerQuestion))
                                dictionaryQuestions.Add(selectedCurrentCoWorkerQuestion, currentItemResult);

                            accumulator += Math.Abs(currentItemResult);
                            counter += 1;
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
                Key = (questionKey ?? string.Empty),
                KeyType = generalAssessment.KeyType,
                Question = (generalAssessment.SelfAssessmentQuestion?.Question ?? string.Empty),
            };
            var agreementAndSatisfaction = EnumUtility.GetEnum<AgreementAndSatisfactionEnum>(Enum.GetName(typeof(AgreementAndSatisfactionEnum), average));
            if (!addedMultipleChoice)
            {
                coWorkersAverageQuestion.Answer = EnumUtility.GetLocalizedDescription<AgreementAndSatisfactionEnum>(agreementAndSatisfaction.ToString());
                coWorkersAverageQuestion.Value = agreementAndSatisfaction;
            }

            generalAssessment.CoWorkersAverageQuestion = coWorkersAverageQuestion;
        }
    }

    private void AppendCoWorkersResult(GeneralAssessment generalAssessment, CoWorker? coWorker, string? questionKey)
    {
        if ((generalAssessment != null) && (coWorker != null) && (!string.IsNullOrWhiteSpace(questionKey)))
        {
            QuestionAnswer? correspondingQuestion = coWorker.QuestionsAndAnswers.FirstOrDefault(q => q.Key == questionKey);
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

    private void AppendCoWorkersResult(GeneralAssessment generalAssessment, List<CoWorker> coWorkers, string? questionKey)
    {
        if ((generalAssessment != null) && (coWorkers?.Any() ?? false))
        {
            this.AppendCoWorkersResult(generalAssessment, coWorkers.FirstOrDefault(c => c.CoWorkerType == CoWorkerTypeA), questionKey);
            this.AppendCoWorkersResult(generalAssessment, coWorkers.FirstOrDefault(c => c.CoWorkerType == CoWorkerTypeB), questionKey);
            this.AppendCoWorkersResult(generalAssessment, coWorkers.FirstOrDefault(c => c.CoWorkerType == CoWorkerTypeC), questionKey);

            var extraCoWorkers = coWorkers.Where(e => (e.CoWorkerType ?? string.Empty).ToUpper() == CoWorkerTypeX).ToList();
            this.AppendExtraCoWorkersResult(generalAssessment, extraCoWorkers, questionKey);
            this.AppendCoWorkersAverageResult(generalAssessment, coWorkers, questionKey);
        }
    }

    private void AppendExtraCoWorkersResult(GeneralAssessment generalAssessment, List<CoWorker> coWorkers, string? questionKey)
    {
        if ((generalAssessment != null) && (!string.IsNullOrWhiteSpace(questionKey)))
        {
            int average = 0;
            decimal accumulator = 0; int counter = 0;
            if (coWorkers?.Any() ?? false)
            {
                var dictionaryQuestions = new Dictionary<QuestionAnswer, int>();
                foreach (var currentCoWorker in coWorkers)
                {
                    var selectedCurrentCoWorkerQuestion = currentCoWorker.QuestionsAndAnswers.FirstOrDefault(q => q.Key == questionKey);
                    if (selectedCurrentCoWorkerQuestion != null)
                    {
                        selectedCurrentCoWorkerQuestion.QuestionType = generalAssessment.QuestionType;
                        if (!object.Equals(selectedCurrentCoWorkerQuestion.Value, AgreementAndSatisfactionEnum.NotSet))
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
                                if (selectedCurrentCoWorkerQuestion.IsMultipleChoiceQuestion)
                                    generalAssessment.AddMultipleChoiceQuestion(selectedCurrentCoWorkerQuestion);
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
                Key = (questionKey ?? string.Empty),
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

            generalAssessment.ExtraCoWorkersQuestion = extraCoWorkersQuestion;
        }
    }

    private void AppendSelfAssessmentResult(GeneralAssessment generalAssessment, SelfAssessment? selfAssessment, int index, out string? questionKey)
    {
        if ((generalAssessment != null) && (selfAssessment != null))
        {
            if (index == 0)
                selfAssessment.QuestionsAndAnswers = selfAssessment.QuestionsAndAnswers.OrderBy(o => o.Key).ToList();
            if (selfAssessment.QuestionsAndAnswers.Count >= index + 1)
            {
                var correspondingQuestion = selfAssessment.QuestionsAndAnswers.ElementAt(index);
                if (correspondingQuestion != null)
                {
                    generalAssessment.SelfAssessmentQuestion = correspondingQuestion;
                    generalAssessment.Key = generalAssessment.SelfAssessmentQuestion.Key;
                    generalAssessment.Question = generalAssessment.SelfAssessmentQuestion.Question;

                    if (object.Equals(correspondingQuestion.Value, AgreementAndSatisfactionEnum.NotSet))
                    {
                        if (generalAssessment.IsFreeWritingQuestion)
                            generalAssessment.AddFreeWritingQuestion(correspondingQuestion);
                        if (generalAssessment.IsMultipleChoiceQuestion)
                            generalAssessment.AddMultipleChoiceQuestion(correspondingQuestion);
                    }
                }
            }
        }
        questionKey = generalAssessment?.SelfAssessmentQuestion?.Key;
    }

    private void AppendSubordinateAverageResult(GeneralAssessment generalAssessment, List<Subordinate> subordinates, string? questionKey)
    {
        if ((generalAssessment != null) && (!string.IsNullOrWhiteSpace(questionKey)))
        {
            bool addedMultipleChoice = false;
            int average = 0;
            decimal accumulator = 0; int counter = 0;
            if (subordinates?.Any() ?? false)
            {
                var dictionaryQuestions = new Dictionary<QuestionAnswer, int>();
                foreach (var currentSubordinate in subordinates)
                {
                    var selectedCurrentSubordinateQuestion = currentSubordinate.QuestionsAndAnswers.FirstOrDefault(q => q.Key == questionKey);
                    if (selectedCurrentSubordinateQuestion != null)
                    {
                        if (!object.Equals(selectedCurrentSubordinateQuestion.Value, AgreementAndSatisfactionEnum.NotSet))
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
                Key = (questionKey ?? string.Empty),
                KeyType = generalAssessment.KeyType,
                Question = (generalAssessment.SelfAssessmentQuestion?.Question ?? string.Empty),
            };
            var agreementAndSatisfaction = EnumUtility.GetEnum<AgreementAndSatisfactionEnum>(Enum.GetName(typeof(AgreementAndSatisfactionEnum), average));
            if (!addedMultipleChoice)
            {
                subordinateAverageQuestion.Answer = EnumUtility.GetLocalizedDescription<AgreementAndSatisfactionEnum>(agreementAndSatisfaction.ToString());
                subordinateAverageQuestion.Value = agreementAndSatisfaction;
            }
            else
            {
                if (generalAssessment.IsFreeWritingQuestion)
                    subordinateAverageQuestion.Answer = generalAssessment.ToFreeWritingHtmlCode();
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

    private List<GeneralAssessment> ToResult(string nickname, string name, bool belongsToManagementTeam, int count, SelfAssessment? selfAssessment,
                                             List<CoWorker> coWorkers, Subordinate? subordinate, List<Subordinate> subordinates)
    {
        var result = new List<GeneralAssessment>(Math.Abs(count));
        for (int currentIndex = 0; currentIndex < count; currentIndex++)
        {
            string? currentQuestionKey;
            var currentGeneralAssessment = new GeneralAssessment() { NickName = nickname, Name = name, AccessedAsManager = belongsToManagementTeam };
            this.AppendSelfAssessmentResult(currentGeneralAssessment, selfAssessment, currentIndex, out currentQuestionKey);
            if (!string.IsNullOrWhiteSpace(currentQuestionKey))
            {
                currentGeneralAssessment.KeyType = LuckyDrawDomainConstants.NormalEvaluatedPersonChar;
                this.AppendCoWorkersResult(currentGeneralAssessment, coWorkers, currentQuestionKey);
                this.AppendSubordinateResult(currentGeneralAssessment, subordinate, currentQuestionKey);
                this.AppendSubordinateAverageResult(currentGeneralAssessment, subordinates, currentQuestionKey);
                result.Add(currentGeneralAssessment);
            }
        }
        return result;
    }

    private void ToResultImmediateLeader(string nickname, string name, bool belongsToManagementTeam, List<GeneralAssessment> generalAssessments,
                                         List<LeadershipQuestion> leadershipQuestions, List<ImmediateLeader> immediateLeaders,
                                         List<ImmediateLeader> otherImmediateLeaders)
    {
        if (generalAssessments != null)
        {
            if (leadershipQuestions?.Any() ?? false)
            {
                if (immediateLeaders?.Any() ?? false)
                {
                    var immediateLeaderQuestionKeys = (from i in immediateLeaders
                                                       from j in i.QuestionsAndAnswers
                                                       where !string.IsNullOrEmpty(j.Key)
                                                       select j.Key).Distinct().ToList();
                    foreach (var currentImmediateLeaderQuestionKey in immediateLeaderQuestionKeys)
                    {
                        if (!string.IsNullOrWhiteSpace(currentImmediateLeaderQuestionKey))
                        {
                            var currentGeneralAssessment = new GeneralAssessment()
                            {
                                NickName = nickname,
                                Name = name,
                                AccessedAsManager = belongsToManagementTeam,
                                Key = currentImmediateLeaderQuestionKey,
                                KeyType = LuckyDrawDomainConstants.ImmediateLeaderEvaluatedPersonChar,
                                Question = leadershipQuestions.FirstOrDefault(q => q.Abbreviation == currentImmediateLeaderQuestionKey)?.Question
                            };
                            Dictionary<QuestionAnswer, int> dictionaryQuestions = new Dictionary<QuestionAnswer, int>();
                            bool addedMultipleChoice = false;
                            int averageImmediate = 0;
                            decimal accumulatorImmediate = 0; int counterImmediate = 0;
                            var questionsAndAnswersImmediate = new List<QuestionAnswer>();
                            foreach (var currentImmediateLeader in immediateLeaders)
                            {
                                var currentImmediateLeaderQuestion = currentImmediateLeader.QuestionsAndAnswers.FirstOrDefault(q => q.Key == currentImmediateLeaderQuestionKey);
                                if (currentImmediateLeaderQuestion != null)
                                {
                                    if (!object.Equals(currentImmediateLeaderQuestion.Value, AgreementAndSatisfactionEnum.NotSet))
                                    {
                                        accumulatorImmediate += Math.Abs(currentImmediateLeader.GetItemResult(currentImmediateLeaderQuestion));
                                        counterImmediate += 1;
                                        this.RegisterImmediateMeasurableToDictionary(dictionaryQuestions, currentImmediateLeader, currentImmediateLeaderQuestion);
                                    }
                                    else
                                    {
                                        if (currentGeneralAssessment.IsMultipleChoiceQuestion)
                                            currentGeneralAssessment.AddMultipleChoiceQuestion(currentImmediateLeaderQuestion);
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
                                Key = currentGeneralAssessment.Key,
                                KeyType = currentGeneralAssessment.KeyType,
                                Question = currentGeneralAssessment.Question ?? string.Empty,
                            };
                            var agreementAndSatisfaction = EnumUtility.GetEnum<AgreementAndSatisfactionEnum>(Enum.GetName(typeof(AgreementAndSatisfactionEnum), averageImmediate));
                            if (!addedMultipleChoice)
                            {
                                immediateLeaderAverageQuestion.Answer = EnumUtility.GetLocalizedDescription<AgreementAndSatisfactionEnum>(agreementAndSatisfaction.ToString());
                                immediateLeaderAverageQuestion.Value = agreementAndSatisfaction;
                            }
                            else
                            {
                                if (currentGeneralAssessment.IsFreeWritingQuestion)
                                    immediateLeaderAverageQuestion.Answer = currentGeneralAssessment.ToFreeWritingHtmlCode();
                            }

                            currentGeneralAssessment.ImmediateLeaderAverageQuestion = immediateLeaderAverageQuestion;
                            this.ToResultOtherImmediateLeaders(currentGeneralAssessment, currentImmediateLeaderQuestionKey, otherImmediateLeaders);
                            generalAssessments.Add(currentGeneralAssessment);
                        }
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
            bool addedMultipleChoice = false;
            int averageOtherImmediate = 0;
            decimal accumulatorOtherImmediate = 0; int counterOtherImmediate = 0;
            var questionsAndAnswersOtherImmediate = new List<QuestionAnswer>();
            foreach (var currentOtherImmediateLeader in otherImmediateLeaders)
            {
                var currentOtherImmediateLeaderQuestion = currentOtherImmediateLeader.QuestionsAndAnswers.FirstOrDefault(q => q.Key == questionKey);
                if (currentOtherImmediateLeaderQuestion != null)
                {
                    if (!object.Equals(currentOtherImmediateLeaderQuestion.Value, AgreementAndSatisfactionEnum.NotSet))
                    {
                        accumulatorOtherImmediate += Math.Abs(currentOtherImmediateLeader.GetItemResult(currentOtherImmediateLeaderQuestion));
                        counterOtherImmediate += 1;
                        this.RegisterImmediateMeasurableToDictionary(dictionaryQuestions, currentOtherImmediateLeader, currentOtherImmediateLeaderQuestion);
                    }
                    else
                    {
                        if (generalAssessment.IsMultipleChoiceQuestion)
                            generalAssessment.AddMultipleChoiceQuestion(currentOtherImmediateLeaderQuestion);
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
            };
            var agreementAndSatisfaction = EnumUtility.GetEnum<AgreementAndSatisfactionEnum>(Enum.GetName(typeof(AgreementAndSatisfactionEnum), averageOtherImmediate));
            if (!addedMultipleChoice)
            {
                otherImmediateLeaderAverageQuestion.Answer = EnumUtility.GetLocalizedDescription<AgreementAndSatisfactionEnum>(agreementAndSatisfaction.ToString());
                otherImmediateLeaderAverageQuestion.Value = agreementAndSatisfaction;
            }
            else
            {
                if (generalAssessment.IsFreeWritingQuestion)
                    otherImmediateLeaderAverageQuestion.Answer = generalAssessment.ToFreeWritingHtmlCode();
            }

            generalAssessment.OtherImmediateLeadersAverageQuestion = otherImmediateLeaderAverageQuestion;
        }
    }

    private void ToResultMediateLeader(string nickname, string name, bool belongsToManagementTeam, List<GeneralAssessment> generalAssessments,
                                       List<LeadershipQuestion> leadershipQuestions, List<MediateLeader> mediateLeaders, List<MediateLeader> otherMediateLeaders)
    {
        if (generalAssessments != null)
        {
            if (leadershipQuestions?.Any() ?? false)
            {
                if (mediateLeaders?.Any() ?? false)
                {
                    var mediateLeaderQuestionKeys = (from i in mediateLeaders
                                                     from j in i.QuestionsAndAnswers
                                                     where !string.IsNullOrEmpty(j.Key)
                                                     select j.Key).Distinct().ToList();
                    foreach (var currentMediateLeaderQuestionKey in mediateLeaderQuestionKeys)
                    {
                        if (!string.IsNullOrWhiteSpace(currentMediateLeaderQuestionKey))
                        {
                            var currentGeneralAssessment = new GeneralAssessment()
                            {
                                NickName = nickname,
                                Name = name,
                                AccessedAsManager = belongsToManagementTeam,
                                Key = currentMediateLeaderQuestionKey,
                                KeyType = LuckyDrawDomainConstants.MediateLeaderEvaluatedPersonChar,
                                Question = leadershipQuestions.FirstOrDefault(q => q.Abbreviation == currentMediateLeaderQuestionKey)?.Question
                            };
                            Dictionary<QuestionAnswer, int> dictionaryQuestions = new Dictionary<QuestionAnswer, int>();
                            bool addedMultipleChoice = false;
                            int averageMediate = 0;
                            decimal accumulatorMediate = 0; int counterMediate = 0;
                            var questionsAndAnswersMediate = new List<QuestionAnswer>();
                            foreach (var currentMediateLeader in mediateLeaders)
                            {
                                var currentMediateLeaderQuestion = currentMediateLeader.QuestionsAndAnswers.FirstOrDefault(q => q.Key == currentMediateLeaderQuestionKey);
                                if (currentMediateLeaderQuestion != null)
                                {
                                    if (!object.Equals(currentMediateLeaderQuestion.Value, AgreementAndSatisfactionEnum.NotSet))
                                    {
                                        accumulatorMediate += Math.Abs(currentMediateLeader.GetItemResult(currentMediateLeaderQuestion));
                                        counterMediate += 1;
                                        this.RegisterMediateMeasurableToDictionary(dictionaryQuestions, currentMediateLeader, currentMediateLeaderQuestion);
                                    }
                                    else
                                    {
                                        if (currentGeneralAssessment.IsMultipleChoiceQuestion)
                                            currentGeneralAssessment.AddMultipleChoiceQuestion(currentMediateLeaderQuestion);
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
                                Key = currentGeneralAssessment.Key,
                                KeyType = currentGeneralAssessment.KeyType,
                                Question = currentGeneralAssessment.Question ?? string.Empty,
                            };
                            var agreementAndSatisfaction = EnumUtility.GetEnum<AgreementAndSatisfactionEnum>(Enum.GetName(typeof(AgreementAndSatisfactionEnum), averageMediate));
                            if (!addedMultipleChoice)
                            {
                                mediateLeaderAverageQuestion.Answer = EnumUtility.GetLocalizedDescription<AgreementAndSatisfactionEnum>(agreementAndSatisfaction.ToString());
                                mediateLeaderAverageQuestion.Value = agreementAndSatisfaction;
                            }
                            else
                            {
                                if (currentGeneralAssessment.IsFreeWritingQuestion)
                                    mediateLeaderAverageQuestion.Answer = currentGeneralAssessment.ToFreeWritingHtmlCode();
                            }

                            currentGeneralAssessment.MediateLeaderAverageQuestion = mediateLeaderAverageQuestion;
                            this.ToResultOtherMediateLeaders(currentGeneralAssessment, currentMediateLeaderQuestionKey, otherMediateLeaders);
                            generalAssessments.Add(currentGeneralAssessment);
                        }
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
            bool addedMultipleChoice = false;
            int averageOtherMediate = 0;
            decimal accumulatorOtherMediate = 0; int counterOtherMediate = 0;
            var questionsAndAnswersOtherMediate = new List<QuestionAnswer>();
            foreach (var currentOtherMediateLeader in otherMediateLeaders)
            {
                var currentOtherMediateLeaderQuestion = currentOtherMediateLeader.QuestionsAndAnswers.FirstOrDefault(q => q.Key == questionKey);
                if (currentOtherMediateLeaderQuestion != null)
                {
                    if (!object.Equals(currentOtherMediateLeaderQuestion.Value, AgreementAndSatisfactionEnum.NotSet))
                    {
                        accumulatorOtherMediate += Math.Abs(currentOtherMediateLeader.GetItemResult(currentOtherMediateLeaderQuestion));
                        counterOtherMediate += 1;
                        this.RegisterMediateMeasurableToDictionary(dictionaryQuestions, currentOtherMediateLeader, currentOtherMediateLeaderQuestion);
                    }
                    else
                    {
                        if (generalAssessment.IsMultipleChoiceQuestion)
                            generalAssessment.AddMultipleChoiceQuestion(currentOtherMediateLeaderQuestion);
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
            };
            var agreementAndSatisfaction = EnumUtility.GetEnum<AgreementAndSatisfactionEnum>(Enum.GetName(typeof(AgreementAndSatisfactionEnum), averageOtherMediate));
            if (!addedMultipleChoice)
            {
                otherMediateLeaderAverageQuestion.Answer = EnumUtility.GetLocalizedDescription<AgreementAndSatisfactionEnum>(agreementAndSatisfaction.ToString());
                otherMediateLeaderAverageQuestion.Value = agreementAndSatisfaction;
            }
            else
            {
                if (generalAssessment.IsFreeWritingQuestion)
                    otherMediateLeaderAverageQuestion.Answer = generalAssessment.ToFreeWritingHtmlCode();
            }

            generalAssessment.OtherMediateLeadersAverageQuestion = otherMediateLeaderAverageQuestion;
        }
    }
    #endregion Methods

    #region Tasks
    public async Task<List<GeneralAssessment>> FindOutAsync(string nickname, string userNameOrEmail, string code, string? evaluatedPersonName = null)
    {
        List<GeneralAssessment> generalAssessments;

        AssessmentResult? assessmentResult = default;
        if ((!string.IsNullOrWhiteSpace(userNameOrEmail)) && (!string.IsNullOrWhiteSpace(code)))
        {
            var encryptedCode = code.EncryptDES(DESExtensionMethods.Default_DES_Key, DESExtensionMethods.Default_DES_IV);
            Expression<Func<AssessmentResult, bool>> expression = x => (((x.Email == userNameOrEmail) || (x.Name == userNameOrEmail)) &&
                                                                         (x.Code == encryptedCode));
            assessmentResult = await this._assessmentResultDomainService.FindOneAsync(expression);
        }

        if (assessmentResult != null)
        {
            var generalQuestions = await this._generalQuestionDomainService.GetAllAsync();
            var leadershipQuestions = await this._leadershipQuestionDomainService.GetAllAsync();
            var managementQuestions = await this._managementQuestionDomainService.GetAllAsync();

            string queryingName, queryingNickName;
            this.GetQueryingNames(assessmentResult, assessmentResult.Name, nickname, out queryingName, out queryingNickName, evaluatedPersonName);

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
            this.LoadManagementData(assessmentResult, leadershipQuestions, out immediateLeaders, out otherImmediateLeaders, out mediateLeaders,
                                    out otherMediateLeaders, ref count);
            generalAssessments = this.ToResult(queryingNickName, queryingName, assessmentResult.BelongsToManagementTeam, count, selfAssessment, coWorkers,
                                               subordinate, subordinates);
            this.ToResultImmediateLeader(queryingNickName, queryingName, assessmentResult.BelongsToManagementTeam, generalAssessments, leadershipQuestions,
                                         immediateLeaders, otherImmediateLeaders);
            this.ToResultMediateLeader(queryingNickName, queryingName, assessmentResult.BelongsToManagementTeam, generalAssessments, leadershipQuestions,
                                       mediateLeaders, otherMediateLeaders);
        }
        else
            generalAssessments = new List<GeneralAssessment>(0);

        return generalAssessments;
    }
    #endregion Tasks
}
