#region Access
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#endregion
public class EndConfigurations : MonoBehaviour
{
    #region Variables
    [Header("EndConfigurations Settings")]
    public TextTranslationController ttc_title;
    public TextTranslationController ttc_result;
    #endregion
    #region Methods
    /// <summary>
    /// Fills the texts with the entry strings
    /// </summary>
    public void FillWithText(in string title, in string result){
        ttc_title.SetText(title);
        ttc_result.SetText(result);
    }
    #endregion
}
