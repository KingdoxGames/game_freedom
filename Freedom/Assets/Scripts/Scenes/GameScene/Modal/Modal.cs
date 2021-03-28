#region Access
using UnityEngine;
using UnityEngine.UI;
using XavHelpTo;
using XavHelpTo.Set;
using XavHelpTo.Change;
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
    [Space]
    public Image img_continueSign;
    [Space]
    public GameObject obj_name;



    #endregion
    #region Events
    private void Awake()
    {
        this.Singleton(ref _, false);
        this.Component(out anim);
        
        isLoading = false;
    }
    private void Start(){
        ShowContinueSign(false);
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
        ShowContinueSign(false);
        obj_name.SetActive(!_dialog.message.name.Equals(""));
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

    ///<returns>Show or hide the ContinueSign</returns>
    public static void ShowContinueSign(in bool show = true) => _.img_continueSign.ColorParam(ColorType.a, show.ToInt());//(!isLoading).ToInt()

    #endregion
}


[System.Serializable]
public struct Message
{
    public string name;
    public string key;
    private string dialog;
    //public Color color;

    public Message(string name, string key)
    {
        this.name = name;
        this.key = key;
        this.dialog = TranslateSystem.TranslationOf(key);
        //this.color = color;
    }

    public string Dialog => dialog ?? (dialog = TranslateSystem.TranslationOf(in key));//.Print("green")
}