#region Access
using UnityEngine;
using XavHelpTo.Know;

#endregion
public partial class Interactable
{
    #region Variables
    [Header("_Requirements")]
    [Range(0, 5f)]
    public float distanceRequired = 0f; // where 0 == does not required
    //[Space]
    //public int[] itemsRequireds; TODO
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
            && Vector3.Distance(
                transform.position,
                PlayerController.tr_player.position
            ) <= distanceRequired
        ;
    }

    #endregion
}