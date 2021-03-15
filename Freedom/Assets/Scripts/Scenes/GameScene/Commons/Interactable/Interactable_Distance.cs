#region Access
using UnityEngine;
using XavHelpTo.Know;
#endregion
public partial class Interactable
{
    #region Variables
    [Header("_Distance")]
    [Range(0, 5f)]
    public float distanceRequired = 0f;
    #endregion
    #region Methods
    /// <summary>
    /// Check the interaction between the target and the transform of this gameoobject
    /// </summary>
    private void CheckInteraction()
    {
        isNear = (Know.IsNull(target) || Know.IsNull(eff_near))
            ? false
            : Vector3.Distance(transform.position, target.position) <= distanceRequired;
        ;

    }
    #endregion
}
