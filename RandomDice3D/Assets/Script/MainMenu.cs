using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        
    }
    public void Start_BTN()
    {
        SceneManager.LoadScene("InGame");
    }
    public void Menu_BTN()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit_BTN()
    {
        Application.Quit();
        Debug.Log("게임종료");
    }
}
