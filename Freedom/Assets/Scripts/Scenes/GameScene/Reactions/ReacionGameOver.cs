#region Access
using System.Collections;
using UnityEngine;
#endregion
/// <summary>
/// Manages the screen of gameover
/// </summary>
public class ReacionGameOver : Reaction
{
    #region Variables
    [Tooltip("Nombre de la key a buscar")]
    //public string keyName_title; // poner uno por default
    public string keyName;

    public bool acceptedEnding = false;
    #endregion
    #region Events
#if UNITY_EDITOR
    public override void OnDrawGizmos(){
        name = $"GameOver: ({waiTime} s)";
        name += acceptedEnding ? " Accepted Ending " : "";
    }
#endif
    protected override void React(){
        if (!acceptedEnding) SideModalManager.ChangeEndText(in keyName);
        else GameManager._ShowEndGame(keyName);
    }
    protected override IEnumerator WaitReact()
    {
        yield return new WaitForSeconds(0);
        //return base.WaitReact();
    }
    #endregion
}