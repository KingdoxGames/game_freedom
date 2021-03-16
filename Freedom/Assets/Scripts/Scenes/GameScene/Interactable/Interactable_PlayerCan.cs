#region Access
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion
public partial class Interactable
{
    #region Variables
    [Header("_PlayerCan")]
    [Tooltip("player can move between the Reaction is happening?")]
    public bool canMove = true;
    public bool canRotate = true;
    public bool canClick = true;
    #endregion
    #region Methods
    //TODO falta los activadores/desactivadores
    #endregion
}