using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageUI : MonoBehaviour
{
    public float PlayerHP = 3;

    // ���ӿ��� �����
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            PlayerHP--;
            if(PlayerHP < 0)
            {
                GameOver();
            }
        }
    }
    void GameOver()
    {
        Debug.Log("���ӿ���");
    }
}
