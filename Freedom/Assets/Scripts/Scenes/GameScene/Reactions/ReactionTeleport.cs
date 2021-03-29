#region Access
using UnityEngine;
using Environment;
#endregion
public class ReactionTeleport : Reaction
{
    #region Variables

    public Transform teleporter;
    public Transform target;

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
        name += !teleporter ? "(Child?)" : $"({teleporter.name})"; // by default his child;
        name += " -> ";
        name += !target ? "(Player?)" : $"({target.name})"; // by default is player;
    }
    #endregion
    #region Methods
    protected override void React()
    {
        //GameObject obj = GameObject.FindWithTag(Data.TAG_PLAYER.ToString());

        //base.React();
        target.position = teleporter.position;
        target.rotation = teleporter.rotation;
        if (target.CompareTag(Data.TAG_PLAYER)){
            target.position += Vector3.up;  
        }
    }
    #endregion
}
