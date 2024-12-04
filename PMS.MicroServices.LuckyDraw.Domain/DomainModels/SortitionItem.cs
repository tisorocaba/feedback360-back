using Microsoft.VisualBasic;
using PMS.Core.Infra.CrossCutting.Constants;
using PMS.Core.Infra.CrossCutting.Cryptography.ExtensionMethods;
using PMS.Core.Infra.CrossCutting.Security;
using System.Text.Json.Serialization;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class SortitionItem
{
    #region Constructors
    public SortitionItem(int length, PasswordGenerator passwordGenerator)
    {
        this._length = Math.Abs(length);
        this.Values = new List<int>(this._length);
        this._passwordGenerator = passwordGenerator;
        this.AccessKey = this._passwordGenerator.GenerateHexadecimal().EncryptDES(DESExtensionMethods.Default_DES_Key, DESExtensionMethods.Default_DES_IV);
    }
    #endregion Constructors

    #region Fields
    private int _length;
    private readonly PasswordGenerator _passwordGenerator;
    #endregion Fields

    #region Methods
    public void AddKeys(string[] keys, Dictionary<int, int> valueCounter, int limit)
    {
        var strKey = this.Key.ToString();
        foreach (var currentKey in keys)
        {
            if ((this.Values.Count < limit) && (!string.IsNullOrWhiteSpace(currentKey)) && currentKey.Contains(CoreInfraCrossCuttingConstants.PipelineChar))
            {
                var splitKey = currentKey.Split(CoreInfraCrossCuttingConstants.PipelineChar);
                var foundKey = splitKey.Where(e => e != strKey).FirstOrDefault();
                if (Information.IsNumeric(foundKey))
                {
                    var foundValue = Convert.ToInt32(foundKey);
                    if ((!this.Values.Contains(foundValue)) && (!this.HasExtrapoledValue(valueCounter, foundValue, limit)))
                    {
                        this.Values.Add(foundValue);
                        this.RegisterUsedValue(valueCounter, foundValue);
                    }
                }
            }
        }
    }

    public List<string> GetPossibleKeys(List<int> values)
    {
        return values.Select(i => string.Join(CoreInfraCrossCuttingConstants.PipelineChar, new int[] { Key, i }.OrderBy(o => o)
                                                                                                               .Select(e => e.ToString())
                                                                                                               .ToArray())
                            ).ToList();
    }

    private bool HasExtrapoledValue(Dictionary<int, int> valueCounter, int value, int limit)
    {
        return (valueCounter != null) && valueCounter.ContainsKey(value) && (valueCounter[value] >= limit);
    }

    private void RegisterUsedValue(Dictionary<int, int> valueCounter, int value)
    {
        if (valueCounter.ContainsKey(value))
            valueCounter[value] = (valueCounter[value] + 1);
        else
            valueCounter.Add(value, 1);
    }

    public SortitionParticipant ToParticipant()
    {
        var participant = new SortitionParticipant()
        {
            IdSortition = this.IdSortition,
            Sortition = this.Sortition,
            Number = this.Key,
            Code = this.AccessKey
        };
        participant.SetId(Guid.NewGuid());
        return participant;
    }
    #endregion Methods

    #region Properties
    public Guid IdSortition { get; set; }

    public string AccessKey { get; set; } = default!;
    public int Key { get; set; }

    [JsonIgnore]
    public Sortition Sortition { get; set; } = default!;

    [JsonIgnore]
    public List<string> Keys { get { return GetPossibleKeys(this.Values); } }

    public List<int> Values { get; private set; }
    #endregion Properties
}
