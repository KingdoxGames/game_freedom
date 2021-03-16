#region Access
using UnityEngine;
using XavHelpTo.Set;

#endregion
public class DialogManager : MonoBehaviour
{

    #region Variables
    private static DialogManager _;
    [Header("Dialog Manager Settings")]
    public Modal pref_dialog;

    [Tooltip("if the dialog is opened")]
    public bool inDialog = false;

    #endregion
    #region Events
    private void Awake()
    {
        this.Singletone(ref _, false);
    }
    #endregion
    #region Methods

    public static void LoadModal( )
    {
        Message msg = new Message(
            "Xavier Arpa",
            "Esto es solo una prueba, en teoria deberia pintar lo que stoy escribiendo",
            Color.white
        );

       _.pref_dialog.AssignMessage(msg);

    }



    public static bool IsLoading() => _.inDialog;
    #endregion
}
