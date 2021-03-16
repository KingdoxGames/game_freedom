#region Access
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavHelpTo.Look;
using XavHelpTo.Know;

#endregion
public partial class Modal
{
    #region Variable
    private float ratioCount;
    private int index = 0;

    [Header("_Text")]
    public const float ratioTimer = 0.01f;

    #endregion
    #region Method

    /// <summary>
    /// Counts the time and adds a letter in the txt if <see cref="isLoading"/> is <see cref="true"/>
    /// </summary>
    public void LoadMessage()
    {
        //🛡
        if (messageActual.IsNull()) return;
        //🛡

        if (!isLoading || !ratioTimer.TimerIn(ref ratioCount)) return;

        txt_dialog.text += messageActual.dialog[index++];

        if (txt_dialog.text.Length == messageActual.dialog.Length)
        {
            "Terminado el dialogo".Print("green");
            isLoading = false;
        }
    }

    /// <summary>
    /// Clear the modal
    /// </summary>
    public void ClearMessage()
    {
        txt_dialog.text = "";
        txt_name.text = "";
        ratioCount = 0;
        index = 0;

        isLoading = false;
    }
    #endregion
}