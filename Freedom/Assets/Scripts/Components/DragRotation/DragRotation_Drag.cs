#region Access
using UnityEngine;
using XavHelpTo.Know;
using XavHelpTo.Get;
#endregion
public partial class DragRotation
{
    #region Variable
    private const float MAGNITUDE = 3f;
    private const int ROTATION = 360;
    [Header("_Drag")]
    [Range(10f, 20f)]
    public float axis_limit = 15f;
    #endregion
    #region Partial Method
    /// <summary>
    /// Change the <see cref="axis_Y"/> with the movement of the drag
    /// </summary>
    partial void SetDrag(){
        if (!Control.HoldDrag) return;
        axis_Y += (Control.Axis_Y * MAGNITUDE).Limit(axis_limit);
        axis_Y = axis_Y.Limit(ROTATION).IsEqualOf(ROTATION, -ROTATION) ? 0 : axis_Y;
    }
    #endregion
}