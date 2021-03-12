#region Access
using UnityEngine;
#endregion
public partial class PlayerController
{
    #region Variables

    private Vector3 axis_XY;
    [Header("_Movement")]
    public bool canMove = true;
    [Range(1,20f)]
    public float speed = 5;
    #endregion
    #region Methods
    /// <summary>
    /// Check the movements of the player based on the player inputs
    /// </summary>
    partial void CheckMovements(){
        if (canMove)
        {
            axis_XY.Set( Input.GetAxis(AXIS_X), 0, Input.GetAxis(AXIS_Z));

            if (!axis_XY.Equals(Vector3.zero)){
                Move();
            }

        }
        else axis_XY.Set(0,0,0);

    }
    /// <summary>
    /// Moves the player based on the <see cref="cam"/> and<see cref="axis_XY"/>
    /// </summary>
    void Move(){

        Vector3 direction = transform.forward;
        direction.y = 0;
        transform.position = Vector3.Lerp(
            transform.position,
            transform.position + direction,
            Time.deltaTime * speed
        );
    }
    #endregion
}