#region Using
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavHelpTo.Set;
using XavHelpTo.Get;
using XavHelpTo.Change;
#endregion
public class MapManager : MonoBehaviour
{
    #region Variables
    private static MapManager _;

    [Header("MapManager Settings")]
    public Transform parent_map;
    public Map actualMap;
    [Space]
    public GameObject[] pref_maps;
    [Space]
    public Maps selectedMap;
    //public acta
    [Header("Debug")]
    public bool _debug_change=false;
    #endregion
    #region Events
    private void Awake()
    {
        this.Singletone(ref _,false);


        //TODO DEBUGEO
        ChangeMap(selectedMap);
    }
    private void Update()
    {
        if (_debug_change)
        {
            ChangeMap(selectedMap);
            _debug_change = false;
        }
    }
    #endregion
    #region Method
    /// <summary>
    /// Destroy the actual map and then creates another based on the prefabs
    /// </summary>
    private void ChangeMap(Maps newMap=Maps.NO_MAP){
        if (newMap.Equals(Maps.NO_MAP)) return;




        //TODO pantalla oscura


        //elimina los hijos
        for (int x = 0; x < parent_map.childCount; x++){
            Destroy(parent_map.GetChild(x).gameObject);
        }


        GameObject map = Instantiate(pref_maps[newMap.ToInt()], parent_map);

        actualMap = map.GetComponent<Map>();




    }
    #endregion
}
/// <summary>
/// All the maps in game
/// </summary>
public enum Maps
{
    NO_MAP = -1,
    //Prison Areas
    A1_PRISON,
    A2_SOCIAL_ROOM,
    A3_DUNGEON,
    A4_DUNGEON_HALL,

    //Castle Areas
    B1_THRONE,
    B2_CASTLE_HALL,
    B3_CASTLE_COURTYARD,
    B4_FRONTIER,

    //Home Areas
    C1_BED_ROOM,
    C2_TABERN,

}