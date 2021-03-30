#region Access
using UnityEngine;
using UnityEngine.UI;
using Environment;
using XavHelpTo;
using XavHelpTo.Look;
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
    public CanvasGroup canvas_name;
    public CanvasGroup canvas_text;
    public CanvasGroup canvas_continueSign;
    
    #endregion
    #region Events
    private void Awake()
    {
        this.Singleton(ref _, false);
        this.Component(out anim);
        StartOptions();
        
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

        //_dialog.message.Name.Print("green");
        //_dialog.message.Dialog.Print("green");

        canvas_name.alpha = (!_dialog.message.Name.Equals("")).ToInt();
        canvas_text.alpha = 1;
        canvas_continueSign.alpha = 1;

    dialog = _dialog;
        txt_name.text = _dialog.message.Name;
        isLoading = true;
        DisplayModal();
    }

    /// <summary>
    /// Show or hide the modal in Scene
    /// </summary>
    public static void DisplayModal(in bool showModal) => _.DisplayModal(showModal);
    private void DisplayModal( bool showModal = true) => anim.SetTrigger(showModal ? Data.SCREEN_TRIGGERS[ScreenTrigger.SHOW.ToInt()] : Data.SCREEN_TRIGGERS[ScreenTrigger.HIDE.ToInt()]);
    ///<returns>Is Text Loading</returns>
    public static bool IsLoading => _.isLoading;
    ///<returns>Show or hide the ContinueSign</returns>
    public static void ShowContinueSign(in bool show = true) => _.img_continueSign.ColorParam(ColorType.a, show.ToInt());//(!isLoading).ToInt()
    #endregion
    #region Partial Actions
    partial void LoadMessage(); // _Text
    partial void StartOptions(); // _Options
    #endregion
}


[System.Serializable]
public struct Message
{
    public NameChat chatName;
    public string key;

    private string name;
    private string dialog;
    //public Color color;

    public Message(NameChat chatName, string key)
    {
        //assign the keys
        this.key = key;
        this.chatName = chatName;

        //set the translations
        this.name = TranslateSystem.TranslationOf(Data.NAMECHAT_KEY + chatName.ToInt());
        this.dialog = TranslateSystem.TranslationOf(key);
        //this.color = color;
    }


    /// <summary>
    /// Shows the name and if does not exist any text keeps in blank
    /// </summary>
    public string Name => name ?? (name = TranslateSystem.TranslationOf(NameKey));

    public string NameKey => Data.NAMECHAT_KEY + chatName.ToInt();

    /// <summary>
    /// Shows the Dialog or in case if does not exist the translation
    /// </summary>
    public string Dialog => dialog ?? (dialog = TranslateSystem.TranslationOf(in key));//.Print("green")
}

[System.Serializable]
public enum NameChat{
    NO = -1,
    EVA_DOAN = 0,
    GUARD = 1,
    NOL_MA = 2,
    VUELTITAS = 3,
    FABRI_DOAN = 4,
    PRISSONNER = 5,
    WARLOCK = 6,
    GUARD_BOSS = 7,
    PEOPLE = 8, // Ciudadanos
    KING = 9
}