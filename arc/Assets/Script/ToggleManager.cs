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
        // ����� �ʱ� ���¸� PlayerPrefs���� �ҷ��� �����մϴ�.
        bool isToggled = PlayerPrefs.GetInt("ToggleState", 0) == 1;
        toggle.isOn = isToggled;
        Image.SetActive(isToggled);

        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnDestroy()
    {
        // ����� ���¸� �����մϴ�.
        PlayerPrefs.SetInt("ToggleState", toggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void OnToggleValueChanged(bool isOn)
    {
        // �̹����� Ȱ��ȭ ���¸� ��� ���¿� ���� �����մϴ�.
        //Image.SetActive(isOn);
        Debug.Log($"��� Ű {isOn}");

        // ��� ���¸� PlayerPrefs�� �����մϴ�.
        PlayerPrefs.SetInt("ToggleState", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}
