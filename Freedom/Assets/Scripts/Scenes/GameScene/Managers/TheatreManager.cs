#region Access
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Environment;
using XavHelpTo;
using XavHelpTo.Look;
using XavHelpTo.Get;
using XavHelpTo.Know;
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
    public int[] currentItems = new int[Data.EQUIP_QTY];
    [Space]
    [Tooltip("Visualización de los elementos")]
    public Image[] img_equippeds = new Image[Data.EQUIP_QTY];

    #endregion
    #region Events
    private void Awake()
    {
        this.Singleton(ref _,false);

        //Initialize the part and items size
        currentPart = 1;
        currentItems = new int[Data.EQUIP_QTY];
    }
    private void Update()
    {
        DisplayHud();
    }
    private void OnDrawGizmos(){
        if (!img_equippeds.Length.Equals(Data.EQUIP_QTY)) img_equippeds = new Image[Data.EQUIP_QTY];
        if (!currentItems.Length.Equals(Data.EQUIP_QTY)){
            currentItems = Data.EQUIP_QTY.FillWith(0);
        }

    }
    #endregion
    #region Methods


    /// <summary>
    /// Refresh the images into the HUD, where the images are the equipped elements
    /// </summary>
    [ContextMenu("Refrescar Items")]
    private void RefreshEquippedImages(){

        for (int x = 0; x < Data.EQUIP_QTY; x++){
            if (Know.IsOnBounds(currentItems[x], Data.ITEM_QTY)) {
                img_equippeds[x].sprite = Resources.Load($"{Data.PATH_SPRITES}Item_{currentItems[x]}",typeof(Sprite)) as Sprite;
            }else{
                $"{nameof(TheatreManager)} {nameof(RefreshEquippedImages)} Error => item fuera de los limites => {img_equippeds[x]}".Print("red");
            }
        }

    }

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
    public static void SetPart(in int i) => _.currentPart = i;
    /// <summary>
    /// Returns the actual <see cref="currentItems"/>
    /// </summary>
    public static int[] CurrentItems => _.currentItems;
    /// <summary>
    /// Set the new item in the currentArray
    /// </summary>
    public static void SetItem(int item, bool addItem = true){

        int finder = (addItem ? 0 : item);
        int value = addItem ? item : 0;
        int _index = Know.IndexOf(_.currentItems, 0, finder);
        bool needRefresh = !_index.Equals(-1);

        if (needRefresh){
            _.currentItems[_index] = value;
            _.RefreshEquippedImages();
        }else{
            string errMsg = addItem
                ? $"No se pudo añadir el item por falta de espacios..."
                : $"No se pudo eliminar el item por que no existe !"
            ;
            $"{nameof(TheatreManager)}_{nameof(SetItem)} Error:  {errMsg} => {item}".Print("red");
        }
    }
    /// <summary>
    /// Assign a trigger eff in the <see cref="Animator"/> of the screen
    /// uses <seealso cref="ScreenTrigger"/> and <seealso cref="Data.SCREEN_TRIGGERS"/>
    /// </summary>    
    public static void TriggerScreen(ScreenTrigger trigger) =>_.anim_screen.SetTrigger(Data.SCREEN_TRIGGERS[trigger.ToInt()]);

    #endregion
}