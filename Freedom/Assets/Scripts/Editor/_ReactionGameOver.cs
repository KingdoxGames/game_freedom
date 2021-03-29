#region Access
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#endregion
[CustomEditor(typeof(ReacionGameOver))]
public class _ReactionGameOver : Editor
{
    #region Var
    #endregion
    #region Events
    public override void OnInspectorGUI()
    {
        ReacionGameOver r = target as ReacionGameOver;
        //base.OnHeaderGUI();
        DrawDefaultInspector();
        GUILayout.Space(20);
        Message(in r);
    }
    #endregion
    #region Methods

    private void Message(in ReacionGameOver r)
    {
        GUIStyle style = new GUIStyle(EditorStyles.label);
        style.normal.textColor = Color.red;
        style.wordWrap = true;
        style.fontSize = 16;

        TranslateSystem tr = FindObjectOfType<TranslateSystem>();
        tr.InitLang(tr.debug_folder, "");
        //if (r.message.key.Length.Equals(0)) r.message.key = "Missing";
        bool condition = (tr is null || tr.dic_Lang is null || !tr.debug_mode);
        string result = condition
            ? " [Error] => Revisar el TranslateSystem para ver la traducción... \\(+_+)/ )"
            : tr.GetValueIn(tr.dic_Lang, r.keyName)
        ;

        GUILayout.Label(result, style);

    }
    #endregion
}