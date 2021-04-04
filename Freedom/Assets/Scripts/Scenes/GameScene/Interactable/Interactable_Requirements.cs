#region Access
using UnityEngine;
using XavHelpTo.Know;
using XavHelpTo.Look;
using Environment;
#endregion
public partial class Interactable
{
    #region Variables
    [Header("_Requirements")]
    [Range(0, 10f)]
    public float distanceRequired = 0f;// where 0 == does not required
    //[Space]
    public int[] itemsRequireds;

    [Range(-1, Data.EXTRA_QTY)] // where -1 == does not required
    public int extraRequired = -1;
    #endregion
    #region Methods



    /// <summary>
    /// Check the interaction between the target and the transform of this gameoobject
    /// </summary>
    partial void CheckRequirements()
    {
        //🛡
        if (PlayerController.tr_player.IsNull()) return;
        //🛡

        // if the distance is zero then its true...
        isNear = distanceRequired.Equals(0) || !PlayerController.tr_player.IsNull()
            && Vector3.Distance( transform.position, PlayerController.tr_player.position ) <= distanceRequired
        ;

        //si no hay requerimientos ó los requeridos se encuentran
        haveItems = HaveItems();




        haveExtra = HaveExtra;
    }

    /// <summary>
    /// Check if it have items
    /// </summary>
    private bool HaveItems(){
        bool result = itemsRequireds.Length.Equals(0);

        if (!result){

            if (!itemsRequireds.CountOf(0).Equals(0)){ //si existe alguno vacío
                //revisará si los slots actuales existen en los requeridos
                result = TheatreManager.CurrentItems.Contains(itemsRequireds);
            }else{
                //revisará si los requeridos existen en los slots actuales
                result = itemsRequireds.Contains(TheatreManager.CurrentItems);
            }
        }
        return result;
    }



    /// <summary>
    /// Check if exist an extra
    /// </summary>
    private bool HaveExtra => extraRequired.Equals(-1) || DataPass.SavedData.currentExtra.Equals(extraRequired);
    #endregion
}