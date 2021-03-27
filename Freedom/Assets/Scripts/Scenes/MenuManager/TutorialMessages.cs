#region Access
using UnityEngine;
using UnityEngine.UI;
using XavHelpTo.Know;
#endregion
public class TutorialMessages : MonoBehaviour
{
    #region Variables
    private int index_ToLoad = -1;
    private bool flag_IsDone;
    private float count_Loads;
    private const string DEFAULT_TEXT = "menu_tutorial_default";
    private const float ratio_Loads = 0.01f;
    private string loadingText;
    [Header("Tutorial Messages")]
    [Tooltip("Mensajes ordenados en e orden de los botones correspondientes")]
    public Text txt_message;
    [Space]
    [TextArea(3,6)]
    public string[] messages;
    #endregion
    #region Events
    private void Awake()
    {
        AssignText(-1);
    }
    private void Update() =>LoadInfo();
    #endregion
    #region Method
    /// <summary>
    /// Loads a <see cref="char"/> of the text, advise in <see cref="flag_IsDone"/> whether is Ended
    /// </summary>
    private void LoadInfo(){
        if (flag_IsDone || !ratio_Loads.TimerIn(ref count_Loads) || loadingText.Length.Equals(0)) return;//🛡
        txt_message.text += loadingText[txt_message.text.Length];
        if (txt_message.text.Equals(loadingText)) flag_IsDone = true;
    }
    /// <summary>
    /// Clear any pass text and Set the new text and starts to load it
    /// </summary>
    public void AssignText(int index=-1){
        if (index.Equals(index_ToLoad) && !index.Equals(-1)) return; //🛡
        txt_message.text = "";
        index_ToLoad = index;
        loadingText = TranslateSystem.TranslationOf(index_ToLoad.Equals(-1) ? DEFAULT_TEXT : messages[index_ToLoad]);
        flag_IsDone = false;
    }

    /// <summary>
    /// Clear the showed text
    /// </summary>
    public void ClearText()
    {
        txt_message.text = "";
        index_ToLoad = -1;
        flag_IsDone = true;
        loadingText = "";
    }
    #endregion
}

namespace TutorialButtons
{
    enum TutorialButtons
    {
        CONTROLS=0,
        SAVED=1,
        ELECTIONS=2
    }
}




/*
 * En caso de que Unity te lo borre
 * 
 * Controles => Para moverte usa 'W','A','S','D' y 'ESC' para pausar. puedes mover la camara arrastrando con 'Click derecho' del ratón. Se usa el botón 'Click izquierdo' para interactuar con los elementos del juego (prueba con los que brillan). 
 * Guardado => Cada cierto tiempo se guardará el juego, estos guardados frecuentarán veni con cada corte de una historia.
 * Elección => El jugador podrá tener la posibilidad de escoger qué hacer en algunos dialogos, teniendo que dar click a la opcion que desea. esto puede influir en la información recibida.
 */