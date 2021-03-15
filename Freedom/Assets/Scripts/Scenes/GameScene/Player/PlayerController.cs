#region Access
using UnityEngine;
using Environment;
using XavHelpTo.Know;
using XavHelpTo.Get;
#endregion
[RequireComponent(typeof(Rigidbody))]
public partial class PlayerController : MonoBehaviour
{
    #region Variables
    public const string TAG_AXIS_X = "Horizontal";
    public const string TAG_AXIS_Z = "Vertical";
    private Vector3 axis_XY;
    private Rigidbody body;
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
        if (CanCheckAxis) axis_XY.Set(Input.GetAxis(TAG_AXIS_X), 0, Input.GetAxis(TAG_AXIS_Z));
        else axis_XY.Set(0, 0, 0);
        CheckMovements();
        CheckOrientation();
    }
#if false
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, orientation);

        float distance = 2f;
        Gizmos.DrawLine(transform.position - distance.ToAxis(), transform.position + distance.ToAxis());
        Gizmos.DrawLine(transform.position - distance.ToAxis(2), transform.position + distance.ToAxis(2));
    }
#endif
    #endregion
    #region Methods
    partial void CheckOrientation();
    partial void CheckMovements();
    #endregion
}
