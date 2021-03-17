#region Usings
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavHelpTo.Change;
using XavHelpTo.Know;
using XavHelpTo;
using XavHelpTo.Look;
#endregion
public partial class Interactable : MonoBehaviour
{
    #region Variables
    private bool isNear = false;
    private Collider col;
    private Queue<Reaction> reactions = new Queue<Reaction>();

    [Header("Interactable Settigns")]
    public ParticleSystem eff_near;
    public Transform parent_reaction;
    [Space]
    public Color color;
    [Space]
    public bool debug_continueReaction = false;

    #endregion
    #region Events
    private void Awake()
    {
        this.Component(out col);
    }
    private void Update()
    {
        CheckRequirements();

        if (!eff_near.IsNull()) eff_near.ActiveParticle(isNear);
        if (!col.IsNull()) col.enabled = isNear;
    }
    private void OnMouseDown()
    {
        if (isNear)
        {
            Interact();
        }
    }
#if DEBUG

    private void OnDrawGizmos(){

        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, distanceRequired);

        if (!PlayerController.tr_player.IsNull())
        {
            Gizmos.DrawLine(transform.position, PlayerController.tr_player.position);
        }

    }
#endif
    #endregion
    #region MEthods
    partial void Interact();
    partial void CheckRequirements();
    #endregion
}