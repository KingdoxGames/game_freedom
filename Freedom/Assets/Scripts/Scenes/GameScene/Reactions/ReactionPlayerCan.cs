#region Access
using UnityEngine;
#endregion
/// <summary>
/// Reaction to change the Availability of the <seealso cref="Control"/> of the player in <see cref="PlayerController"/>
/// </summary>
public class ReactionPlayerCan : Reaction
{
    #region Variables
    [Header("ReactionPlayerCan Settings")]
    public PlayerCan playerCan;
    #endregion
    #region Methods

    protected override void React()
    {
        Control.playerCan = playerCan;
    }

    #endregion
}
