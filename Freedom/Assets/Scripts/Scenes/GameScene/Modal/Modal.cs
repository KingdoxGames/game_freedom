#region Access
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XavHelpTo;
using XavHelpTo.Set;
using XavHelpTo.Know;
using XavHelpTo.Change;
#endregion
[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
public partial class Modal : MonoBehaviour
{
    #region Variable
  
    private static Modal _;
    private Message messageActual;
    private bool isLoading = false;
    private Animator anim;

    [Header("Modal settings ")]
    public Image img_name;
    public Image img_dialog;
    [Space]
    public Text txt_name;
    public Text txt_dialog;



    #endregion
    #region Events
    private void Awake()
    {
        this.Singleton(ref _, false);
        this.Component(out anim);
    }
    private void Update()
    {

        CheckInputs();

        LoadMessage();

    }
    #endregion
    #region Method

    private void CheckInputs()
    {
        //si el jugador prsiona click izquierdo
        if (Input.GetMouseButtonDown(0))
        {
            //TODO

            //Carga el siguiente mensajé ó llena el texto
            if (isLoading)
            {

            }
            else
            {

            }
        }
        //permite hacer Skip con espacio
        if (Input.GetKey(KeyCode.Space))
        {
            //TODO Carga la siguiente reacción
        }
    }

    /// <summary>
    /// Assign a new message and replace another existent
    /// </summary>
    public static void AssignMessage(Message msg)
    {
        _.ClearMessage();

        _.txt_name.text = msg.name;
        _.messageActual = msg;

        _.isLoading = true;
        _.DisplayModal();
    }



    /// <summary>
    /// Show or hide the modal in Scene
    /// </summary>
    private void DisplayModal(bool showModal = true) => anim.SetTrigger(showModal ? "Show" : "Hide");




    #endregion
}


[System.Serializable]
public struct Message
{
    public string name;
    [TextArea]
    public string dialog;
    //public Color color;


    public Message(string name, string dialog)
    {
        this.name = name;
        this.dialog = dialog;
        //this.color = color;
    }


}