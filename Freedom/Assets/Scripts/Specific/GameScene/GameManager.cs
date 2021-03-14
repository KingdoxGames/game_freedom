#region
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavHelpTo.Set;
using XavHelpTo.Get;
using XavHelpTo.Know;
#endregion
public class GameManager : MonoBehaviour
{
    #region Variable
    private static GameManager _;
    public static Camera cam = null;

    //[Header("Game Manager")]

    #endregion
    #region Events
    private void Awake(){
        this.Singletone(ref _, false);
        cam = cam.Default(Camera.main);
    }
    #endregion
    #region Methods


    #endregion
}
