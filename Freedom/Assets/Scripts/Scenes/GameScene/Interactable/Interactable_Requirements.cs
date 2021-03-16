#region Access
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavHelpTo.Know;

#endregion
public partial class Interactable
{
    #region Variables
    [Header("_Requirements")]
    [Range(0, 5f)]
    public float distanceRequired = 0f;

    [Tooltip("Para saber en qué parte del acto estará disponible")]
    public int requiredInPart = 0;

    //TODO pasar esto a un Enum con sus objetos
    public string[] requiredObject;
    #endregion
    #region Methods



    /// <summary>
    /// Check the interaction between the target and the transform of this gameoobject
    /// </summary>
    partial void CheckRequirements()
    {
        //🛡
        if (PlayerController.tr_player.IsNull()) return;
        //🛡
        isNear = !PlayerController.tr_player.IsNull()
            && !eff_near.IsNull()
            && Vector3.Distance(transform.position,PlayerController.tr_player.position) <= distanceRequired
        ;
    }

    #endregion
}