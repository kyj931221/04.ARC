using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiTextManager : MonoBehaviour
{
    public InputField inputField;  // �ϳ��� InputField
    public Dropdown dropdown;      // Dropdown �޴�
    public Button updateButton;    // ������Ʈ ��ư
    public Text[] textFields;      // ���� ���� Text �ʵ�

    private string[] texts;        // �ؽ�Ʈ�� ������ �迭
    private const string PlayerPrefsKeyPrefix = "SavedText_"; // PlayerPrefs Ű ���λ�

    void Start()
    {
        // �ؽ�Ʈ �迭 �ʱ�ȭ �� PlayerPrefs���� �ҷ�����
        texts = new string[textFields.Length];
        for (int i = 0; i < textFields.Length; i++)
        {
            string key = PlayerPrefsKeyPrefix + i;
            if (PlayerPrefs.HasKey(key))
            {
                texts[i] = PlayerPrefs.GetString(key);
            }
            else
            {
                texts[i] = "Default Text " + (i + 1); // �ʱ� �ؽ�Ʈ ����
            }
            textFields[i].text = texts[i]; // Text �ʵ忡 ����
        }

        // Dropdown �ɼ� �ʱ�ȭ
        dropdown.ClearOptions();
        for (int i = 0; i < textFields.Length; i++)
        {
            dropdown.options.Add(new Dropdown.OptionData("Text " + (i + 1)));
        }
        dropdown.value = 0;

        // ��ư Ŭ�� ������ �߰�
        updateButton.onClick.AddListener(UpdateSelectedText);
    }

    // ���õ� �ؽ�Ʈ�� ������Ʈ�ϰ� PlayerPrefs�� �����ϴ� �Լ�
    void UpdateSelectedText()
    {
        int selectedIndex = dropdown.value;
        texts[selectedIndex] = inputField.text;
        textFields[selectedIndex].text = texts[selectedIndex];

        // PlayerPrefs�� ����
        string key = PlayerPrefsKeyPrefix + selectedIndex;
        PlayerPrefs.SetString(key, texts[selectedIndex]);
        PlayerPrefs.Save();
    }

    void Update()
    {
        
    }
}
