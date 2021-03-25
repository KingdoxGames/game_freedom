#region Access
using UnityEngine;
using UnityEngine.Events;
using Environment;
using XavHelpTo;
using XavHelpTo.Change;
using XavHelpTo.Set;

#endregion
/// <summary>
/// Manages the theatre and the order of the things , like managing the mapping, actions,
/// </summary>
[DisallowMultipleComponent]
public class TheatreManager : MonoBehaviour
{
    #region Variables
    private static TheatreManager _;
    [Header("Theather Manager Settigns")]
    public CanvasGroup canvasG_hud;
    public Animator anim_screen;
    public static UnityAction ActionRequirement;
    [Space]
    public int currentPart = -1;
    public string[] currentItems = new string[0];
    #endregion
    #region Events
    private void Awake()
    {
        this.Singleton(ref _,false);

        //Initialize the part and items size
        currentPart = 0;
        currentItems = new string[2];
    }
    private void Update()
    {
        DisplayHud();
    }
    #endregion
    #region Methods

    /// <summary>
    /// Shows or hides the HUD in scene, based of <see cref="Control.canPause"/>
    /// </summary>
    private void DisplayHud() => canvasG_hud.alpha = canvasG_hud.alpha.UnitInTime(Control.playerCan.pause.ToInt(), 5);

    /// <summary>
    /// Invoke all the <see cref="RequirementController"/> suscribed
    /// </summary>
    [ContextMenu("Actualiza todos los requerimientos")]
    public void RefreshRequirements(){
        ActionRequirement?.Invoke();
    }
    /// <summary>
    /// Returns the actual <see cref="currentPart"/>
    /// </summary>
    public static int CurrentPart => _.currentPart;
    /// <summary>
    /// Returns the actual <see cref="currentItems"/>
    /// </summary>
    public static string[] CurrentItems => _.currentItems;

    /// <summary>
    /// Assign a trigger eff in the <see cref="Animator"/> of the screen
    /// uses <seealso cref="ScreenTrigger"/> and <seealso cref="Data.SCREEN_TRIGGERS"/>
    /// </summary>    
    public static void TriggerScreen(ScreenTrigger trigger) =>_.anim_screen.SetTrigger(Data.SCREEN_TRIGGERS[trigger.ToInt()]);

    #endregion
}