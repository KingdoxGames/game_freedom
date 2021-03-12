#region Access
using UnityEngine;
using XavHelpTo.Get;
using XavHelpTo.Know;
#endregion
#region Partial Declaration
/// <summary>
/// TODO separar el drag en otro Script, y que ese altere "un eje" ó hacer una opcion para activar o no el drag..
/// DragRotation Can Move a GameObj and do rotations, looking another GameObj (default himself + Vector3.forward)
/// </summary>
public partial class DragRotation : MonoBehaviour
{
    private const int DRAG_MOUSE_INPUT = 1;
    private const string DRAG_MOUSE_X = "Mouse X";
    private const float ROTATION_X = 45f;

    [Header("Visual Axis")]
    public float axis_Y = 0f;

    [Space]
    [Header("Rotation Settings")]
    public float magnitude = 5f;
    [Range(0.1f, 20f)]
    public float axis_limit = 15f;
    [Range(0.1f,1f)]
    public float delta_time = 0.25f;
}
public partial class DragRotation
{
    [Header("Orbital Object")]
    public float distance = 20f;
    public Transform target;
}
#endregion
#region Partial Events
public partial class DragRotation{
    private void Start()
    {
        axis_Y = transform.localEulerAngles.y;
            
    }
    private void Update()
    {
        SetDrag();
    }
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
}

#endregion

#region Partial Methods
public partial class DragRotation{

    /// <summary>
    /// Adjust the rotation
    /// </summary>
    private void SetRotation()
    {
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            GetEulerRotation(),
            delta_time
        );
    }

    /// <summary>
    /// Change the <see cref="axis_Y"/> with the movement of the drag
    /// </summary>
    private void SetDrag()
    {
        if (Input.GetMouseButton(DRAG_MOUSE_INPUT))
        {
            axis_Y += (Input.GetAxis(DRAG_MOUSE_X) * magnitude).Limit(axis_limit);
            axis_Y = axis_Y.Limit(360);
            if (axis_Y.IsEqualOf(360, -360))
            {
                axis_Y = 0;
            }
        }
    }

    /// <summary>
    /// Determines the position of the target and then use their position in X,Z Pos
    /// to get a updated position with the <see cref="distance"/>
    /// </summary>
    private void SetPosition(){
        if (Know.IsNull(target)) return;

        Vector3 toPos = target.position
            + GetEulerRotation()
            * (distance * Vector3.back)
        ;

        transform.position = Vector3.Slerp(transform.position, toPos, delta_time);

    }

    /// <returns>The <see cref="Quaternion.Euler"/> adding the <see cref="ROTATION_X"/> in x and 0 in z axis</returns>
    private Quaternion GetEulerRotation() => Quaternion.Euler(ROTATION_X, axis_Y, 0f);
}
#endregion








