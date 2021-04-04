#region Access
using UnityEngine;
using XavHelpTo;
using UnityEngine.UI;
using XavHelpTo.Change;
using XavHelpTo.Set;
using XavHelpTo.Look;
using Environment;
#endregion
public class MenuManager : MonoBehaviour
{
    #region Variables
    private MenuManager _;
    private const string KEY_REPLAY = "menu_replay";
    [Header("MenuManager")]
    public GameObject obj_hide;
    public SideModalManager sideModal;
    [Space]
    [Header("End Game")]
    public TextTranslationController txtTransCtrl_play; // used to change the value if it reach..
    public GameObject obj_player;
    public GameObject[] obj_bars;
    public Image img_background;

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

        //si ha alcanzado el final
        if (_saved.reachEnd){
            //1. cambiamos el texto con el nuevo key 
            txtTransCtrl_play.key = KEY_REPLAY;
            txtTransCtrl_play.RefreshText();

            //2. cambiamos el fondo basado en el Extra que poseas
            /* haciendo referencia a la toma de desiciones con los lobos
             * obtendrás una pantalla distinta:
             * EXTRA 0 (los ves escapar) => pantalla en claro
             * EXTRA 1 (Escapas con ellos)=> Quitar unos barrotes
             * EXTRA 2 (los matas y tu safe) => pantalla rojiza
             * EXTRA 3 (Mueren los 3) => quitar algunos barrotes y pantalla rojiza
             */

            obj_player.SetActive(false);

            switch (_saved.currentExtra)
            {
                case 0:
                    img_background.ColorParam(ColorType.RGB, 1);
                    break;
                case 1:
                    obj_bars.ActiveObjects(false); // no barrotes
                    img_background.ColorParam(ColorType.RGB, 1);
                    break;
                case 2:
                    img_background.ColorParam(ColorType.RGB, 0).ColorParam(ColorType.r,1);
                    break;
                case 3:
                    obj_bars.ActiveObjects(false); // no barrotes
                    img_background.ColorParam(ColorType.RGB, 0).ColorParam(ColorType.r,1);
                    break;
            }
        }

    }
    #endregion
    #region Methods

    /// <summary>
    /// Starts the game
    /// </summary>
    public void PlayGame()
    {

        SavedData _saved = DataPass.SavedData;
        if (_saved.reachEnd){
            //limpiamos => acto, extra y reachEnd
            _saved.currentAct = 0;
            _saved.currentExtra = 0;
            _saved.reachEnd = false;
            DataPass.SetData(_saved);
            DataPass.SaveLoadFile(true);
        }

        //$"A jugar !".Print("green");
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
