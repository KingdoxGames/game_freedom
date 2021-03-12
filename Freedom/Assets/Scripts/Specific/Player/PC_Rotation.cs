#region Access
using UnityEngine;
using XavHelpTo.Change;
#endregion
public partial class PlayerController
{
    #region Variables
    private Vector3 orientation;
    [Header("_Rotation")]
    public bool canRotate = true;
    #endregion
    #region Methods
    
    /// <summary>
    /// Check te rotation of the player
    /// </summary>
    partial void CheckOrientation(){
        orientation = transform.position.Axis(Y, transform.position.y)+ cam.transform.forward.Axis(Y).normalized;
        if (canRotate)
        {
            if (!axis_XY.Equals(Vector3.zero))
            {   
                Rotate();
            }
        }

    }

    /// <summary>
    /// Player rotates based on the camera forward the movements in axis
    /// </summary>
    void Rotate()
    {
        Quaternion toRotate = Quaternion.LookRotation(
            cam.transform.TransformDirection(axis_XY));
        toRotate.x = 0;
        toRotate.z = 0;
        transform.rotation = toRotate;
    }
    #endregion
}