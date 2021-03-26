#region Using
using UnityEngine;
using Environment;
using XavHelpTo.Set;
using XavHelpTo.Get;
using XavHelpTo.Look;
using XavHelpTo.Change;
#endregion
/// <summary>
/// Manages the transition of the maps
/// </summary>
public class MapManager : MonoBehaviour
{
    #region Variables
    private static MapManager _;

    [Header("MapManager Settings")]
    public Transform parent_map;
    public Transform actualMap;
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
        //TEST
        ChangeMap(Data.DataMaps.Indications[DataPass.SavedData.currentAct].SetUp(out selectedMap));
        
        //ENDTEST
        //ya con el DataPass y el TheatreManager con los valores esperados

        // 0. tener la pantalla oscura
        // 1. Conocer cual es nuestro "selectedMap" y "actualMap" basado en el contexto de la trama

        // 2. Hacer la navegación hacia el sitio

        // 3. 

        //TODO
        //cargamos el mapa al que se supone que debemos ir
        //debe de tomarse en cuenta en qué entrada aparecer, mapa etc...
        //ChangeMap(selectedMap); TODO

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


        //TheatreManager.TriggerScreen(ScreenTrigger.HIDE);

        _.ClearMaps();

        GameObject map = Instantiate(_.pref_maps[to.ToInt()], _.parent_map);
        _.actualMap = map.GetComponent<Transform>();

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
