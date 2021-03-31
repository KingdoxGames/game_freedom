#region Access
using UnityEngine;
using Environment;
using XavHelpTo.Change;
using XavHelpTo.Look;
#endregion
public class ReactionHistory : Reaction
{
    #region Variables
    [Range(-1,Data.ACT_QTY)]
    public int act = -1;
    [Range(-1,Data.PARTS_QTY)]
    public int part = -1;
    [Range(-1,Data.EXTRA_QTY)]
    public int extra = -1;
    [Range(-1, Data.ITEM_QTY)]
    public int item = -1;
    public bool addItem = true;

    [Space]
    [Tooltip("Cambia al mapa selecto")]
    public Maps map = Maps.NO_MAP;

    #endregion
    #region Events
    public override void OnDrawGizmos()
    {
        name = $"History: ({waiTime} s) -> ";
        name += ToShow(map.ToInt(),"ChangeMap"); ;
        name += ToShow(act, "Act");
        name += ToShow(part, "Part");
        name += ToShow(extra, "Extra");
        string addOrRemove = addItem ? "ADD" : "REMOVE";
        name += ToShow(item, $"{addOrRemove} Item");
        name += $" {debug_information} ";
    }
    #endregion
    #region Methods
    protected override void React()
    {
        //base.React();

        //ACT
        SavedData saved = DataPass.SavedData;
        bool changesInSaved = false;
        if (ToChange(in act, in saved.currentAct)){
            saved.currentAct = act;
            changesInSaved = true;
        }

        //PART
        if (ToChange(in part,TheatreManager.CurrentPart)) {
            TheatreManager.SetPart(part);

        }

        //EXTRA
        if (!extra.Equals(-1)){
            saved.currentExtra = extra;
            changesInSaved = true;
        }

        // ---> SAVE?
        if (changesInSaved)
        {
            DataPass.SetData(saved);
            DataPass.SaveLoadFile(true);
        }

        //ITEM
        if (!item.Equals(-1)) {
            TheatreManager.SetItem(item, addItem);
        }

        //MAP
        if (!map.Equals(Maps.NO_MAP)) MapManager.ChangeMap(map, false);


       
    }
    private string ToShow(in int i, string val) => !i.Equals(-1) ? $"{val} {i} " : "";
    /// <summary>
    /// Returns true if it wants to be changed
    /// takes -1 as a default (false);
    /// </summary>
    private bool ToChange(in int i, in int val) => !i.Equals(-1) && !i.Equals(val);
    #endregion
}