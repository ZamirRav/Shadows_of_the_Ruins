using UnityEngine;
using UnityEngine.UI;

public class DevilModToggle : MonoBehaviour
{
    public Toggle toggle;
    public AudioSource audioSource;

    private void Start()
    {
        toggle.isOn = GameSettings.IsDevilModOn;
        toggle.onValueChanged.AddListener(OnToggleChanged);
    }

    private void OnToggleChanged(bool isOn)
    {
        if (isOn) audioSource.Play();
        GameSettings.IsDevilModOn = isOn;
    }
}
