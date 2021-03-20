﻿#region Access
using UnityEngine;
#endregion
public partial class PlayerController
{
    #region Methods
    
    /// <summary>
    /// Check te rotation of the player
    /// </summary>
    partial void CheckOrientation(){
        if (Control.canRotate && !axis_XY.Equals(Vector3.zero)) Rotate();
    }
    /// <summary>
    /// Player rotates based on the camera forward the movements in axis
    /// </summary>
    void Rotate()
    {
        Quaternion toRotate = Quaternion.LookRotation(
            GameManager.cam.transform.TransformDirection(axis_XY)
        );
        toRotate.x = 0;
        toRotate.z = 0;
        transform.rotation = toRotate;
    }
    #endregion
}