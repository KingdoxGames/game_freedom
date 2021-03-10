using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavHelpTo.Look;
/// <summary>
/// DragRotation Can Move a GameObj and do rotations, looking another GameObj (default himself + Vector3.forward)
/// </summary>
public class DragRotation : MonoBehaviour
{

    const int DRAG_MOUSE_NUMBER = 1;
    const string MOUSE_AXIS_X = "Mouse X";

    #region Variables
    #endregion
    #region Events

    private void Update()
    {
        if (IsDragging())
        {

            Input.GetAxis(MOUSE_AXIS_X).Print();

        }
    }

    #endregion
    #region Methods

    /// <returns>Shows if is using the Drag</returns>
    private bool IsDragging() => Input.GetMouseButton(DRAG_MOUSE_NUMBER);


    #endregion
}
