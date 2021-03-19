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


    #endregion
    #region Method
    /// <summary>
    /// Manages the news conditions and set the first reaction
    /// based in <see cref="AssignReactions"/> and <see cref="NextReaction"/>
    /// </summary>
    partial void Interact()
    {
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
        if (reactions.Count == 0) return; //🛡
        reactions.Dequeue().ExecuteReaction();
    }
}
#endregion