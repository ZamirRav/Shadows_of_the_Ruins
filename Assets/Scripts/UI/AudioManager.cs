using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        int musicToggleValue = PlayerPrefs.GetInt("MusicToggle", 1);
        audioSource.mute = musicToggleValue == 0;
    }

    public void SetMusic(bool isOn)
    {
        audioSource.mute = !isOn;
        PlayerPrefs.SetInt("MusicToggle", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}