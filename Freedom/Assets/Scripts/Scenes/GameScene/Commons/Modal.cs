#region Access
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XavHelpTo.Get;
using XavHelpTo.Set;
using XavHelpTo.Know;
using XavHelpTo.Look;
using XavHelpTo.Change;
#endregion
public class Modal : MonoBehaviour
{
    #region Variable
    /// <summary>
    /// Muestra el arreglo con los mensajes
    /// </summary>
    //private string[] actualMessages;
    //private int actualIndex;

    public const float ratioTimer = 0.01f;
    private float ratioCount;

    private int index = 0;
    private Message messageActual;

    private bool isLoading = false;

    [Header("Modal settings ")]
    public Image img_name;
    public Image img_dialog;
    [Space]
    public Text txt_name;
    public Text txt_dialog;

    #endregion
    #region Events
    private void Update()
    {

        CheckInputs();
        if (isLoading && ratioTimer.TimerIn(ref ratioCount)){

            LoadMessage();
        }

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
        }
        //permite hacer Skip con espacio
        if (Input.GetKey(KeyCode.Space))
        {

        }
    }

    /// <summary>
    /// Assign a new message and replace another existent
    /// </summary>
    public void AssignMessage(Message msg){
        ClearMessage();

        txt_name.text = msg.name;
        img_name.color = msg.Color;
        img_dialog.color = msg.Color;
        messageActual = msg;

        isLoading = true;
    }
    public void ClearMessage(){
        txt_dialog.text = "";
        txt_name.text = "";
        ratioCount = 0;
        index = 0;

        isLoading = false;
    }

    /// <summary>
    /// Counts the time and adds a letter in the txt
    /// </summary>
    public void LoadMessage(){
        txt_dialog.text += messageActual.dialog[index++];

        if (txt_dialog.text.Length == messageActual.dialog.Length){
            "Terminado el dialogo".Print("green");
            isLoading = false;
        }
    }

    #endregion
}


public struct Message
{
    public string name;
    public string dialog;
    public Color Color;


    public Message(string name, string dialog, Color color) {
        this.name = name;
        this.dialog = dialog;
        this.Color = color;
    }


}