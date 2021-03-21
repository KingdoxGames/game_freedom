#region Access
using UnityEngine;
using XavHelpTo.Know;
using Environment;
using XavHelpTo.Change;
#endregion
public class SplashManager : MonoBehaviour
{
    #region Variable
    private float count;
    private bool flag;
    private float countToGo;
    [Header("SplashManager")]
    [Tooltip("Cuanto tiempo se esperará?")]
    [Range(2, 10)]
    public float timeInSplash;
    [Range(2, 10)]
    public float timeInToGo;
    [Tooltip("el Controlador que activaremos tras pasar el tiempo")]
    public ImageController imgCtrl_Splash;
    #endregion
    #region Event
    private void Update()
    {
        if (!flag)
        {
            if (timeInSplash.TimerFlag(ref flag, ref count))
            {
                imgCtrl_Splash.Invert();
            }
        }
        else if (timeInToGo.TimerIn(ref countToGo)) Change.ToScene(Scenes.MenuScene.ToInt());
    }
    #endregion
}