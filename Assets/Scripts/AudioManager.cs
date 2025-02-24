using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Singleton instance for easy access
    public static AudioManager Instance { get; private set; }

    [Header("Audio Sources")]
    public AudioSource musicSource;  // Source for background music
    public AudioSource sfxSource;    // Source for sound effects (SFX)

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;  // Default background music clip

    // PlayerPrefs keys for saving volume settings
    private const string MusicVolumeKey = "MusicVolume";
    private const string SFXVolumeKey = "SFXVolume";

    void Awake()
    {
        // Singleton pattern to persist AudioManager across scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);  // Ensure only one AudioManager exists
        }
    }

    void Start()
    {
        PlayMusic(backgroundMusic);  // Start playing background music
        LoadVolumeSettings();        // Load saved volume settings
    }

    // Play background music with looping
    public void PlayMusic(AudioClip clip)
    {
        if (clip != null)
        {
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    // Play a one-shot sound effect
    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    // Set and save the music volume (0.0 to 1.0)
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = Mathf.Clamp01(volume);
        PlayerPrefs.SetFloat(MusicVolumeKey, musicSource.volume);  // Save music volume
    }

    // Set and save the SFX volume (0.0 to 1.0)
    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = Mathf.Clamp01(volume);
        PlayerPrefs.SetFloat(SFXVolumeKey, sfxSource.volume);  // Save SFX volume
    }

    // Load saved volume settings from PlayerPrefs
    private void LoadVolumeSettings()
    {
        // Load saved volumes, defaulting to 0.5 if no saved values exist
        float savedMusicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 0.5f);
        float savedSFXVolume = PlayerPrefs.GetFloat(SFXVolumeKey, 0.5f);

        musicSource.volume = savedMusicVolume;
        sfxSource.volume = savedSFXVolume;
    }
}
