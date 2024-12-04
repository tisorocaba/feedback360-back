using Newtonsoft.Json;
using PMS.Core.Domain.DomainModels.Base;
using PMS.Core.Infra.CrossCutting.Constants;
using PMS.Core.Infra.CrossCutting.Cryptography.ExtensionMethods;
using PMS.Core.Infra.CrossCutting.Security;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class Sortition
    : AuditableDomainModelBase<Guid>
{
    #region Constructors
    public Sortition()
    {
        this._rows = 3;
        this._columns = 1;
        this.Items = new List<SortitionItem>(this._rows);
        this._valueCounter = new Dictionary<int, int>();
        this._passwordGenerator = new PasswordGenerator();
    }

    public Sortition(int rows, int columns, PasswordGenerator passwordGenerator)
    {
        this._rows = Math.Abs(rows);
        this._columns = Math.Abs(columns);
        this.Items = new List<SortitionItem>(rows);
        this._valueCounter = new Dictionary<int, int>();
        this._passwordGenerator = passwordGenerator;
    }
    #endregion Constructors

    #region Fields
    private int _rows, _columns;
    private Dictionary<int, int> _valueCounter;
    private readonly PasswordGenerator _passwordGenerator;
    #endregion Fields

    #region Methods
    public void AddItem(int pKey, int[] pValues, int rowIndex)
    {
        int key = Math.Abs(pKey);

        var queryable = pValues.Where(c => (c != key) && (c != rowIndex));

        var preSelectedValues = queryable.ToList();
        var preSelectedKeys = preSelectedValues.Select(i => string.Join(CoreInfraCrossCuttingConstants.PipelineChar, new int[] { key, i }.Select(e => e.ToString())
                                               .ToArray()));

        if (!Items.Any(i => i.Key == key))
        {
            var item = new SortitionItem(this._columns, this._passwordGenerator) { Key = key };
            var usedKeys = this.GetUsedKeys();
            var usingKeys = preSelectedKeys.Where(i => !usedKeys.Contains(i))
                                           .ToArray();
            item.AddKeys(usingKeys, this._valueCounter, this._columns);
            this.Items.Add(item);
        }
    }

    private List<string> GetUsedKeys()
    {
        var usedKeys = new List<string>(this._rows * this._columns);
        foreach (var currentItem in this.Items)
        {
            foreach (var currentItemKey in currentItem.Keys)
            {
                if (!usedKeys.Contains(currentItemKey))
                    usedKeys.Add(currentItemKey);
            }
        }
        return usedKeys;
    }

    public void SetContent()
    {
        JsonSerializerSettings jss = new JsonSerializerSettings();
        jss.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        var decryptedContent = JsonConvert.SerializeObject(this, jss);
        this.Content = decryptedContent.EncryptDES(DESExtensionMethods.Default_DES_Key, DESExtensionMethods.Default_DES_IV);
    }

    private void SetPrinting()
    {
        if (this.Impressions == null)
            this.Impressions = new List<SortitionParticipantPrinting>();

        var impression = new SortitionParticipantPrinting() { Sortition = this, IdSortition = this.Id };
        impression.SetId(Guid.NewGuid());
        this.Impressions.Add(impression);
    }

    public void ToParticipants()
    {
        var list = new List<SortitionParticipant>();
        foreach (var currentItem in this.Items)
        {
            currentItem.Sortition = this;
            currentItem.IdSortition = this.Id;
            list.Add(currentItem.ToParticipant());
        }
        this.Participants = list;
    }

    public override void OnBeforeAdding()
    {
        base.OnBeforeAdding();
        this.ToParticipants();
        this.SetContent();
        if (this.NumberOfParticipants <= 0)
            this.NumberOfParticipants = this.Participants.Count;
        this.SetPrinting();

    }
    #endregion Methods

    #region Properties
    public Guid? IdTeam { get; set; }
    public int Number { get; set; }
    public int NumberOfParticipants { get; set; }
    public string Content { get; set; } = default!;

    [JsonIgnore]
    public Team? Team { get; set; } = default!;

    public string? TeamName { get; set; }

    public bool IsValid { get { return (!Items.Any(i => i.Values.Count != this._columns)); } }

    public List<SortitionParticipantPrinting> Impressions { get; private set; } = default!;
    public List<SortitionItem> Items { get; private set; }
    public List<SortitionParticipant> Participants { get; private set; } = default!;
    #endregion Properties
}
