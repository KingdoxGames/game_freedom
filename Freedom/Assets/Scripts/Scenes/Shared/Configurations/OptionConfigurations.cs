#region Access
using UnityEngine;
using UnityEngine.UI;
using Environment;
using XavHelpTo.Look;
using XavHelpTo.Get;
#endregion
public class OptionConfigurations : MonoBehaviour
{
    #region Variables
    public const float DEFAULT_SENSIBILITY = 3f;
    [Header("OptionsConfig")]
    public Slider slid_Music;
    public Slider slid_Sound;
    public Slider slid_Sensibility;
    #endregion
    #region Events
    private void Start(){
        SavedData _saved = DataPass.SavedData;
        slid_Music.value = _saved.musicPercent;
        slid_Sound.value = _saved.soundPercent;

        if (_saved.dragSensibility.Equals(0)){
            _saved.dragSensibility = DEFAULT_SENSIBILITY;
            DataPass.SetData(_saved);
        }

        slid_Sensibility.value = _saved.dragSensibility.PercentOf(Data.DRAG_SENSIBILITY_MAX);

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

    /// <summary>
    /// refresh the sensibility of the mouse
    /// check if exist the <seealso cref="DragRotation"/> to set ingame
    /// </summary>
    public void SetDragSensibility(float dragPercent){
        //la cantidad que se debe asignar basada en el procentaje otorgado
        SavedData _saved = DataPass.SavedData;
        _saved.dragSensibility = dragPercent.QtyOf(Data.DRAG_SENSIBILITY_MAX);
        DataPass.SetData(_saved);
        
    }

    #endregion
}
