#region Access
using UnityEngine;
using XavHelpTo;
using XavHelpTo.Change;
using XavHelpTo.Look;
using Environment;
#endregion
public class MenuManager : MonoBehaviour
{
    #region Variables
    private MenuManager _;
    [Header("MenuManager")]
    public GameObject obj_hide;
    public SideModalManager sideModal;

    #endregion
    #region Events
    private void Awake(){
        this.Singleton(ref _, false);
        obj_hide.SetActive(true);
    }
    private void Start()
    {
        SavedData _saved = DataPass.SavedData;

        if (!_saved.tutorialDone)
        {
            sideModal.ChangeModal(1);
            _saved.tutorialDone = true;
            DataPass.SetData(_saved);
            DataPass.SaveLoadFile(true);
        }
    }
    #endregion
    #region Methods

    /// <summary>
    /// Starts the game
    /// </summary>
    public void PlayGame()
    {
        $"Iniciar a jugar".Print("green");
        Change.ToScene(Scenes.GameScene.ToInt());
    }
    /// <summary>
    /// Close the game
    /// </summary>
    public void ExitGame(){
        $"Gracias por Jugar :)".Print("red");
        Application.Quit();
    }
    #endregion
}