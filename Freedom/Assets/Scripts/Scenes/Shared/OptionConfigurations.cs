#region Access
using UnityEngine;
using UnityEngine.UI;
#endregion
public class OptionConfigurations : MonoBehaviour
{
    #region Variables
    [Header("OptionsConfig")]
    public Slider slid_Music;
    public Slider slid_Sound;
    #endregion
    #region Events
    private void Start(){
        SavedData _saved = DataPass.SavedData;
        slid_Music.value = _saved.musicPercent;
        slid_Sound.value = _saved.soundPercent;
    }
    #endregion
    #region Methods
    /// <summary>
    /// Refresh the music audio
    /// </summary>
    public void SetMusic(float musicPercent) => AudioSystem.SetMusic(musicPercent);
    /// <summary>
    /// Refresh the sound audio
    /// </summary>
    public void SetSound(float soundPercent) => AudioSystem.SetSound(soundPercent);

    #endregion
}
