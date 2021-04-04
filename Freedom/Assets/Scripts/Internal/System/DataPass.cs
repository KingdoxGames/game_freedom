#region ####################### IMPLEMENTATION
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Environment;
using XavHelpTo.Set;
#endregion
#region ### DataPass
/// <summary>
/// Encargado de ser la conexión de los datos guardados con las escenas
/// Este podrá cargar el ultimo archivo o guardar un archivo con sus datos
/// <para>Dependencias: <seealso cref="Data"/>, <seealso cref="SavedData"/>, <seealso cref="DataStorage"/></para>
/// </summary>
public class DataPass : MonoBehaviour
{
    #region ####### VARIABLES
    private static DataPass _;
    [Header("Saved Data")]
    [SerializeField]
    private SavedData savedData = new SavedData();
    #endregion
    #region ###### EVENTS
    private void Awake()
    {
        this.Singletone(ref _);
        _._SaveLoadFile(!File.Exists(Path));
    }
    #endregion
    #region ####### METHODS
    /// <summary>
    /// Guardamos ó cargamos el archivo que poseeremos para contener los datos
    /// que se guardan en un archivo
    /// </summary>
    /// <param name="wantSave"></param>
    public static void SaveLoadFile(in bool wantSave = false) => _._SaveLoadFile(wantSave);
    private void  _SaveLoadFile(bool wantSave = false)
    {
        BinaryFormatter _formatter = new BinaryFormatter();
        FileStream _stream = new FileStream(Path, wantSave ? FileMode.Create : FileMode.Open);
        DataStorage _dataStorage;
        
        //Dependiendo de si va a cargar o guardar hará algo o no
        if (wantSave)
        {
            savedData.debug_savedTimes++;
            _dataStorage = new DataStorage(SavedData);
            _formatter.Serialize(_stream, _dataStorage);
            _stream.Close();
        }
        else
        {
            _dataStorage = _formatter.Deserialize(_stream) as DataStorage;
            _stream.Close();
            SetData( _dataStorage.savedData);
        }
    }
    /// <summary>
    ///  Update the Data of <see cref="DataPass"/> in <seealso cref="SavedData"/> with <paramref name="newSavedData"/>
    /// </summary>
    public static void SetData( SavedData newSavedData) => _.savedData = newSavedData;
    /// <returns>The Loaded data in <see cref="DataPass"/></returns>
    public static SavedData SavedData => _.savedData;

    /// <returns>The path of the saved data</returns>
    private static string Path => Application.persistentDataPath + Data.savedPath;
    
    [ContextMenu("Guardar los datos")]
    public void _Save() => SaveLoadFile(true);
    #endregion
}
#endregion
#region DataStorage y SavedData
/// <summary>
/// Encargado de hacer que, con un constructor se agreguen los nuevos valores
/// <para>Dependencias => <seealso cref="SavedData"/></para>
/// </summary>
[System.Serializable]
public class DataStorage
{
    //aquí se vuelve a colocar los datos puestos debajo...
    public SavedData savedData = new SavedData();
    //Con esto podremos guardar los datos de datapass a DataStorage
    public DataStorage(SavedData savedData) => this.savedData = savedData;
}
/// <summary>
/// Este es el modelo de datos que vamos a guardar y manejar
/// para los archivos que se crean... Estos datos internos pueden cambiar para los proyectos...
/// <para>
///     Aquí almacenamos los datos internos del juego
/// </para>
/// </summary>
[System.Serializable]
public struct SavedData
{
    [Tooltip("El jugador nesecita que se le muestre el tutorial al iniciar?")]
    public bool tutorialDone;
    [Tooltip("decibeles guardado de musica")]
    [Range(0,1f)]
    public float musicPercent;
    [Tooltip("Porcentaje guardado de sonido")]
    [Range(0,1)]
    public float soundPercent;

    [Tooltip("En qué acto estamos actualmente?")]
    [Range(0,7)]
    public int currentAct;

    public string currentLang;

    public int currentExtra;

    public bool reachEnd;

    [Tooltip("Qué tan sensible es el agarre?")]
    public float dragSensibility; // 1-10, if 0 => 3f defualt
    //Sensibility mouse drag?


    //Extra Debug ?
    [Space(10)]
    [Header("Debug Area")]
    [Tooltip("Para debug, saber las veces que se ha guardado")]
    public int debug_savedTimes;
};
#endregion
