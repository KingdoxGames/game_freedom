using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Where we have all the management of the inputs
/// </summary>
public static class Control
{
    #region Variables
    private const string TAG_AXIS_X = "Horizontal";
    private const string TAG_AXIS_Y = "Mouse X";
    private const string TAG_AXIS_Z = "Vertical";
    private const int DRAG_MOUSE_INPUT = 1;

    private static KeyCode back = KeyCode.Escape;
    #endregion
    #region Method
    ///<returns> Was Back Pressed? </returns>
    public static bool PressBack => KeyDown(back);

    ///<returns> Was Accept Pressed? </returns>
    public static bool PressAccept => KeyDown(KeyCode.Mouse0);

    ///<returns> Was Skip Pressed? </returns>
    public static bool PressSkip => KeyDown(KeyCode.Space);

    ///<returns> Is Dragging ? </returns>
    public static bool HoldDrag => Input.GetMouseButton(DRAG_MOUSE_INPUT);


    /// <returns> The axis pressed in x</returns>
    public static float Axis_X => Axis(TAG_AXIS_X);
    /// <returns> The axis pressed in y</returns>
    public static float Axis_Y => Axis(TAG_AXIS_Y);
    /// <returns> The axis pressed in z</returns>
    public static float Axis_Z => Axis(TAG_AXIS_Z);
    #endregion
    #region General Method
    /// <returns>returns true if the key was pressed in the frame</returns>
    private static bool KeyDown(in KeyCode key) => Input.GetKeyDown(key);
    /// <returns>Returns the axis of the key</returns>
    private static float Axis(in string key) => Input.GetAxis(key);
    #endregion
    /*
     * Notas: https://forum.unity.com/threads/difference-between-getbutton-getkey-and-getmousebutton.167567/
     * 
     * Input.GetKey se llama cada frame
     * Input.GetMouseButton se llama solo una vez hasta que este cambie a ser presionado
     * // Input.GetKey(KeyCode.Mouse1);
     * // Input.GetMouseButton(DRAG_MOUSE_INPUT);
     */
}
