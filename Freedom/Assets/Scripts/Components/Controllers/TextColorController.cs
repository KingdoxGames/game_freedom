#region Access
using UnityEngine;
using UnityEngine.UI;
using XavHelpTo.Look;
using XavHelpTo.Get;
using XavHelpTo.Know;
#endregion

public class TextColorController : MonoBehaviour
{
    #region Variables
    private float count;
    private const float TIMER = 5f;
    private string[] colors ={
        "white",
        "black",
        "magenta",
        "lightblue",
        "lime",
        "red",
        "yellow"
    };
    private string text;
    private Text txt;
    #endregion
    #region Events
    private void Awake()
    {
        this.Component(out txt);
        SetText(txt.text);
    }
    private void Update(){
        if (TIMER.TimerIn(ref count)) ChangeColor();
    }
    #endregion
    #region Methods
    /// <summary>
    /// Sets the new text
    /// </summary>
    private void SetText(string _text) => text = _text;
    /// <summary>
    /// Change the color of the displayed text
    /// </summary>
    private void ChangeColor() => txt.text = text.InColor(colors.Any());
    #endregion
}
