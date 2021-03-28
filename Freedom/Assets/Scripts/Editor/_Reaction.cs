#region Access
using UnityEngine;
using UnityEditor;
using XavHelpTo.Get;
#endregion
#region Editor
/// <summary>
/// Modify The Component in the InspectorGUI, passed to all his inheritances
/// </summary>
[CustomEditor(typeof(Reaction),true)]
internal class _Reaction : Editor{
    private Color lastColor;
    private void Awake() => lastColor = Get.RandomColor(.6f);
    public override void OnInspectorGUI(){
        // base.OnInspectorGUI();
        GUIStyle style = new GUIStyle(EditorStyles.textArea);
        Reaction r = target as Reaction;
        style.normal.textColor = lastColor;
        style.name = ".";//Hides the input area just a dumby hack ;)
        style.fontSize = 18;
        if (r.debug_information.Length.Equals(0)) r.debug_information = "Info : ";
        r.debug_information = GUILayout.TextField(r.debug_information, style);
        DrawDefaultInspector();

    }
}
#endregion