#region Access
using UnityEngine;
using XavHelpTo.Know;
using XavHelpTo.Look;
#endregion
public partial class Interactable
{
    #region Variables
    [Header("_Interaction")]
    [Tooltip("Muestra la interacción actual del objeto")]
    public int actualInteraction = -1;
    [Space]
    public Interaction[] interactions;

    #endregion
    #region Methods


    private void DialogAction()
    {
        if (isNear)
        {
            DialogManager.LoadModal();

            "___Entró___".Print("red");
            //openDialog(interactions.ZeroMax());
            //interactions[index].text.Print("blue");


        }
    }

    #endregion
}

/// <summary>
/// Estructura que se
/// </summary>
[System.Serializable]
public struct Interaction
{
    /// <summary>
    /// Descripción de la interacción
    /// </summary>
    public string UserName;
    /// <summary>
    /// Tipo de Interacción
    /// </summary>
    public Interact type;
    /// <summary>
    /// contenido a usar, este varía en función del tipo
    /// </summary>
    [TextArea(3,10)]
    public string text;
}


/// <summary>
/// Nos muestra el tipo de interacción
/// </summary>
public enum Interact
{
    NO=-1,
    DIALOG,//para mostrar un texto 
    OBJECT, //para saber que elemento equipar
    EVENT
}