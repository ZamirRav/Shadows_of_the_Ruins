using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public Toggle musicToggle;

    void Start()
    {
        musicToggle.isOn = PlayerPrefs.GetInt("MusicToggle", 1) == 1;
        musicToggle.onValueChanged.AddListener(OnToggleChanged);
        AudioManager.Instance.SetMusic(musicToggle.isOn);
    }

    void OnToggleChanged(bool isOn)
    {
        AudioManager.Instance.SetMusic(isOn);
    }

    void OnDestroy()
    {
        musicToggle.onValueChanged.RemoveListener(OnToggleChanged);
    }
}