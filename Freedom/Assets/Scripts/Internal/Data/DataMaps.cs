#region Access
#endregion
namespace _DataMaps
{
    /// <summary>
    /// All the information refered of maps
    /// </summary>
    public class DataMaps{
        #region Variables

        private delegate Indicator IndicatorRecipe(int act, Maps from, Maps to);
        private static IndicatorRecipe Ind {get;} = (int act, Maps from, Maps to) => new Indicator(act, from, to);

        public  Indicator[] Indications { get; }


        #endregion
         public DataMaps(){
            Indications = new Indicator[] {
                //0 - Dia de la revuelta
                Ind(0, Maps.C2_TABERN, Maps.B3_CASTLE_COURTYARD),
                //1 - Exilio
                Ind(1, Maps.B3_CASTLE_COURTYARD, Maps.B4_FRONTIER),
                //2 - Encerrados
                Ind(2, Maps.NO_MAP, Maps.A1_PRISON),
                //3 - El plan
                Ind(3, Maps.A1_PRISON, Maps.A1_PRISON),
                //4 - Declaración
                Ind(4, Maps.A3_DUNGEON, Maps.A4_DUNGEON_HALL),
                //5 -  La revuelta
                Ind(5, Maps.A1_PRISON, Maps.A2_SOCIAL_ROOM),
                //6 - El exterior
                Ind(6, Maps.A2_SOCIAL_ROOM, Maps.B3_CASTLE_COURTYARD),
                //7 - El Final
                Ind(7, Maps.B3_CASTLE_COURTYARD, Maps.B2_CASTLE_HALL)
            };

            return;
        }
        #region MEthods

        #endregion
    }

    public struct Indicator
    {
        public int Act { get; }
        public Maps From { get; }
        public Maps To { get; }

        public Indicator(int act, Maps from, Maps to){
            Act = act;
            From = from;
            To = to;
        }

        /// <summary>
        /// Set the <see cref="Maps"/> with <see cref="From"/> and return the <see cref="To"/>
        /// </summary>
        public Maps SetUp(out Maps a){
            a = From;
            return To;
        }
    }
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