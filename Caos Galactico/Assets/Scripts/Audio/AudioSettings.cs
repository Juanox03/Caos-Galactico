using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] AudioMixer _audioMixer;
    [SerializeField] Slider _sliderMaster;
    [SerializeField] Slider _sliderMusic;
    [SerializeField] Slider _sliderSFX;

    public void SetMasterVolume()
    {
        float volume = _sliderMaster.value;
        _audioMixer.SetFloat("Volume Master", volume);
    }

    public void SetMusicVolume()
    {
        float volume = _sliderMusic.value;
        _audioMixer.SetFloat("Volume Music", volume);
    }

    public void SetSFXVolume()
    {
        float volume = _sliderSFX.value;
        _audioMixer.SetFloat("Volume SFX", volume);
    }
}