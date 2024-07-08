using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiTextManager : MonoBehaviour
{
    public InputField inputField;  // 하나의 InputField
    public Dropdown dropdown;      // Dropdown 메뉴
    public Button updateButton;    // 업데이트 버튼
    public Text[] textFields;      // 여러 개의 Text 필드

    private string[] texts;        // 텍스트를 저장할 배열
    private const string PlayerPrefsKeyPrefix = "SavedText_"; // PlayerPrefs 키 접두사

    void Start()
    {
        // 텍스트 배열 초기화 및 PlayerPrefs에서 불러오기
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
                texts[i] = "Default Text " + (i + 1); // 초기 텍스트 설정
            }
            textFields[i].text = texts[i]; // Text 필드에 설정
        }

        // Dropdown 옵션 초기화
        dropdown.ClearOptions();
        for (int i = 0; i < textFields.Length; i++)
        {
            dropdown.options.Add(new Dropdown.OptionData("Text " + (i + 1)));
        }
        dropdown.value = 0;

        // 버튼 클릭 리스너 추가
        updateButton.onClick.AddListener(UpdateSelectedText);
    }

    // 선택된 텍스트를 업데이트하고 PlayerPrefs에 저장하는 함수
    void UpdateSelectedText()
    {
        int selectedIndex = dropdown.value;
        texts[selectedIndex] = inputField.text;
        textFields[selectedIndex].text = texts[selectedIndex];

        // PlayerPrefs에 저장
        string key = PlayerPrefsKeyPrefix + selectedIndex;
        PlayerPrefs.SetString(key, texts[selectedIndex]);
        PlayerPrefs.Save();
    }

    void Update()
    {
        
    }
}
