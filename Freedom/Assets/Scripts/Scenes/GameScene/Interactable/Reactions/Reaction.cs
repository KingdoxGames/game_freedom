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
        [HideInInspector]
        public Interactable interactable;

        [Header("Reaction Settings")]
        public string debug_information;
        

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

        StartCoroutine(WaitReact());
        
        //....
    }


    /// <summary>
    /// Waits until an external thing advise to continue the reaction
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerator WaitReact()
    {
        while (!interactable.debug_continueReaction)
        {
            yield return new WaitForEndOfFrame();
        }
        "CONTINUAMOS LA REACCION".Print();
        interactable.debug_continueReaction = false;
        interactable.NextReaction();

    }


    #endregion
}

