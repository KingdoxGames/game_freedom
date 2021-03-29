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
    #region Event
    public override void OnDrawGizmos()
    {
        string can = "";
        can += playerCan.checkAxis ? $" {nameof(playerCan.checkAxis)} " : "";
        can += playerCan.move ? $" {nameof(playerCan.move)} " : "";
        can += playerCan.rotate ? $" {nameof(playerCan.rotate)} " : "";
        can += playerCan.pause ? $" {nameof(playerCan.pause)} " : "";
        name = $"Can: ({waiTime} s) {can} -> {debug_information}";
    }
    #endregion
    #region Methods

    protected override void React()
    {
        Control.playerCan = playerCan;
    }

   // private string Checker(in bool condition) => condition ? $" {nameof(condition)} " : "";

    #endregion
}
