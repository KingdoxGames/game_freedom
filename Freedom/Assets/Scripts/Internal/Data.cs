#region Imports
using UnityEngine;
#endregion

namespace Environment
{
    #region Environment
    /// <summary>
    /// Representa los datos basicos del enviroment
    /// </summary>
    public class Data 
    {
        [HideInInspector]
        public static Data data = new Data();

        public const string savedPath = "saved.txt";
        public const string version = "v0.1.1";
        public const string TAG_PLAYER = "Player";
       
    }
    #endregion
    #region Enums
    /// <summary>
    /// Enumerador de los nombres de las escenas de este proyecto
    /// Estos se colocan manualmente....
    /// </summary>
    public enum Scenes
    {
        MenuScene, //el menu principal apra acceder a los demás sitios
        GameScene, //Pantalla de juego
    }
    /// <summary>
    /// Son las llaves que posee el jugador en este proyecto
    /// </summary>
    public enum KeyPlayer
    {
      //Deas='¢'
    }
    #endregion
}