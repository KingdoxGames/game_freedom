#region Access
using UnityEngine;
using XavHelpTo.Get;
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
    public void LoadMessage(){
        if (dialog.IsNull() || !isLoading || !ratioTimer.TimerIn(ref ratioCount)) return;//🛡

        int _length = dialog.message.dialog.Length;
        txt_dialog.text += dialog.message.dialog[index++.Max(_length - 1)];
        isLoading = !txt_dialog.text.Length.Equals(_length);
    }
    /// <summary>
    /// Fullyfill the <see cref="UnityEngine.UI.Text"/> of <see cref="txt_dialog"/>
    /// </summary>
    public static void _FullLoadMessage() => _.FullLoadMessage();
    private void FullLoadMessage(){
        isLoading = false;
        txt_dialog.text = dialog.message.dialog;
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