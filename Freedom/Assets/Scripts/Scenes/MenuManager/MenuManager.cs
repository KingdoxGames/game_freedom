#region Access
using UnityEngine;
using XavHelpTo;
using XavHelpTo.Look;
#endregion
public class MenuManager : MonoBehaviour
{
    #region Variables
    private MenuManager _;
    [Header("MenuManager")]
    public GameObject obj_hide;
    public SideModalManager obj_modalManager;

    #endregion
    #region Events
    private void Awake(){
        this.Singleton(ref _, false);
        obj_hide.SetActive(true);
    }
    private void Start()
    {
        SavedData _saved = DataPass.SavedData;
        obj_modalManager.ChangeModal(_saved.tutorialDone ? 0 : 1);
        if (_saved.tutorialDone)
        {
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
    }
    /// <summary>
    /// Close the game
    /// </summary>
    public void ExitGame(){
        Application.Quit();
    }
    #endregion
}