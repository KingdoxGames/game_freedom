#region Access
using UnityEngine;
using UnityEditor;
using XavHelpTo.Change;
#endregion
[CustomEditor(typeof(ReactionScreen))]
public class _ReactionScreen : Editor
{
    #region Variables
    private static readonly string[] _screenTriggerMsg =
    {
        "Muestra la pantalla, pasando de negro a transparente el velo",
        "Esconde la pantalla, pasando de transparente a negro por completo",
        "Si coloco más effectos..."
    };
    #endregion
    #region Event
    public override void OnInspectorGUI(){
        DrawDefaultInspector();
        ReactionScreen r = target as ReactionScreen;
        GUILayout.Space(20);
        SetTypeMsg(in r);
        //base.OnInspectorGUI();
    }
    
    #endregion
    #region Methods

    private void SetTypeMsg(in ReactionScreen r)
    {
        GUIStyle style = new GUIStyle(EditorStyles.label);
        style.normal.textColor = Color.green;
        style.wordWrap = true;
        style.fontSize = 14;

        string message = $"{r.trigger}:   {_screenTriggerMsg[r.trigger.ToInt()]}";
        GUILayout.Label(message, style);

    }
    #endregion
}
