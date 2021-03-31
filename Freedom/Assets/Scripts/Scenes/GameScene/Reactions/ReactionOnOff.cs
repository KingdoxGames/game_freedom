#region 
using UnityEngine;
using XavHelpTo.Change;
#endregion

public class ReactionOnOff : Reaction{

    #region Variables
    [Header("ReactionOnOff")]
    public GameObject[] objs;
    public bool condition;
    #endregion
    #region Events
    public override void OnDrawGizmos()
    {
        name = $"OnOff: ({waiTime} s) -> ";
        foreach (GameObject o in objs){
            name += $" ({o.name}) ";
        }

        name += $" {debug_information}";
    }
    #endregion
    #region Methods
    protected override void React()
    {
        if (objs.Length.Equals(0))
        {
            //desactive Visualplayer?
        }
        else
        {
            objs.ActiveObjects(condition);
        }
    }
    #endregion
}