using UnityEngine;
using UnityEngine.UI;

public class InfintyMoneyToggle : MonoBehaviour
{
    public Toggle toggle;

    private void Start()
    {
        toggle.isOn = GameSettings.IsToggleOn;
        toggle.onValueChanged.AddListener(OnToggleChanged);
    }

    private void OnToggleChanged(bool isOn)
    {
        GameSettings.IsToggleOn = isOn;
    }
}
