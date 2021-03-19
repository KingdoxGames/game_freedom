#region Access
using UnityEngine;
#endregion
public partial class DragRotation : MonoBehaviour
{
    #region Variables
    [Header("DragRotation Settings")]
    public Transform target;
    [Space]
    [Range(-360f,360f)]
    public float axis_Y = 0f;
    #endregion
    #region Events
    private void Start() => axis_Y = transform.localEulerAngles.y;
    private void Update() => SetDrag();
    private void FixedUpdate()
    {
        SetRotation();
        SetPosition();
    }
#if false
    private void OnDrawGizmos()
    {
        if (Know.IsNull(target)) return;
        //Puntos entre la dirección de la camara y la dirección que debería observar
        Debug.DrawLine(transform.position, target.position, Color.red);
    }
#endif
    #endregion
    #region Methods
    partial void SetDrag();
    partial void SetRotation();
    partial void SetPosition();
    #endregion
}