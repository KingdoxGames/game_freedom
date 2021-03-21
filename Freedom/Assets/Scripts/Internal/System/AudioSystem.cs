#region Access
using UnityEngine;
using UnityEngine.Audio;
using XavHelpTo.Get;
using XavHelpTo;
#endregion
public class AudioSystem : MonoBehaviour
{
    #region Variable
    private const string MUSIC_KEY = "MusicVolume";
    private const string SOUND_KEY = "SoundVolume";
    private const float MAX_dB = 80f;
    private static AudioSystem _;
    private Vector2 dBValues;
    [Header("AudioSystem")]
    public AudioMixer mixer;
    #endregion
    #region Event
    private void Awake() => this.Singleton(ref _);
    private void Start()
    {
        SavedData _saved = DataPass.SavedData;
        if (!_saved.tutorialDone){
            _saved.musicPercent = 1;
            _saved.soundPercent = 1;
            DataPass.SetData(_saved);
        }

        SetMusic(_saved.musicPercent);
        SetSound(_saved.soundPercent);
    }
    #endregion
    #region Method
    /// <summary>
    /// Adjust the Music based in a 0-1 value
    /// </summary>
    public static void SetMusic(float percent) => _.SetAdjustedB(out _.dBValues.x, percent, MUSIC_KEY);
    /// <summary>
    /// Adjust the Sound based in a 0-1 value
    /// </summary>
    public static void SetSound(float percent) => _.SetAdjustedB(out _.dBValues.y, percent, SOUND_KEY);
    /// <summary>
    /// Save the latest configurations in <see cref="DataPass"/>
    /// </summary>
    public static void SavedBValues(){
        SavedData _saved = DataPass.SavedData;
        _saved.musicPercent = _.Normalize(_.dBValues.x);
        _saved.soundPercent = _.Normalize(_.dBValues.y);
        DataPass.SetData(_saved);
        DataPass.SaveLoadFile(true);
    }
    /// <returns></returns>
    private float Normalize(float value) => (value.PercentOf(MAX_dB) / 100) + 1 ;
    /// <summary>
    /// Based on the max dB adjust the Volume with the saved percentage
    /// Using <see cref="SavedData"/>
    /// </summary>
    private void SetAdjustedB(out float dB, float percent, string key)
    {
        mixer.GetFloat(key, out dB);
        dB = (-1 + percent).QtyOf(MAX_dB) * 100;
        mixer.SetFloat(key, dB);
    }
    #endregion
}