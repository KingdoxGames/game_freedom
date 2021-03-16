#region Access
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavHelpTo.Look;
#endregion
[DisallowMultipleComponent]
//[ExcludeFromPreset]
public class Reaction : MonoBehaviour
{
    #region Variables
        [Header("Reaction Settings")]
        public string debug_information;
        public Interactable interactable;
    #endregion
    #region Methods

    /// <summary>
    /// React with the interactable in case to be 
    /// </summary>
    protected virtual void React() => $"Reacción".Print("magenta");


    /// <summary>
    /// TODO
    /// </summary>
    public virtual void ExecuteReaction()
    {
        React();


        //....
    }


    #endregion
}

