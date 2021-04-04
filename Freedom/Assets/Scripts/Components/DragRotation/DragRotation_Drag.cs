#region Access
using UnityEngine;
using XavHelpTo.Know;
using XavHelpTo.Get;
using Environment;
#endregion
public partial class DragRotation
{
    #region Variable
    private const int ROTATION = 360;
    public const float axis_limit = 20f; // 20 init
    //[Header("_Drag")]
    //[Range(1f, Data.DRAG_SENSIBILITY_MAX)]
    //public static float sensibility = 3f; // default 3 private
    #endregion
    #region Partial Method
    /// <summary>
    /// Change the <see cref="axis_Y"/> with the movement of the drag
    /// </summary>
    partial void SetDrag(){
        if (!Control.HoldDrag) return;
        axis_Y += (Control.Axis_Y * DataPass.SavedData.dragSensibility).Limit(axis_limit);
        axis_Y = axis_Y.Limit(ROTATION).IsEqualOf(ROTATION, -ROTATION) ? 0 : axis_Y;
    }
    #endregion
}