#region Usings
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavHelpTo.Change;
using XavHelpTo.Get;
using XavHelpTo.Look;
#endregion
[RequireComponent(typeof(BoxCollider))]
public partial class Interactable : MonoBehaviour
{
    #region Variables
    private BoxCollider box;
    private bool isNear = false;

    [Header("Interactable Settigns")]
    public Transform target;
    public ParticleSystem eff_near;

    #endregion
    #region Events
    private void Awake()
    {
        this.Component(out box);
    }
    private void Update()
    {
        CheckInteraction();
        eff_near.ActiveParticle(isNear);

    }
    private void OnMouseDown()
    {
        //TODO hacer un corroborador de si el el juego no está en un estado que no sea libre

        if (isNear)
        {
            "___Entró___".Print("red");
            openDialog(interactions.ZeroMax());

        }
    }
#if DEBUG

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceRequired);

    }
#endif
    #endregion
    #region MEthods


  

    #endregion
}
/*
 Quí tenemos que hacer que el bloque pueda interactuar como dialogo,
objeto o interruptor llamando al map actual y que este contenga la cadena de accioens
dependiendo del que sea
 */