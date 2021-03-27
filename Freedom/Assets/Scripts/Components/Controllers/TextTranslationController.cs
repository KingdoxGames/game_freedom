#region Access
using UnityEngine;
using UnityEngine.UI;
using XavHelpTo.Get;
using XavHelpTo.Know;
#endregion
[RequireComponent(typeof(Text))]
/// <summary>
/// Check if the current translation is different as the <seealso cref="DataPass"/> saved lang
/// </summary>
public class TextTranslationController : MonoBehaviour
{
    #region Variable
    private Text txt;
    [Header("TextTranslation Setting")]
    public string key;

    #region Debug Variables
    [HideInInspector] public bool isDebug = false;
    #endregion


    #endregion
    #region Events
    private void Awake(){
        isDebug = false;
        this.Component(out txt);
        ClearText();
    }
    private void OnEnable()
    {
        if (txt.IsNull()) this.Component(out txt);
        if (TranslateSystem.Inited) RefreshText();

        TranslateSystem.LangSubscribe += RefreshText;
    }
    private void OnDisable(){
        ClearText();
        TranslateSystem.LangSubscribe -= RefreshText;
    }
    #endregion
    #region Methodpda

    private void RefreshText() => txt.text = TranslateSystem.TranslationOf(key);

    private void ClearText() => txt.text = "";
    #endregion
}
