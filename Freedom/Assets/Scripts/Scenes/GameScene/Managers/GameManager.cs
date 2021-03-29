#region
using UnityEngine;
using UnityEngine.SceneManagement;
using Environment;
using XavHelpTo.Set;
using XavHelpTo.Look;
using XavHelpTo.Change;
using XavHelpTo.Get;
#endregion
public class GameManager : MonoBehaviour
{
    #region Variable
    private static GameManager _;
    private Camera cam = null;
    
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
    public static void GoToMenu() => Scenes.MenuScene.ToInt().ToScene();
    /// <summary>
    /// Restarts the game in the last saved data 
    /// </summary>
    public static void ReStart() => Scenes.GameScene.ToInt().ToScene();
    /// <summary>
    /// Returns the camera in <see cref="cam"/>
    /// </summary>
    public static Camera Camera => _.cam;

    #endregion
}