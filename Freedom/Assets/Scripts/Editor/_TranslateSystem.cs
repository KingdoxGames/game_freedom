#region Access
using UnityEngine;
using UnityEditor;
using Environment;
#endregion
#region Editor
[CustomEditor(typeof(TranslateSystem))]
public class _TranslateSystem : Editor
{
    GUIStyle style;
    private string advice = "Estas en debug Mode !";
    //revisamos si esta enable el modo edición

    public override void OnInspectorGUI(){
        TranslateSystem tr = target as TranslateSystem;
        if (tr.debug_mode)  {
            style = new GUIStyle(EditorStyles.textField);
            style.fontSize = 16;
            style.name = "";

            //DEBUG-> indica que estamos en Edición
            AssignText(ref advice);

            //File (ex: Spanish, English)
            //style.name = EditorStyles.textField.name;
            style.fontSize = 14;
            style.normal.textColor = Color.green;
            if (tr.debug_folder.Length.Equals(0)) tr.debug_folder = Data.DEFAULT_LANG; 
            tr.debug_folder = AssignText(ref tr.debug_folder);

            // Key (ex: xav, in_door_01)
            style.normal.textColor = Color.magenta;
            if (tr.debug_key.Length.Equals(0)) tr.debug_key = "lang";
            tr.debug_key = AssignText(ref tr.debug_key);


            //1. Cargamos el diccionario
                tr.InitLang(tr.debug_folder, "");

            string translated = (tr.dic_Lang is null)
                ? "Error => Archivo Incorrecto, coloca uno de los que existen en Resources/Lang/..."
                : tr.GetValueIn(tr.dic_Lang, tr.debug_key);
            ;
            translated = "Resultado => " + translated;

            style.fontSize = 12;
            style.normal.textColor = Color.red;
            style.wordWrap = true;
            translated = AssignText(ref translated);
        }

        tr.debug_mode = GUILayout.Button($"Debug Mode: {tr.debug_mode}") ? !tr.debug_mode : tr.debug_mode;

        DrawDefaultInspector();

    }


    private string AssignText(ref string txt, GUIStyle _style= default) => GUILayout.TextField(txt, _style ?? style);

}
#endregion