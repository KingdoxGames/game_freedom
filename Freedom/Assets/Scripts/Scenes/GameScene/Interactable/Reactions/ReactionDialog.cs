#region Access
using System.Collections;
using UnityEngine;
using XavHelpTo.Look;
using XavHelpTo.Know;
using DialogInteract;
#endregion
/// <summary>
/// Reacciones que van a hacer interacción con el <seealso cref="Modal"/>
/// </summary>
public class ReactionDialog : Reaction
{
    #region Variables

    [Header("_Dialog")]
    [Tooltip("Determina el comportamiento del dialogo, debemos esperar? podremos decidir cuando continuar? podemos llenar el texto?")]
    public DialogInteraction dialoginteraction = DialogInteraction.WAIT;
    [Tooltip("Mensaje que vamos a pintar en el dialogo")]
    public Message message;
    [Space]
    [Tooltip("Determina si cierra o abre el modal al culminar")]
    public bool closeLater = false;


    #endregion
    #region MEthods
    [ContextMenu("Mostrar Dialogo")]
    protected override void React()
    {
        //base.React();
        Modal._AssignMessage(this);
    }
    protected override IEnumerator WaitReact()
    {
        float _count = 0;
        bool _passTimeFlag = false;
        bool _keep = true;

        yield return new WaitForFixedUpdate();

        switch (dialoginteraction)
        {
            case DialogInteraction.WAIT:
                while (_keep){
                    yield return new WaitForFixedUpdate();
                    _keep = !waiTime.TimerFlag(ref _passTimeFlag, ref _count);
                }
                break;
            case DialogInteraction.WAIT_AND_CONTINUE:
                while (_keep)
                {
                    yield return new WaitForFixedUpdate();
                    _keep = !(waiTime.TimerFlag(ref _passTimeFlag, ref _count) && Control.PressAccept);
                    Modal.ShowContinueSign(in _passTimeFlag);
                }
                break;
            case DialogInteraction.CAN_FILL_TEXT:
                while (_keep)
                {
                    yield return new WaitForFixedUpdate();
                    _keep = CheckFillText(waiTime.TimerFlag(ref _passTimeFlag, ref _count));
                    Modal.ShowContinueSign(!Modal.IsLoading);
                    yield return new WaitForEndOfFrame();
                }
                break;
        }
        yield return new WaitForFixedUpdate();

        if (closeLater) Modal.DisplayModal(false);

        interactable.NextReaction();
    }
    /// <summary>
    /// Based wether is done or not the message proccess can fullLoad the text o pass
    /// </summary>
    /// <param name="isTextDone"></param>
    private bool CheckFillText(in bool isReady){
        bool _keep = true;
        if (isReady && Control.PressAccept ){
            if (Modal.IsLoading)Modal._FullLoadMessage();
            else _keep = false;
        }
        return _keep;
    }


    #endregion
}
namespace DialogInteract{
[System.Serializable]
public enum DialogInteraction { WAIT = 0, WAIT_AND_CONTINUE = 1, CAN_FILL_TEXT = 2 }
}