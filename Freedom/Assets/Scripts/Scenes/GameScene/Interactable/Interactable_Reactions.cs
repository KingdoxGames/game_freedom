#region Access
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavHelpTo.Know;
#endregion
public partial class Interactable
{
    #region Variable
    public Queue<Reaction> reactions = new Queue<Reaction>();

    [Header("_Reactions")]
    public bool canCheckAxis = true;
    public bool canMove = true;
    public bool canRotate = true;

    #endregion
    #region Method
    /// <summary>
    /// Manages the news conditions and set the first reaction
    /// based in <see cref="AssignReactions"/> and <see cref="NextReaction"/>
    /// </summary>
    partial void Interact()
    {
        isInteracting = true;
        PlayerReactionIn(false);
        AssignReactions();
        NextReaction();
    }
   
    /// <summary>
    /// Insert all the reactions in the Queue
    /// </summary>
    private void AssignReactions(){
        if (parent_reaction.IsNull()) return; //🛡
        reactions.Clear();
        foreach (Reaction r in parent_reaction.GetComponentsInChildren<Reaction>())
        {
            r.interactable = this;
            reactions.Enqueue(r);
        }
    }
    /// <summary>
    /// Starts the next interaction of the queue and dequeues it.
    /// </summary>
    [ContextMenu("SIguiente Reacción")]
    public void NextReaction(){
        if (reactions.Count == 0) EndReactions();
        else reactions.Dequeue().ExecuteReaction();
    }


    /// <summary>
    /// Ends the interactions
    /// </summary>
    private void EndReactions()
    {
        isInteracting = false;
        PlayerReactionIn(true);
    }


    /// <summary>
    /// Enables or Disables the player activity using the settings can__ or returning the control
    /// </summary>
    /// <param name="normalize"></param>
    private void PlayerReactionIn(bool normalize){
        Control.canPause = normalize; // -> el jugador no puede pausar en las interacciones
        Control.canMove = normalize || canMove;
        Control.canRotate = normalize || canRotate;
        Control.canCheckAxis = normalize || canCheckAxis;
    }
}
#endregion