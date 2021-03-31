#region
using UnityEngine;
using Environment;
using XavHelpTo.Set;
using XavHelpTo.Change;
using XavHelpTo.Get;
#endregion
public class GameManager : MonoBehaviour
{
    #region Variable
    private static GameManager _;
    private Camera cam = null;
    public GameObject obj_cheatModal;
    #endregion
    #region Events
    private void Awake() {
        this.Singletone(ref _, false);
        cam = cam.Default(Camera.main);
    }
    private void Update()
    {

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Q))
        {
            CheatModal();
        }

    }
    #endregion
    #region Methods

    /// <summary>
    /// Enable/disable the cheats
    /// </summary>
    private void CheatModal() => obj_cheatModal.SetActive(!obj_cheatModal.activeInHierarchy);

    /// <summary>
    /// Returns to the menú
    /// </summary>
    public static void GoToMenu() => Scenes.MenuScene.ToInt().ToScene();
    /// <summary>
    /// Restarts the game in the last saved data 
    /// </summary>
    public static void ReStart() => Scenes.GameScene.ToInt().ToScene();
    /// <summary>
    /// Returns the camera in <see cref="cam"/>
    /// </summary>
    public static Camera Camera => _.cam;




    /// <summary>
    /// Used to debug in CheatModal
    /// Change and saves the act
    /// </summary>
    public void ActChange(float act) {
        SavedData saved = DataPass.SavedData;
        saved.currentAct = act.Round();
        Debug_SaveData(saved);
    }
    /// <summary>
    /// Used to debug in CheatModal
    /// Change the part
    /// </summary>
    public void PartChange(float part) => TheatreManager.SetPart(part.Round());
    /// <summary>
    /// Used to debug in CheatModal
    /// Change and saves the Extra
    /// </summary>
    public void ExtraChange(float extra)
    {
        SavedData saved = DataPass.SavedData;
        saved.currentExtra = extra.Round();
        Debug_SaveData(saved);
    }
    /// <summary>
    /// Used to debug in CheatModal
    /// Change  the item 1
    /// </summary>
    public void Item1Change(float item1) => TheatreManager.Debug_ItemChange(0, item1.Round());
    /// <summary>
    /// Used to debug in CheatModal
    /// Change  the item 2
    /// </summary>
    public void Item2Change(float item2) => TheatreManager.Debug_ItemChange(1, item2.Round());

    /// <summary>
    /// Shows the map and fade out the darker screen doing thir animation
    /// and takes the controls
    /// </summary>
    public void ToMap(float map){
        TheatreManager.TriggerScreen(ScreenTrigger.SHOW);
        Control.playerCan = new PlayerCan(true);
        MapManager.ChangeMap((Maps)map.Round());
    }

    /// <summary>
    ///  Used to Debug in CheatModal
    ///  saves the information
    /// </summary>
    private void Debug_SaveData(SavedData saved){
        DataPass.SetData(saved);
        DataPass.SaveLoadFile(true);
    }
    #endregion
}