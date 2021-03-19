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
    /// Gestionara las condiciones y reacciones
    /// </summary>
    partial void Interact()
    {

        // ponemos en cola todas las reacciones
        //lo estamos haciendo en el start
        AssignReactions();

        // iniciamos la secuencia de reacciones
        NextReaction();

    }
   
    /// <summary>
    /// Insert all the reactions in the Queue
    /// </summary>
    private void AssignReactions()
    {
        //🛡
        if (parent_reaction.IsNull()) return;
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
    public void NextReaction()
    {
        //🛡
        if (reactions.Count == 0) return;

        reactions.Dequeue().ExecuteReaction();
    }

}
#endregion