using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public int Wave = 0;
    public int InGameWave = 0;
    public int RealWave = 1;
    public int savedWave = 0;

    public Text waveText;
    public Text BestWaveText;

    private string KeyString = "HighWave";

    public TextMeshProUGUI Wave_TXT;

    void Awake()
    {
        savedWave = PlayerPrefs.GetInt(KeyString, );
        BestWaveText.text = "Best Wave : " + savedWave.ToString("");
    }

    void Start()
    {
      StartCoroutine("Timer");
    }

    void Update()
    {
        waveText.text = "Wave : " + RealWave.ToString("");
        if (RealWave > savedWave)
        {
            PlayerPrefs.SetInt(KeyString, RealWave);
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        Wave += 1;
        InGameWave += 1;
        StartCoroutine("Timer");

        if (Wave == 15)
        {
            Wave -= 15;
            RealWave++;
            EnemyController.instance_EC.EnemyHpUp();
        }
    }

    void ScoreUp()
    {
        Timer();
    }
}
