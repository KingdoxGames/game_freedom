#region Access
using UnityEngine;
using XavHelpTo.Change;
#endregion
public partial class PlayerController
{
    #region Variables
    [Header("_Movement")]
    public bool canMove = true;
    [Range(1,200f)]
    public float speed = 5;
    [Range(1, 10f)]
    public float magnitude = 1;
    #endregion
    #region Methods
    /// <summary>
    /// Check the movements of the player based on the player inputs
    /// </summary>
    partial void CheckMovements(){
        if (canMove)
        {
            Move();
        }
    }
    /// <summary>
    /// Moves the player based on the <see cref="cam"/> and<see cref="axis_XY"/>
    /// </summary>
    void Move(){
        body.velocity = !axis_XY.Equals(Vector3.zero)
            ? transform.forward.Axis(1, 0) * Time.deltaTime * speed * magnitude
            : Vector3.zero;
    }
    #endregion
}