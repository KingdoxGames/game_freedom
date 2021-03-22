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
    [Header("Game Manager Settings")]
    public static Camera cam = null;
    #endregion
    #region Events
    private void Awake(){
        this.Singletone(ref _, false);
        cam = cam.Default(Camera.main);
    }
    #endregion
    #region Methods
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