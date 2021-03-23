#region
using UnityEngine;
using Environment;
using XavHelpTo.Set;
using XavHelpTo.Know;
using XavHelpTo.Change;
using XavHelpTo.Get;
#endregion
public class GameManager : MonoBehaviour
{
    #region Variable
    private static GameManager _;
    private const float SCALE_TIME_HUD = 6f;
    [Header("Game Manager Settings")]
    public static Camera cam = null;
    public CanvasGroup canvasG_hud;
    #endregion
    #region Events
    private void Awake(){
        this.Singletone(ref _, false);
        cam = cam.Default(Camera.main);
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
    private void DisplayHud() => canvasG_hud.alpha = canvasG_hud.alpha.UnitInTime(Control.canPause.ToInt(), SCALE_TIME_HUD);
    /// <summary>
    /// Returns to the menú
    /// </summary>
    public void GoToMenu() => Scenes.MenuScene.ToInt().ToScene();
    /// <summary>
    /// Restarts the game in the last saved data 
    /// </summary>
    public void ReStart() => Scenes.GameScene.ToInt().ToScene();
    #endregion
}