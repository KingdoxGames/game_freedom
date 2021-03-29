#region Access
using UnityEngine;
using Environment;
using XavHelpTo.Look;

#endregion
public class ReactionTeleport : Reaction
{
    #region Variables

    public Transform teleporter;
    public Transform target;
    [Space]
    [Tooltip("Evitas que modifique la posición")]
    public bool blockPosition = false;
    [Tooltip("Evitas que modifique la rotación")]
    public bool blockRotation = false;
    [Space]
    public bool inverseRotation = false;
    #endregion
    #region Events
    public override void Awake(){
        base.Awake();

        Transform child = transform.GetChild(0);
        if (!teleporter) teleporter = child;
        if (!target) target = GameObject.FindWithTag(Data.TAG_PLAYER.ToString()).transform;

        teleporter.gameObject.SetActive(!child.Equals(teleporter));
    }
    public override void OnDrawGizmos(){

        name = $"Teleport: ({waiTime} s) ";
        name += !blockPosition ? " Position " : "";
        name += !blockRotation ? " Rotation " : "";
        name += !blockRotation && inverseRotation ? " InverseRotation ": "";
        name += !teleporter ? "(Child?)" : $"({teleporter.name})"; // by default his child;
        name += " -> ";
        name += !target ? "(Player?)" : $"({target.name})"; // by default is player;
        name += $" {debug_information}";
    }
    #endregion
    #region Methods
    protected override void React()
    {
        //GameObject obj = GameObject.FindWithTag(Data.TAG_PLAYER.ToString());

        //base.React();
        if (!blockPosition)
        {
            target.position = teleporter.position;
            if (target.CompareTag(Data.TAG_PLAYER)) target.position += Vector3.up;  
        }
        if (!blockRotation) {
            target.rotation = inverseRotation
                ? Quaternion.Inverse(teleporter.rotation)
                : teleporter.rotation;
        }


        if (blockRotation && blockPosition) $"{nameof(ReactionTeleport)} Error: -> No estás haciendo nada aquí :/".Print("red");
    }
    #endregion
}
