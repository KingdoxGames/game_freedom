#region Usings
using UnityEngine;
using XavHelpTo.Change;
using XavHelpTo.Know;
using XavHelpTo;
using XavHelpTo.Look;
#endregion
public partial class Interactable : MonoBehaviour
{
    #region Variables
    [HideInInspector] public bool debug_refreshTime;

    private bool isNear = false;
    private bool haveItems = false;
    private bool haveExtra = false;
    private static bool isInteracting = false;
    private Collider col;

    [Header("Interactable Settigns")]
    public ParticleSystem eff_near;
    public Transform parent_reaction;

    [Space]
    public bool startInteraction = false; // iniciar interactuando
    public bool nearInteract = false; // interactuar si esta cerca
    public bool destroyWhenEnds = false; // eliminar interacción si termina
    public bool disableWhenEnds = false; //desactiva el elemento..
    #endregion
    #region Events
    private void Awake() => this.Component(out col,false);
    private void Start()
    {
        if (!parent_reaction)
        {
            $"No se ha colocado parent en {name} asignar uno !, por defecto colocaremos  el mismo :/".Print("red");
            parent_reaction = transform;
        }
        if (startInteraction) Interact();
    }
    private void Update(){

        CheckRequirements();
        if (!eff_near.IsNull()) eff_near.ActiveParticle(IsInteractable);
        if (!col.IsNull()) col.enabled = isNear;

        if (nearInteract && IsInteractable) {
            Interact(); // only if is interactable triggering their  cercanies
        }

    }
    private void OnMouseDown()
    {
        if (IsInteractable) Interact();
    }
#if true
    private void OnDrawGizmos(){
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, distanceRequired);
        //if (!PlayerController.tr_player.IsNull()) Gizmos.DrawLine(transform.position, PlayerController.tr_player.position);
    }
#endif
    #endregion
    #region MEthods
    partial void Interact();
    partial void CheckRequirements();

    /// <summary>
    /// returns true wether is interactable
    /// </summary> //Control.playerCan.pause &&
    private bool IsInteractable =>  !isInteracting && isNear && haveItems && haveExtra;

    /// <summary>
    /// Shows if is interacting
    /// </summary>
    public static bool Interacting => isInteracting;
    #endregion
}