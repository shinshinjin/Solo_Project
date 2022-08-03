using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StageUI : MonoBehaviour
{
    public static float PlayerHP = 3;

    public TextMeshProUGUI PlayerHP_TXT;

    // 게임오버 만들곳
    void Start()
    {

    }

    void Update()
    {
        PlayerHP_TXT.text = PlayerHP.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            PlayerHP--;
            if(PlayerHP <= 0)
            {
                GameManager.instance.GameOver();
            }
        }
    }
}
