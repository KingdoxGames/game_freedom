#region Access
using UnityEngine;
using Environment;
using XavHelpTo;
#endregion

public class Guard : MonoBehaviour
{
    #region Variables
    private Vector3 initPosition; // where he will return in case that he has changed their own position
    private Transform target;
    private const float RANGE_SCALE_Y = 0.001f;
    private const float ALPHA_RANGE_COLOR = 0.6f;
    private MeshRenderer mesh_range;
    [Header("Guard Settigns")]
    public Transform tr_range; // by default his 2nd child
    public string targetTag;// where we will look at to get the target
    [Space]
    public bool enableRange = true;
    [Range(1, 20)]
    public float range = 5;
    [Space]
    [Range(1, 50)]
    public float speed = 1;

    #endregion
    #region Events
    private void Awake(){

        initPosition = transform.position; // set their default initial position

        if (targetTag.Length.Equals(0)) targetTag = Data.TAG_PLAYER; // by default select the player Tag
        target = GameObject.FindWithTag(targetTag).transform;
        if (!tr_range) tr_range = transform.GetChild(1);
        RefreshRange();

        tr_range.Component(out mesh_range, false);
        


    }
    private void Update()
    {
        tr_range.gameObject.SetActive(enableRange);
    }
    private void FixedUpdate()
    {
        if (enableRange)
        {
            CheckMovements();
        }
    }
    private void OnDrawGizmos(){
#if UNITY_EDITOR
        if (initPosition.Equals(Vector3.zero)) initPosition = transform.position;
        if (!tr_range) tr_range = transform.GetChild(1);
        if (targetTag.Length.Equals(0)) targetTag = Data.TAG_PLAYER;
        tr_range.position = transform.position;
        RefreshRange();
#endif
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(initPosition, range);

        Gizmos.color = IsGuardOutArea ? Color.white :  Color.yellow;
        Gizmos.DrawLine(initPosition, transform.position);

    }
    #endregion
    #region Methods
    private void RangeColor(Color c){
        c.a = ALPHA_RANGE_COLOR;
        if (c.Equals(mesh_range.material.color)) return; // 🛡
        mesh_range.material.color = c;
    }
    /// <summary>
    /// Based on the parammeters of nearest, guard can decide what will gonna do
    /// </summary>
    private void CheckMovements()
    {
        if (IsTargetNear){

            LookTo(target.position);
            if (!IsGuardOutArea || IsTargetInArea){
                RangeColor(Color.red);
                MoveTo(target.position);
            }else{
                RangeColor(Color.yellow);
            }
        }
        else
        {
            RangeColor(Color.gray);

            LookTo(initPosition);
            MoveTo(initPosition);
        }
    }

    /// <summary>
    /// Rotates to the direction of the position
    /// </summary>
    /// <param name="pos"></param>
    private void LookTo(Vector3 pos){
        if (pos.Equals(transform.position) ) return; // 🛡    
        Quaternion q = Quaternion.LookRotation(pos - transform.position);
        q.x = 0;
        q.z = 0;
        transform.rotation = q;
    }
    /// <summary>
    /// Refreshes the visual range 
    /// </summary>
    private void RefreshRange() => tr_range.localScale = ((Vector3.one - Vector3.up) * range * 2) + Vector3.up * RANGE_SCALE_Y;

    /// <summary>
    /// Check whether is the range between the target and the center of the position is less than...
    /// </summary>
    private bool IsTargetNear => Vector3.Distance(target.position, transform.position) < range;

    /// <summary>
    /// Check if is target still in area
    /// </summary>
    private bool IsTargetInArea => Vector3.Distance(initPosition, target.position) < range;

    /// <summary>
    /// Check whether is the range between the guard and the center exceed the range assigned
    /// </summary>
    private bool IsGuardOutArea => Vector3.Distance(transform.position, initPosition) > range;


    /// <summary>
    /// Move the Guard to the position specified
    /// </summary>
    private void MoveTo(Vector3 to){
        //if (Vector3.Distance(initPosition, transform.position) > range) return; // 🛡
        to.y = initPosition.y;
        transform.position = Vector3.Lerp(transform.position, to, Time.deltaTime * speed);

       
    }
    #endregion
}