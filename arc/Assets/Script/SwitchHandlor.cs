using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class SwitchHandlor : MonoBehaviour
{
    private int switchState_0;
    private int switchState_1;
    private int switchState_2;
    private int switchState_3;
    private int switchState_4;

    public GameObject switchBtn_0;
    public GameObject switchBtn_1;
    public GameObject switchBtn_2;
    public GameObject switchBtn_3;
    public GameObject switchBtn_4;

    void Start()
    {
        // 이전에 저장된 상태를 불러옵니다.
        switchState_0 = PlayerPrefs.GetInt("SwitchState_0", 1);
        switchState_1 = PlayerPrefs.GetInt("SwitchState_1", 1);
        switchState_2 = PlayerPrefs.GetInt("SwitchState_2", 1);
        switchState_3 = PlayerPrefs.GetInt("SwitchState_3", 1);
        switchState_4 = PlayerPrefs.GetInt("SwitchState_4", 1);

        // 불러온 상태에 따라 초기 위치를 설정합니다.
        SetInitialPosition(switchBtn_0, switchState_0);
        SetInitialPosition(switchBtn_1, switchState_1);
        SetInitialPosition(switchBtn_2, switchState_2);
        SetInitialPosition(switchBtn_3, switchState_3);
        SetInitialPosition(switchBtn_4, switchState_4);
    }

    private void SetInitialPosition(GameObject switchBtn, int state)
    {
        if (state == -1)
        {
            switchBtn.transform.localPosition = new Vector3(-Math.Abs(switchBtn.transform.localPosition.x), switchBtn.transform.localPosition.y, switchBtn.transform.localPosition.z);
        }
        else
        {
            switchBtn.transform.localPosition = new Vector3(Math.Abs(switchBtn.transform.localPosition.x), switchBtn.transform.localPosition.y, switchBtn.transform.localPosition.z);
        }
    }

    public void OnSwitchButtonClicked()
    {
        switchBtn_0.transform.DOLocalMoveX(-switchBtn_0.transform.localPosition.x, 0.2f).OnComplete(() => SaveSwitchState(switchBtn_0, 0));
        switchBtn_1.transform.DOLocalMoveX(-switchBtn_1.transform.localPosition.x, 0.2f).OnComplete(() => SaveSwitchState(switchBtn_1, 1));
        switchBtn_2.transform.DOLocalMoveX(-switchBtn_2.transform.localPosition.x, 0.2f).OnComplete(() => SaveSwitchState(switchBtn_2, 2));
        switchBtn_3.transform.DOLocalMoveX(-switchBtn_3.transform.localPosition.x, 0.2f).OnComplete(() => SaveSwitchState(switchBtn_3, 3));
        switchBtn_4.transform.DOLocalMoveX(-switchBtn_4.transform.localPosition.x, 0.2f).OnComplete(() => SaveSwitchState(switchBtn_4, 4));
    }

    private void SaveSwitchState(GameObject switchBtn, int index)
    {
        int switchState = Math.Sign(-switchBtn.transform.localPosition.x);
        PlayerPrefs.SetInt($"SwitchState_{index}", switchState);
        PlayerPrefs.Save();
        Debug.Log($"btn {index} state : " + switchState);
    }
}
