#region Access
using UnityEngine;
using Environment;
using XavHelpTo.Know;
using XavHelpTo.Get;
using XavHelpTo.Set;
#endregion
[RequireComponent(typeof(Rigidbody))]
public partial class PlayerController : MonoBehaviour
{
    #region Variables
    
    private Vector3 axis_XY;
    private Rigidbody body;
    [Space]
    public static Transform tr_player;

    [Header("Player Controller")]
    public bool CanCheckAxis = true;

    #endregion
    #region Events
    private void Awake()
    {
        this.Component(out tr_player);
        this.Component(out body);
    }
    private void FixedUpdate()
    {
        if (CanCheckAxis) axis_XY.Set(Control.Axis_X, 0, Control.Axis_Z);
        else axis_XY.Set(0, 0, 0);
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
    partial void CheckOrientation();
    partial void CheckMovements();
    #endregion
}
