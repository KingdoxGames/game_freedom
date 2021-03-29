#region Access
using UnityEngine;
using UnityEngine.UI;
using XavHelpTo;
using XavHelpTo.Set;
using XavHelpTo.Change;
using Environment;
#endregion
public class SideModalManager : MonoBehaviour
{
    #region Variable
    private const string TRIGGER_SHOW = "Show";
    private const string TRIGGER_HIDE = "Hide";
    private static SideModalManager _;
    private bool[] animsShowed; // init in false ordered with anim_sideModals
    [Header("SideModalManager")]
    [Space]
    public Image img_background; // se activa si hay un modal activo
    [Tooltip("Modal a mostrar al iniciar, -1 significa ninguno")]
    public int indexInit = -1;
    [Tooltip("Donde se poseerá los side modal ")]
    public Animator[] anim_sideModals;
    #endregion
    #region Event
    private void Awake() => this.Singleton(ref _, false);
    private void Start()
    {
        anim_sideModals.Length.NewIn(out animsShowed);
        anim_sideModals.ActiveObjects(true);
        ChangeModal(indexInit);
    }
    #endregion
    #region MEthod

    /// <summary>
    /// Disables all the modals except the selected
    /// </summary>
    public static void _ChangeModal(int showModal) => _.ChangeModal(showModal);
    public void ChangeModal(int showModal)
    {

        //Check if exist a showed modal(true);
        for (int i = 0; i < animsShowed.Length; i++)
        {
            if (animsShowed[i] && !i.Equals(showModal))
            {
                TriggerSideModal(i, TRIGGER_HIDE);
                animsShowed[i] = false;
            }

        }
        //animates the showed if does not exist
        if (!showModal.Equals(-1) && !animsShowed[showModal])
        {
            TriggerSideModal(showModal, TRIGGER_SHOW);
            animsShowed[showModal] = true;
        }

        img_background.enabled = !showModal.Equals(-1);

    }

    /// <summary>
    /// Only in <seealso cref="Scenes.GameScene"/>. Change the displayed text in end
    /// </summary>
    public static void ChangeEndText(in string key){
        //if (SceneManager.GetActiveScene().buildIndex.Equals(Scenes.GameScene.ToInt())) return; // 🛡
        _.ChangeModal(SideModalGame.END.ToInt());
        EndConfigurations end = FindObjectOfType<EndConfigurations>();
        string title = TranslateSystem.TranslationOf(Data.END_TITLE_KEY);
        string result = TranslateSystem.TranslationOf(key);


        end.FillWithText(title, result);


    }

    /// <summary>
    /// Set the trigger in the animation 
    /// </summary>
    private void TriggerSideModal(in int animIndex, in string trigger) => anim_sideModals[animIndex].SetTrigger(trigger);
    #endregion
}
public enum SideModalGame{PAUSE,OPTIONS,END}