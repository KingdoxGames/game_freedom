#region Access
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#endregion
[CustomEditor(typeof(ReactionDialog))]
public class _ReactionDialog : Editor
{
    #region Variables

    #endregion
    #region Events
    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();
    }
    #endregion
    #region Methods
    #endregion
}