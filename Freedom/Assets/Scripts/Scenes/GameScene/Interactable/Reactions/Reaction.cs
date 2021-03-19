#region Access
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavHelpTo.Look;
using XavHelpTo.Know;
using XavHelpTo.Set;
using Environment;
#endregion
[DisallowMultipleComponent]
//[ExcludeFromPreset]
public class Reaction : MonoBehaviour
{
    #region Variables
        [HideInInspector]
        public Interactable interactable;

        [Header("⚡️Reaction Settings")]
        public string debug_information;
        [Space]
        [Range(-1,20)]
        [Tooltip(
        "Nos permitirá modificar el evento para saber cuanto tiempo debe esperar hasta la siguiente,"
        + ". -1 significa que no usa tiempo")]
        public float waitSystem = -1;

    #endregion
    #region Methods

    /// <summary>
    /// Reaccionamos con la que estaba presente a la siguiente
    /// </summary>
    public virtual void ExecuteReaction()
    {
        React();

        StartCoroutine(WaitReact());

        //....
    }

    /// <summary>
    /// React with the interactable in case to be 
    /// </summary>
    protected virtual void React() => $"Reacción".Print("white");

    /// <summary>
    /// Waits until an external thing advise to continue the reaction
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerator WaitReact()
    {
        //yield return new WaitForEndOfFrame();

        //if ( false)//waitSystem < 0 &&
        //{
        //    bool _continue = false;
        //    while (!_continue)
        //    {
        //        yield return new WaitForEndOfFrame();
        //        _continue = !Control.PressAccept;
        //    }
        //}
        //else
        //{
        //}
        float _countTime = 0;
        while (!waitSystem.TimerIn(ref _countTime)) yield return new WaitForEndOfFrame();
        
        interactable.NextReaction();
    }



    #endregion
}

