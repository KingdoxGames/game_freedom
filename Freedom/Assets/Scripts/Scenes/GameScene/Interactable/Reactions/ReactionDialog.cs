#region Access
using System.Collections;
using UnityEngine;
using XavHelpTo.Look;
using XavHelpTo.Know;
#endregion
/// <summary>
/// Reacciones que van a hacer interacción con el <seealso cref="Modal"/>
/// </summary>
public class ReactionDialog : Reaction
{
    #region Variables
    [Header("_Dialog")]
    [Tooltip("Mensaje que vamos a pintar en el dialogo")]
    public Message message;
    [Space]
    [Tooltip("Determina si el jugador puede llenar al instante el texto del dialogo")]
    public bool canFillText = true;
    [Tooltip("Determina si cierra o abre el modal al culminar")]
    public bool closeLater = false;


    #endregion
    #region MEthods
    [ContextMenu("Mostrar Dialogo")]
    protected override void React()
    {
        base.React();
        //Contactas con el modal para mostrar los dialogos de los mensajes
        Modal._AssignMessage(this);
    }
    protected override IEnumerator WaitReact()
    {
        float _count = 0;
        bool _passTimeFlag = false;
        bool _keep = true;

        yield return new WaitForFixedUpdate();

        if (canFillText){
            while (_keep) {
                yield return new WaitForFixedUpdate();
                _keep = CheckFillText(waiTime.TimerFlag(ref _passTimeFlag, ref _count));
                yield return new WaitForEndOfFrame();
            }
        }else{
            while (_keep){
                yield return new WaitForFixedUpdate();
                //si el jugador espera hasta que complete el texto y acepta para seguir
                //if (waiTime.TimerFlag(ref _passTimeFlag, ref _count) && Control.PressAccept)
                //{
                //    "Continuar luego del texto".Print("blue");
                //    // TODO
                //    // continuar a la siguiente reaccion
                //}
            }
        }

        "Sale".Print();
        Modal.DisplayModal(false);
    }




    /// <summary>
    /// Based wether is done or not the message proccess can fullLoad the text o pass
    /// </summary>
    /// <param name="isTextDone"></param>
    private bool CheckFillText(in bool isReady){
        if (isReady && Control.PressAccept ){

            $" Modal.IsLoading {Modal.IsLoading}, ".Print("red");
            if (Modal.IsLoading ){   
                Modal._FullLoadMessage();
            }else{
                return false;
            }
        }
        return true;
    }


    #endregion
}
