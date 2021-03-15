#region Access
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavHelpTo.Set;
#endregion
public class DialogManager : MonoBehaviour
{

    #region Variables
    private DialogManager _;
    [Header("Dialog Manager Settings")]
    public GameObject pref_dialog;

    [Tooltip("if the dialog is opened")]
    public bool isInDialog;

    #endregion
    #region Events
    private void Awake()
    {
        this.Singletone(ref _, false);
    }
    #endregion
    #region Methods
    #endregion
}
