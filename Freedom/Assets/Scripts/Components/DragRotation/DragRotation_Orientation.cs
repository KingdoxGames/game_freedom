#region Access
using UnityEngine;
using XavHelpTo.Know;
#endregion
public partial class DragRotation
{
    #region Variables
    private const float DELTA_SMOOTH = 0.1f;
    private const float ROTATION_X = 45f;
    [Header("_Orientation")]
    [Range(10f, 20f)]
    public float distance = 10f;
    #endregion
    #region Partial Methods
    /// <summary>
    /// Adjust the rotation based on the <see cref="GetEulerRotation"/>
    /// </summary>
    partial void SetRotation() => transform.rotation = Quaternion.Lerp(transform.rotation, GetEulerRotation, DELTA_SMOOTH);
    /// <summary>
    /// Determines the position of the target and then use their position in X,Z Pos
    /// to get a updated position with the <see cref="distance"/>
    /// </summary>
    partial void SetPosition() => transform.position = target.IsNull() ? transform.position : SmoothPosition;
    #endregion
    #region General Methods
    /// <returns>The <see cref="Quaternion.Euler"/> adding the <see cref="ROTATION_X"/> in x and 0 in z axis</returns>
    private Quaternion GetEulerRotation => Quaternion.Euler(ROTATION_X, axis_Y, 0f);
    /// <returns> The <see cref="ToPosition"/> with a <see cref="Vector3.Slerp(Vector3, Vector3, float)"/></returns>
    private Vector3 SmoothPosition => Vector3.Slerp(transform.position, ToPosition, DELTA_SMOOTH);
    /// <returns> The position based on the <seealso cref="target.position"/> and <see cref="GetEulerRotation"/> </returns>
    private Vector3 ToPosition => target.position + GetEulerRotation * (distance * Vector3.back);
    #endregion
}