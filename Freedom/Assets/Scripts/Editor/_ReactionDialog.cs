#region Access
using UnityEngine;
using UnityEditor;
using XavHelpTo.Change;
using DialogInteract;
#endregion
[CustomEditor(typeof(ReactionDialog))]
public class _ReactionDialog : Editor
{
    #region Variables
    private const string EXAMPLE_TEXT = "At quaeque adversarium ius, sed at integre persius verterem. Sit summo tibique at, eam et fugit complectitur, vis te natum vivendum mandamus. Iudico quodsi cum ad, dicit everti sensibus in sea, ea eius paulo deterruisset pri. Pro id aliquam hendrerit";
    private static readonly string[] dialogType ={
        "Esperamos el tiempo sin que podamos hacer algo (exceptuando el skip).",
        "Esperamos el tiempo correspondiente y luego le damos a aceptar para que podamos continuar. siempre tendrá que completarse el texto como minimo.",
        "Podemos esperar a que se llene el texto ó bien hacemos que se llene, para ir al siguiente mensaje debemos aceptar para continuar.",
        "..."
    };
    #endregion
    #region Events
    public override void OnInspectorGUI(){
        DrawDefaultInspector();
        ReactionDialog r = target as ReactionDialog;

        RefreshMsg();
        GUILayout.Space(20);
        SetTypeMsg(in r);
        GUILayout.Space(20);

        NameAndMessage(in r);

    }
   
    #endregion
    #region Methods
    /// <summary>
    /// Shows the translated message based on the <seealso cref="TranslateSystem"/>
    /// </summary>
    /// <param name="r"></param>
    private void NameAndMessage(in ReactionDialog r){
        TranslateSystem tr = FindObjectOfType<TranslateSystem>();
        tr.InitLang(tr.debug_folder, "");
        bool condition = (tr is null || tr.dic_Lang is null || !tr.debug_mode);

        //Name        
        GUIStyle style = new GUIStyle(EditorStyles.label);
        style.normal.textColor = Color.red;
        style.wordWrap = true;
        style.fontSize = 18;

        string resultName = !condition ? tr.GetValueIn(tr.dic_Lang,  r.message.NameKey) : "";
        string result = condition
            ? " [Error] => Revisar el TranslateSystem para ver la traducción... \\(+_+)/ )"
            : tr.GetValueIn(tr.dic_Lang, r.message.key)
        ;

        GUILayout.Label(resultName, style);
        GUILayout.Label(result, style);
        GUILayout.Space(20);
        if (!condition) CalcTimePerText(in result, in r);
        
    }
    /// <summary>
    /// Calculates the time to set all the text
    /// </summary>
    /// <param name="r"></param>
    private void CalcTimePerText(in string r, in ReactionDialog r2){
        GUIStyle style = new GUIStyle(EditorStyles.label);
        style.normal.textColor = Color.white;
        style.fontSize = 12;
        style.wordWrap = true;
        float time = (r.Length * Modal.ratioTimer);
        r2.finalTime = time > r2.waiTime ? time : r2.waiTime;
        GUILayout.Label($"Tiempo aprox: {r2.finalTime} s", style);
        GUILayout.Space(20);
        GUILayout.Label($"Longitud: {r.Length}/{EXAMPLE_TEXT.Length}", style);
    }
    /// <summary>
    /// Displays a message showing how much time its required
    /// </summary>
    private void RefreshMsg(){
        GUIStyle style = new GUIStyle(EditorStyles.label);
        style.normal.textColor = Color.yellow;
        GUILayout.Label($"Se refresca cada {ReactionDialog.NAME_TIMER} segundos aprox...", style);
    }
    /// <summary>
    /// Set the msg for the
    /// <see cref="DialogInteraction"/>
    /// </summary>
    private void SetTypeMsg(in ReactionDialog r){
        GUIStyle style = new GUIStyle(EditorStyles.label);
        style.normal.textColor = Color.green;
        style.wordWrap = true;
        string message = $"{r.dialoginteraction}:   {dialogType[r.dialoginteraction.ToInt()]}";
        GUILayout.Label(message, style);
    }
    #endregion
}