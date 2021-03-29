#region Access
using UnityEngine;
using Environment;
#endregion
/// <summary>
/// Reaction to do with the screen
/// </summary>
public class ReactionScreen : Reaction
{
    #region Variables
    
    [Header("_Screen_Fade")]
    public ScreenTrigger trigger = ScreenTrigger.HIDE;
    #endregion
    #region Events
    public override void OnDrawGizmos(){
        name = $"Screen: ({waiTime} s) -> {trigger}";
    }
    #endregion
    #region Methods
    protected override void React()
    {
        //hacemos el efecto
        TheatreManager.TriggerScreen(trigger);
    }
    #endregion
}