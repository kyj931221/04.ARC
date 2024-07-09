using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleManager : MonoBehaviour
{
    [SerializeField]
    private List<Toggle> toggles;

    private void Awake()
    {
        foreach (var toggle in toggles)
        {
            string toggleKey = GetToggleKey(toggle);
            bool isToggled = PlayerPrefs.GetInt(toggleKey, 0) == 1;
            toggle.isOn = isToggled;

            toggle.onValueChanged.AddListener((bool isOn) => OnToggleValueChanged(toggle, isOn));
        }
    }

    private void OnDestroy()
    {
        foreach (var toggle in toggles)
        {
            string toggleKey = GetToggleKey(toggle);
            PlayerPrefs.SetInt(toggleKey, toggle.isOn ? 1 : 0);
        }
        PlayerPrefs.Save();
    }

    private void OnToggleValueChanged(Toggle toggle, bool isOn)
    {
        string toggleKey = GetToggleKey(toggle);
        PlayerPrefs.SetInt(toggleKey, isOn ? 1 : 0);
        PlayerPrefs.Save();
        Debug.Log($"토글 {toggleKey} 상태: {isOn}");
    }

    private string GetToggleKey(Toggle toggle)
    {
        return $"ToggleState_{toggle.GetInstanceID()}";
    }
}
