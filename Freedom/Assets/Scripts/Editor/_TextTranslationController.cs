#region Access
using UnityEngine;
using UnityEditor;
#endregion
#region
/// <summary>
/// if is enable(true) the debug mode of <seealso cref="TranslateSystem.debug_mode"/>
/// then you can recognize if the key is right and display the information of the key
/// </summary>
[CustomEditor(typeof(TextTranslationController))]
public class _TextTranslationController : Editor
{
    
    
    public override void OnInspectorGUI(){
        

        TextTranslationController ttc = target as TextTranslationController;

        //Button DebugMode
        ttc.isDebug = GUILayout.Button($"Debug Mode: {ttc.isDebug}") ? !ttc.isDebug : ttc.isDebug;

        DrawDefaultInspector();

        //Mostramos el resultado
        if (ttc.isDebug){


            TranslateSystem tr = FindObjectOfType<TranslateSystem>();
            tr.InitLang(tr.debug_folder, "");
            if (ttc.key.Length.Equals(0)) ttc.key = "lang"; 
            string result = (tr is null || tr.dic_Lang is null || !tr.debug_mode)
                ? " [Error] => Revisar el TranslateSystem"
                : tr.GetValueIn(tr.dic_Lang, ttc.key)
            ;





            GUIStyle style = new GUIStyle(EditorStyles.label);
            
            //Folder
            GUILayout.Space(20);
            style.fontSize = 10;
            style.normal.textColor = Color.green;
            GUILayout.Label($"[Folder] => {tr.debug_folder}", style);
            //Key
            style.fontSize = 12;
            style.normal.textColor = Color.magenta;
            GUILayout.Label($"[Key] => {ttc.key}", style);

            // result
            GUILayout.Space(20);
            style.fontSize = 14;
            style.wordWrap = true;
            style.normal.textColor = Color.red;
            GUILayout.Label($"[Resultado] => {result}", style);
        }
    }
}
#endregion