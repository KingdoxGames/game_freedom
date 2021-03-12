#region Access
using UnityEngine;
using XavHelpTo.Know;
#endregion
public partial class PlayerController : MonoBehaviour
{
    #region Variables
    private const string AXIS_X = "Horizontal";
    private const string AXIS_Z = "Vertical";
    private Vector3 axis_XY;
    private Camera cam = null;

    #endregion
    #region Events
    private void Awake()
    {
        if (Know.IsNull(cam)) cam = Camera.main;
    }
    private void Update(){
        axis_XY.Set(Input.GetAxis(AXIS_X), 0, Input.GetAxis(AXIS_Z));
        CheckOrientation();
    }
    private void FixedUpdate()
    {
        CheckMovements();
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
