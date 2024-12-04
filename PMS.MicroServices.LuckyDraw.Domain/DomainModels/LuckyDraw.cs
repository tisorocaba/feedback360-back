using PMS.Core.Infra.CrossCutting.Security;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class LuckyDraw
{
    #region Constructors
    public LuckyDraw()
    {
        this._passwordGenerator = new PasswordGenerator();
    }
    #endregion Constructors

    #region Fields
    private readonly PasswordGenerator _passwordGenerator;
    #endregion Fields

    #region Methods
    public Sortition Raffle(int rows, int columns)
    {
        var sortition = new Sortition(rows, columns, this._passwordGenerator);
        if ((rows > 1) && (columns > 1))
        {
            Random random = new Random();

            bool validRandomResult;
            int attemptCounter = 0;
            int[] rowNumbers;
            do
            {
                validRandomResult = true;
                rowNumbers = Enumerable.Range(1, rows)
                                       .Select(i => new Tuple<int, int>(random.Next(rows), i))
                                       .OrderByDescending(i => i.Item1)
                                       .Select(i => i.Item2)
                                       .ToArray();
                for (int index = 0; index < rowNumbers.Length; index++)
                {
                    validRandomResult = validRandomResult && (rowNumbers[index] != (index + 1));
                    if (!validRandomResult)
                    {
                        rowNumbers = [];
                        break;
                    }
                }
                attemptCounter += 1;
            } while ((!validRandomResult) || (attemptCounter >= 100));

            bool failed = false;
            if (rowNumbers.Any())
            {
                List<int> possibleCombinations = (from n in Enumerable.Range(1, rows)
                                                  from r in Enumerable.Repeat(n, columns)
                                                  select r).ToList();
                Dictionary<int, List<int>> keyValuePairs = new Dictionary<int, List<int>>();

                for (int currentRowNumberIndex = 0; currentRowNumberIndex < rows; currentRowNumberIndex++)
                {
                    var currentRowNumber = rowNumbers.ElementAt(currentRowNumberIndex);
                    List<int> currentColumnValues = new List<int>(columns);
                    for (int currentColumnIndex = 0; currentColumnIndex < columns; currentColumnIndex++)
                    {
                        var tempPossibleValues = possibleCombinations.Where(i => (i != currentRowNumber) && (!currentColumnValues.Contains(i))).ToList();
                        int chosenIndex;
                        if (tempPossibleValues.Count > 1)
                            chosenIndex = random.Next(1, tempPossibleValues.Count);
                        else
                            chosenIndex = 0;
                        if (tempPossibleValues.Any())
                        {
                            var chosenNumber = tempPossibleValues[chosenIndex];
                            currentColumnValues.Add(chosenNumber);
                            var lastIndexOf = possibleCombinations.IndexOf(chosenNumber);
                            if (lastIndexOf > -1)
                                possibleCombinations.RemoveAt(lastIndexOf);
                        }
                        else
                        {
                            failed = true;
                            break;
                        }
                    }
                    if (failed)
                        break;

                    keyValuePairs.Add(currentRowNumber, currentColumnValues);
                    sortition.AddItem(currentRowNumber, currentColumnValues.ToArray(), (currentRowNumberIndex + 1));
                }
            }
        }
        return sortition;
    }

    public Sortition RaffleForTeam(Team team, int columns)
    {
        var sortition = this.Raffle(team.NumberOfParticipants, columns);
        sortition.IdTeam = team.Id;
        sortition.TeamName = team.Name;
        return sortition;
    }
    #endregion Methods
}
