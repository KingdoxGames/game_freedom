#region Access
using UnityEngine;
using UnityEngine.UI;
using XavHelpTo;
#endregion
[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
public partial class Modal : MonoBehaviour
{
    #region Variable
  
    private static Modal _;
    private ReactionDialog dialog;
    private bool isLoading = false;
    private Animator anim;


    [Header("Modal settings ")]
    public Image img_name;
    public Image img_dialog;
    [Space]
    public Text txt_name;
    public Text txt_dialog;



    #endregion
    #region Events
    private void Awake()
    {
        this.Singleton(ref _, false);
        this.Component(out anim);
        isLoading = false;
    }
    private void Update()
    {
        LoadMessage();
    }
    #endregion
    #region Method
    /// <summary>
    /// Assign a new message and replace another existent
    /// </summary>
    public static void _AssignMessage(in ReactionDialog dialog) => _.AssignMessage(in dialog);
    private void AssignMessage(in ReactionDialog _dialog)
    {
        ClearMessage();

        dialog = _dialog;
        txt_name.text = _dialog.message.name;

        isLoading = true;
        DisplayModal();
    }

    /// <summary>
    /// Show or hide the modal in Scene
    /// </summary>
    public static void DisplayModal(in bool showModal) => _.DisplayModal(showModal);
    private void DisplayModal( bool showModal = true) => anim.SetTrigger(showModal ? "Show" : "Hide");

    ///<returns>Is Text Loading</returns>
    public static bool IsLoading => _.isLoading;
    #endregion
}


[System.Serializable]
public struct Message
{
    public string name;
    [TextArea]
    public string dialog;
    //public Color color;


    public Message(string name, string dialog)
    {
        this.name = name;
        this.dialog = dialog;
        //this.color = color;
    }


}