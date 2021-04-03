#region Access
using UnityEngine;
using XavHelpTo.Know;
using XavHelpTo.Get;
#endregion
[RequireComponent(typeof(Rigidbody))]
public partial class PlayerController : MonoBehaviour
{
    #region Variables

    private Vector3 axis_XY;
    private Rigidbody body;
    [Space]
    public static Transform tr_player;
    #endregion
    #region Events
    private void Awake()
    {
        this.Component(out tr_player);
        this.Component(out body);
    }
    private void FixedUpdate()
    {
        CheckPause();
        CheckAxisInputs();
        CheckMovements();
        CheckOrientation();
    }
#if DEBUG
    private void OnDrawGizmos()
    {
        if (tr_player.IsNull()) this.Component(out tr_player);

        //Gizmos.color = Color.blue;
        //Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5);

        //Gizmos.color = Color.white;
        //Gizmos.DrawLine(transform.position, orientation);

        //float distance = 2f;
        //Gizmos.DrawLine(transform.position - distance.ToAxis(), transform.position + distance.ToAxis());
        //Gizmos.DrawLine(transform.position - distance.ToAxis(2), transform.position + distance.ToAxis(2));
    }
#endif
    #endregion
    #region Methods
    /// <summary>
    /// updates the <see cref="axis_XY"/> wheter exist changes in <see cref="Control"/>
    /// </summary>
    private void CheckAxisInputs()
    {
        if (Control.playerCan.checkAxis) axis_XY.Set(Control.Axis_X, 0, Control.Axis_Z);
        else axis_XY.Set(0, 0, 0);
    }
    /// <summary>
    /// Detects if the player wants to open the pause modal
    /// </summary>
    private void CheckPause(){
        if (Control.PressBack){

            GameManager.SetPause(true);
        }
    }
    partial void CheckOrientation();
    partial void CheckMovements();
    #endregion
}
