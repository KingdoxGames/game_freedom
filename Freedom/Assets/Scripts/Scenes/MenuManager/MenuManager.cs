#region Access
using UnityEngine;
using ModalsMenu;
using XavHelpTo.Change;
using XavHelpTo.Look;
using XavHelpTo;
using XavHelpTo.Set;
#endregion
public class MenuManager : MonoBehaviour
{
    #region Variables
    public const string TRIGGER_SHOW = "Show";
    public const string TRIGGER_HIDE = "Hide";
    private MenuManager _;
    private bool[] animsShowed; // init in false ordered with anim_sideModals
    [Header("MenuManager")]
    public GameObject obj_hide;
    [Tooltip("Donde se poseerá los side modal ")]
    public Animator[] anim_sideModals;

    #endregion
    #region Events
    private void Awake(){
        this.Singleton(ref _, false);
        obj_hide.SetActive(true);
        anim_sideModals.Length.NewIn(out animsShowed);
        anim_sideModals.ActiveObjects(true);
    }
    private void Start()
    {
        ChangeModal(SideModalsMenu.MENU.ToInt());
    }
    #endregion
    #region Methods



    /// <summary>
    /// Close the game
    /// </summary>
    public void ExitGame(){
        $"Adios  :)".Print("magenta");
        Application.Quit();
    }

    /// <summary>
    /// Disables all the modals except the selected
    /// </summary>
    public void ChangeModal(int showModal){

        //Check if exist a showed modal(true);
        for (int i = 0; i < animsShowed.Length; i++)
        {
            if (animsShowed[i] && !i.Equals(showModal))
            {
                TriggerSideModal((SideModalsMenu)i, TRIGGER_HIDE);
                animsShowed[i] = false;
            }

        }


        //animates the showed if does not exist
        if (!animsShowed[showModal])
        {
            TriggerSideModal((SideModalsMenu)showModal, TRIGGER_SHOW);
            animsShowed[showModal] = true;
        }


    }
    /// <summary>
    /// Set the trigger in the animation 
    /// </summary>
    private void TriggerSideModal(in SideModalsMenu animIndex, in string trigger) => anim_sideModals[animIndex.ToInt()].SetTrigger(trigger);
    #endregion
}

namespace ModalsMenu{
    enum SideModalsMenu{
        MENU=0,
        TUTORIAL=1,
        Option=2
    }
}