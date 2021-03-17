#region Access
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavHelpTo.Look;
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

    [Tooltip("Determina si cierra o abre el modal")]
    public bool closeLater = false;

    #endregion
    #region MEthods
    protected override void React()
    {
        base.React();


        Modal._AssignMessage(this);


    }
    #endregion
}
