#region Access
using UnityEngine;
using XavHelpTo.Know;
using XavHelpTo.Look;
using XavHelpTo.Get;
using XavHelpTo.Change;
#endregion

public class RequirementController : MonoBehaviour
{
    #region Variables
    [Header("Requirements Controller Settings ")]
    public bool checkOnStart = true;

    [Header("Requirements")]

    [Tooltip("El acto en el que se requiere que se encuentre")]
    [Range(-1, 7)]
    public int act = -1;

    [Tooltip("La parte de la se requiere que se encuentre")]
    [Range(-1, 4)]
    public int part = 1;

    [Tooltip("Los items requeridos, el maximo debe ser igual a la cantidad maxima de objetos que puede portar el personaje")]
    public string[] items = new string[0];


    [Header("Elements EnableDisabled by requirements status")]
    //Elementos que serán activados cuando se cumpla las condiciones
    public Transform[] childs;

    #endregion
    #region Events
    private void Awake(){transform.Components(out childs);}
    private void Start(){if (checkOnStart) RefreshElements();}
    private void OnEnable()
    {
        TheatreManager.ActionRequirement += RefreshElements;

    }
    private void OnDisable()
    {
        TheatreManager.ActionRequirement -= RefreshElements;
    }
    #endregion
    #region Methods
    /// <summary>
    /// Updates all the elements in <see cref="obj_elements"/>
    /// </summary>
    [ContextMenu("RefrescarElementos")]
    public void RefreshElements() => childs.ActiveObjects(CheckedRequirements);
    /// <summary>
    /// Check if all the requirements are done, then enables all teh obj_elemts
    /// </summary>
    private bool CheckedRequirements => IsOnAct && IsOnPart && CheckObjects;
    /// <summary>
    /// Returns true if required is granted or if it does not have.
    /// uses <see cref="IsUsed{T}(T)"/>
    /// </summary>
    private bool IsOnAct => IsUsed(act, DataPass.SavedData.currentAct);

    /// <summary>
    /// Returns true if required is granted or if it does not have.
    /// uses <see cref="IsUsed{T}(T)"/>
    /// </summary>
    private bool IsOnPart => IsUsed(part, TheatreManager.CurrentPart);

    /// <summary>
    /// Confirm if all the elements
    /// </summary>
    private bool CheckObjects => items.Length.Equals(0) || TheatreManager.CurrentItems.Contains(items);

    /// <summary>
    /// Based on the value, check if is used, the detection is based in set -1 in ints or else void string
    /// </summary>
    private bool IsUsed<T>(T t, T t2) {
        string val = t.ToString();
        return val.Equals("-1") || val.Equals("") || t.Equals(t2);
    }
    #endregion
}