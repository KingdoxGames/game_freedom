#region Imports
using UnityEngine;
using _DataMaps;
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
        public static DataMaps DataMaps { get; } = new DataMaps();

        public const string savedPath = "saved4.txt";
        public const string version = "v0.6.0";
        public const string TAG_PLAYER = "Player";
        public const string PATH_LANG = "Lang/";
        public const string PATH_SPRITES = "Sprites/";

        public const string DEFAULT_LANG = "Spanish";
        public const int EQUIP_QTY = 2; // capacity ingame
        public const int ACT_QTY = 7;
        public const int PARTS_QTY = 4;//does not apply for every act
        public const int EXTRA_QTY = 3;//does not apply for every part
        public const int ITEM_QTY = 6; // not used frequently

        public const int OPTIONS_MAX_QTY = 3; // based in modal options

        //Screen Trigger Keys
        public static readonly string[] SCREEN_TRIGGERS = { "Show", "Hide" };


        public const string END_TITLE_KEY = "menu_end_title"; // key to end sideModal
        public const string NAMECHAT_KEY = "namechat_"; // Key to namechat names

    }
    /// <summary>
    /// Las escenas del juego, ordenadas como en "Build Settings"
    /// </summary>
    public enum Scenes
    {
        SplashScene=0,
        MenuScene=1,
        GameScene=2
    }

    /// <summary>
    /// linked with <seealso cref="Data.SCREEN_TRIGGERS"/>
    /// </summary>
    public enum ScreenTrigger { SHOW, HIDE };

    #endregion
}

