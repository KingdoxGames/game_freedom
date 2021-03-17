#region Access
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavHelpTo.Look;
using XavHelpTo.Know;
using XavHelpTo.Set;
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
        [Space]
        [Range(-1,20)]
        [Tooltip("Nos permitirá modificar el evento para saber cuanto tiempo debe esperar hasta la siguiente, -1 significa que no usa tiempo")]
        public float waitSystem = -1;
        

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
        float _countTime = 0 ;

        while (
            ( !interactable.debug_continueReaction && waitSystem.Equals(-1) )
            || (!interactable.debug_continueReaction && !waitSystem.Equals(-1) && !waitSystem.TimerIn(ref _countTime))

            )
        {
            
            yield return new WaitForEndOfFrame();
        }
        "CONTINUAMOS LA REACCION".Print();
        interactable.debug_continueReaction = false;
        interactable.NextReaction();

    }


    #endregion
}

