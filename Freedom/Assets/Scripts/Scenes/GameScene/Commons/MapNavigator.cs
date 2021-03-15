#region Access
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Environment;
using XavHelpTo.Get;
using XavHelpTo.Change;
using XavHelpTo.Know;
#endregion
[RequireComponent(typeof(BoxCollider))]
public class MapNavigator : MonoBehaviour
{
    #region Variables
    [Header("MapNavigator")]
    public bool canNavigate = true;
    public Maps to;
    [Range(0, 4)]
    public float distance;
    [Space]
    public BoxCollider box;
    #endregion
    #region Events

    private void Awake()
    {
        this.Component(out box);
        box.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other){
        if (canNavigate && other.CompareTag(Data.TAG_PLAYER))
        {
            canNavigate = false;

            MapManager.ChangeMap(to);

        }
    }

#if DEBUG
    private void OnDrawGizmos(){
        if (Know.IsNull(box)) this.Component(out box);
        Gizmos.color = Color.yellow;
        Vector3 center = transform.position + box.center;
        Gizmos.DrawLine(center, center + transform.forward * distance);
    }
#endif

    #endregion
    #region MEthods
    #endregion
}