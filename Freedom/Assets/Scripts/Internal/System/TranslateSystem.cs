#region Access
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using XavHelpTo;
using Environment;
using UnityEngine.Events;
#endregion
/// <summary>
/// Manages all the information who exist in xml files and retireves his keys
/// </summary>
public class TranslateSystem : MonoBehaviour
{
    #region Variables
    private const string KEYNAME = "key";
    private string systemLanguage;
    private static TranslateSystem _;
    public Dictionary<string, string> dic_Lang;

    private bool inited;
    public static UnityAction LangSubscribe;

    #region Debug Variables
        [HideInInspector] public bool debug_mode = false;
        [HideInInspector] public string debug_folder = "Spanish";
        [HideInInspector] public string debug_key = "lang";
    #endregion
    #endregion
    #region Events
    private void Awake() {
        inited = false;
        debug_mode = false;

        this.Singleton(ref _);
    }
    private void Start(){
        InitLang();
        //Traduce los que se suscribieron
        RefreshTexts();
        inited = true;
    }
    #endregion
    #region Methods
    /// <summary>
    /// Initializes the Language Dictionary
    /// </summary>
    public void InitLang(string folder= default, string defFolder = default)
    {
        systemLanguage = Application.systemLanguage.ToString();
        TextAsset txt = LoadTextAsset(Data.PATH_LANG, folder ?? systemLanguage, defFolder ?? Data.DEFAULT_LANG);
        dic_Lang = LoadDictionary(txt);
    }
    /// <summary>
    /// Carga el archivo a buscar y lo inserta en un <see cref="TextAsset"/>
    /// </summary>
    public TextAsset LoadTextAsset(string folder, string fileName, string defaultName = default){
        TextAsset txt = Resources.Load(folder+fileName, typeof(TextAsset)) as TextAsset;
        if (!txt && (fileName == defaultName || defaultName == default)) return null;
        else return txt ?? LoadTextAsset(folder,defaultName);
    } 
    /// <summary>
    /// Carga el diccionario basado en el texto otorgado
    /// </summary>
    private Dictionary<string,string> LoadDictionary(TextAsset txt){
        if (txt is null) return null; //🛡
        Dictionary<string,string> dic = new Dictionary<string, string>();
        //Enumeramos los elementos
        IEnumerator elemEnum = LoadXml(txt).DocumentElement.GetEnumerator();
        while (elemEnum.MoveNext()){
            //linea actual de la fila
            XmlElement xmlItem = (XmlElement)elemEnum.Current;
            //Añadimos el key y su valor
            dic.Add(xmlItem.GetAttribute(KEYNAME), xmlItem.InnerText);
        }
        return dic;
    }
    /// <summary>
    /// Carga los <see cref="TextAsset"/> en un nuevo <seealso cref="XmlDocument"/>
    /// </summary>
    public XmlDocument LoadXml(TextAsset txt) {
        if (txt is null) return null; //🛡
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(txt.text);
        return xml;
    }
    /// <summary>
    /// Recupera el valor dentro de el archivo indicado usando un key
    /// </summary>
    public string GetValueIn(in Dictionary<string,string> dic, in string key) => !(dic is null) && dic.ContainsKey(key) ? dic[key] : $"Err: {key}";
    /// <summary>
    /// Makes a translation of the dictionary of language
    /// </summary>
    public static string TranslationOf(in string key){
        string result = "";
        if (_ is null || _.dic_Lang is null) return result; // 🛡
        return _.GetValueIn(_.dic_Lang, key);
    }

    /// <summary>
    /// Invoca el refrescamiento para los suscritos
    /// </summary>
    [ContextMenu("Refrescar textos")]
    public void RefreshTexts() => LangSubscribe?.Invoke();

    /// <summary>
    /// Show if is Inited
    /// </summary>
    public static bool Inited => !(_ is null) && _.inited;
    #endregion
}