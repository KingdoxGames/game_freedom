#region
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Environment;
using XavHelpTo.Set;
using XavHelpTo.Change;
using XavHelpTo.Get;
using XavHelpTo.Look;
#endregion
public class GameManager : MonoBehaviour
{
    #region Variable
    private static GameManager _;
    private Camera cam = null;
    public GameObject obj_cheatModal;
    [Space]
    public CanvasGroup canvas_endGame;
    public Text txt_endGameTitle;
    public Text txt_endGameInfo;
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
    /// Sets the game in pause
    /// </summary>
    public static void SetPause(bool wantPause){
        if (!Control.playerCan.pause && wantPause ) return; // 🛡

        Control.playerCan = new PlayerCan(!wantPause);
        SideModalManager._ChangeModal( wantPause ? 0 : -1);

    }


    /// <summary>
    /// Displays in screen the EndGame screen
    /// Insert the translations based on the key
    /// </summary>
    public static void _ShowEndGame(string key) => _.StartCoroutine(_.ShowEndGame(key));
    private IEnumerator ShowEndGame(string key){
        // 0. actualizamos el estado

        SavedData _saved = DataPass.SavedData;
        _saved.reachEnd = true;
        DataPass.SetData(_saved);
        DataPass.SaveLoadFile(true);

        // 1. activamos el objeto
        canvas_endGame.gameObject.SetActive(true);

        // 2. ponemos las traduccion
        txt_endGameTitle.text = TranslateSystem.TranslationOf(key + Data.END_GAME_TITLE_KEY);
        txt_endGameInfo.text = TranslateSystem.TranslationOf(key + Data.END_GAME_INFO_KEY);
        yield return new WaitForEndOfFrame();

        float limit = 1;
        // 3. mostramos lentamente en pantalla
        while (!canvas_endGame.alpha.Equals(limit)){
            canvas_endGame.alpha = canvas_endGame.alpha.UnitInTime(limit);
            yield return new WaitForEndOfFrame();
        }

        //"YOU WIN !".Print("magenta");
    }

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
        saved.currentAct = act.ToInt();
        Debug_SaveData(saved);
    }
    /// <summary>
    /// Used to debug in CheatModal
    /// Change the part
    /// </summary>
    public void PartChange(float part) => TheatreManager.SetPart(part.ToInt());
    /// <summary>
    /// Used to debug in CheatModal
    /// Change and saves the Extra
    /// </summary>
    public void ExtraChange(float extra)
    {
        SavedData saved = DataPass.SavedData;
        saved.currentExtra = extra.ToInt();
        Debug_SaveData(saved);
    }
    /// <summary>
    /// Used to debug in CheatModal
    /// Change  the item 1
    /// </summary>
    public void Item1Change(float item1) => TheatreManager.Debug_ItemChange(0, item1.ToInt());
    /// <summary>
    /// Used to debug in CheatModal
    /// Change  the item 2
    /// </summary>
    public void Item2Change(float item2) => TheatreManager.Debug_ItemChange(1, item2.ToInt());

    /// <summary>
    /// Shows the map and fade out the darker screen doing thir animation
    /// and takes the controls
    /// </summary>
    public void ToMap(float map){
        TheatreManager.TriggerScreen(ScreenTrigger.SHOW);
        Control.playerCan = new PlayerCan(true);
        MapManager.ChangeMap((Maps)map.ToInt());
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