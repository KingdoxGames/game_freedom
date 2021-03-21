#region Access
using UnityEngine;
using XavHelpTo;
using XavHelpTo.Set;
using XavHelpTo.Change;
#endregion
public class SideModalManager : MonoBehaviour
{
    #region Variable
    public const string TRIGGER_SHOW = "Show";
    public const string TRIGGER_HIDE = "Hide";
    private SideModalManager _;
    private bool[] animsShowed; // init in false ordered with anim_sideModals
    [Header("SideModalManager")]
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
        if (!indexInit.Equals(-1))
        {
            ChangeModal(indexInit);
        }
    }
    #endregion
    #region MEthod

    /// <summary>
    /// Disables all the modals except the selected
    /// </summary>
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
    }

    /// <summary>
    /// Set the trigger in the animation 
    /// </summary>
    private void TriggerSideModal(in int animIndex, in string trigger) => anim_sideModals[animIndex].SetTrigger(trigger);
    #endregion
}
