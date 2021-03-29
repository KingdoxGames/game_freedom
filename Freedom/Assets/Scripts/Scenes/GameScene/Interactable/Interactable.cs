#region Usings
using UnityEngine;
using XavHelpTo.Change;
using XavHelpTo.Know;
using XavHelpTo;
#endregion
public partial class Interactable : MonoBehaviour
{
    #region Variables
    [HideInInspector] public bool debug_refreshTime;

    private bool isNear = false;
    //private bool needItems = false;
    [Tooltip("Si existe algún tipo de interacción, solo puede existir un solo momento de interacción")]
    private static bool isInteracting = false;
    private Collider col;
    [Header("Interactable Settigns")]
    public ParticleSystem eff_near;
    public Transform parent_reaction;
    [Space]
    public bool startInteraction = false;
    [Space]
    [Tooltip("Interactuar automaticamente si está cerca")]
    public bool nearInteract = false;
    [Space]
    public bool destroyWhenEnds = false;
    //[Space(20)]
    //public Color color;
    #endregion
    #region Events
    private void Awake() => this.Component(out col,false);
    private void Start()
    {   
        if (startInteraction) Interact();
    }
    private void Update()
    {
        CheckRequirements();
        if (!eff_near.IsNull()) eff_near.ActiveParticle(isNear);
        if (!col.IsNull()) col.enabled = isNear;

        if (nearInteract && IsInteractable) {
            Interact(); // only if is interactable triggering their  cercanies
        }



        //if (needItems)
        //{

        //}

    }
    private void OnMouseDown()
    {
        if (IsInteractable) Interact();
    }
#if true
    private void OnDrawGizmos(){
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, distanceRequired);
        if (!PlayerController.tr_player.IsNull()) Gizmos.DrawLine(transform.position, PlayerController.tr_player.position);
    }
#endif
    #endregion
    #region MEthods
    partial void Interact();
    partial void CheckRequirements();

    /// <summary>
    /// returns true wether is interactable
    /// </summary>
    private bool IsInteractable => Control.playerCan.pause && !isInteracting && isNear;

    /// <summary>
    /// Shows if is interacting
    /// </summary>
    public static bool Interacting => isInteracting;
    #endregion
}