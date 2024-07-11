using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject Modify_screen;

    private void Start()
    {
        
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("App Exit!!");
    }

    public void active_object()
    {
        
        Modify_screen.SetActive(true);
    }

    public void active_false_object()
    {
        
        Modify_screen.SetActive(false);
    }

}
