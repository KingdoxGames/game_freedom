#region Access
using System.Collections;
using UnityEngine;
using XavHelpTo.Look;
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
    public override void OnDrawGizmos(){
        name = $"GameOver: ({waiTime} s)";


        name += acceptedEnding ? " Accepted Ending " : "";
    }
    protected override void React(){

        if (!acceptedEnding)
        {
            //GAME OVER SCENE
            SideModalManager.ChangeEndText(in keyName);
        }else{
            GameManager._ShowEndGame(keyName);
        }

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