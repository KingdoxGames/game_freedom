#region Access
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Environment;
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
    [Space]
    public bool refreshMap = false;//TODO aja y cual mapa? :))))))))
    //TODO por ver -> string localthing ="typeA" //rollo cuando decidas contra el jefe guardia

    #endregion
    #region Events
    public override void OnDrawGizmos()
    {
        name = $"History: ({waiTime} s) -> ";
        name += "ChangeMap ";
        name += ToShow(act, "Act");
        name += ToShow(part, "Part");
        name += ToShow(extra, "Extra");
        name += $" {debug_information} ";
    }
    #endregion
    #region Methods
    protected override void React()
    {
        //base.React();

        //ACT
        SavedData saved = DataPass.SavedData;
        if (ToChange(in act, in saved.currentAct))
        {
            saved.currentAct = act;
            DataPass.SetData(saved);
        }

        //PART
        if (ToChange(in part,TheatreManager.CurrentPart)) {
            TheatreManager.SetPart(part);
        }

        //if (true)
        //{
        //    MapManager.ChangeMap((Maps))
        //}

    }
    private string ToShow(in int i, string val) => !i.Equals(-1) ? $"{val} {i} " : "";
    /// <summary>
    /// Returns true if it wants to be changed
    /// takes -1 as a default (false);
    /// </summary>
    private bool ToChange(in int i, in int val) => !i.Equals(-1) && !i.Equals(val);
    #endregion
}