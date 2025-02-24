using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        // Initialize sliders with saved volume values
        if (AudioManager.Instance != null)
        {
            if (musicSlider != null)
                musicSlider.value = AudioManager.Instance.musicSource.volume;

            if (sfxSlider != null)
                sfxSlider.value = AudioManager.Instance.sfxSource.volume;
        }

        // Add listeners for slider value changes
        if (musicSlider != null)
            musicSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });

        if (sfxSlider != null)
            sfxSlider.onValueChanged.AddListener(delegate { OnSFXVolumeChange(); });
    }

    public void OnMusicVolumeChange()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetMusicVolume(musicSlider.value);
        }
    }

    public void OnSFXVolumeChange()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetSFXVolume(sfxSlider.value);
        }
    }
}
