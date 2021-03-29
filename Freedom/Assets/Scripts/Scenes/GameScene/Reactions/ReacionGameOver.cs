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
    #endregion
    #region Events
    public override void OnDrawGizmos(){
        name = $"GameOver: ({waiTime} s)";
    }
    protected override void React(){
        //GAME OVER SCENE
        SideModalManager.ChangeEndText(in keyName);

    }
    protected override IEnumerator WaitReact()
    {
        yield return new WaitForSeconds(0);
        //return base.WaitReact();
    }
    #endregion
    #region Methods
    #endregion
}