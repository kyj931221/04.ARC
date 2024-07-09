using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Image;

    [SerializeField]
    private Toggle toggle;

    private void Awake()
    {
        // 토글의 초기 상태를 PlayerPrefs에서 불러와 설정합니다.
        bool isToggled = PlayerPrefs.GetInt("ToggleState", 0) == 1;
        toggle.isOn = isToggled;
        Image.SetActive(isToggled);

        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnDestroy()
    {
        // 토글의 상태를 저장합니다.
        PlayerPrefs.SetInt("ToggleState", toggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void OnToggleValueChanged(bool isOn)
    {
        // 이미지의 활성화 상태를 토글 상태에 따라 변경합니다.
        //Image.SetActive(isOn);
        Debug.Log($"토글 키 {isOn}");

        // 토글 상태를 PlayerPrefs에 저장합니다.
        PlayerPrefs.SetInt("ToggleState", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}
