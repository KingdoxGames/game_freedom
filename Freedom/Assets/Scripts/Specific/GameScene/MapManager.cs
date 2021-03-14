#region Using
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavHelpTo.Set;
using XavHelpTo.Get;
using XavHelpTo.Look;
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
    }
    private void Start()
    {
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
    /// and it try to adjust the player position based on the mapNavigator
    /// </summary>
    public static void ChangeMap(Maps to=Maps.NO_MAP){
        if (to.Equals(Maps.NO_MAP)) return;

        Maps lastMap = _.selectedMap;
        _.selectedMap = to;



        //TODO pantalla oscura

        _.ClearMaps();

        GameObject map = Instantiate(_.pref_maps[to.ToInt()], _.parent_map);
        _.actualMap = map.GetComponent<Map>();

        _.FindMapNavigator(lastMap);



    }


    /// <summary>
    /// Destroy any map who keeps in the scene( in <see cref="parent_map"/>)
    /// </summary>
    private void ClearMaps()
    {
        //elimina los hijos
        for (int x = 0; x < _.parent_map.childCount; x++)
        {
            Destroy(_.parent_map.GetChild(x).gameObject);
        }
    }

    /// <summary>
    /// Try to find the map navigator who will be redirect, wheter is not finded then will choose one randomly
    /// </summary>
    private void FindMapNavigator(Maps lastMap)
    {
        MapNavigator[] navigators = _.actualMap.GetComponentsInChildren<MapNavigator>();
        bool finded = false;
        foreach (MapNavigator n in navigators)
        {
            if (!finded && n.to.Equals(lastMap))
            {
                //Colocas al player en esta posición y le dás algo de espacion para no entrar en loop
                _.MovePlayer(n);
                finded = true;
            }
        }
        if (!finded)
        {
            int index = navigators.ZeroMax();
            _.MovePlayer(navigators[index]);
            $"NO ENCONTRÓ en {lastMap} yendo a {_.actualMap}".Print("red");
        }
    }

    /// <summary>
    /// Move the player in the position of the Map Navigator with his distance
    /// </summary>
    /// <param name="n"></param>
    private void MovePlayer(MapNavigator n){
        PlayerController.tr_player.position =
                   (n.transform.position
                   + n.transform.forward
                   * n.distance);
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