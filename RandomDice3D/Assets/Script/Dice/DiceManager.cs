using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DiceType
{
    Fire,
    Yellow,
    Blue,
    Green,
    Gray
}

public class DiceManager : MonoBehaviour
{
    public int _Level;  // 주사위의 레벨
    public DiceType type; // 주사위의 타입
    public int[] DiceIndex = new int[2]; // 얘 써서 위치 저장

    Renderer diceColor; // 주사위의 색상
    SpawnPoints spawnPoints;
    Bullet bullet;

    private List<GameObject> LevelBulletList;
    void Start()
    {
        type = (DiceType)Random.Range(0, 5);
        diceColor = gameObject.GetComponent<Renderer>();

        _Level = 0;
        LevelBulletList = new List<GameObject>();

        for (int i = 0; i < 7; i++)
        {
            LevelBulletList.Add(gameObject.transform.GetChild(i).gameObject);
        }
    }

    public enum State { PICKED, RELEASED }
    public State CurrentState { get; set; } = State.RELEASED;

    void Update()
    {
        if (CurrentState == State.PICKED)
        {

        }

        switch (type)
        {
            case DiceType.Fire: diceColor.material.color = Color.red; break;
            case DiceType.Yellow: diceColor.material.color = Color.yellow; break;
            case DiceType.Blue: diceColor.material.color = Color.blue; break;
            case DiceType.Green: diceColor.material.color = Color.green; break;
            case DiceType.Gray: diceColor.material.color = Color.gray; break;
        }

        LevelBulletCheck(_Level);
    }


    public void LevelUp()
    {
        type = (DiceType)Random.Range(0, 5);
        _Level += 1;
    }

    void LevelBulletCheck(int Level)
    {
        if (Level >= 6)
        {
            Level = 6;
        }

        for (int i = 0; i < 7; i++)
        {
            if (Level == i)
            {
                LevelBulletList[i].SetActive(true);
            }
            else
            {
                LevelBulletList[i].SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        DiceManager diceManager;
        diceManager = other.gameObject.GetComponent<DiceManager>();

        if (diceManager == null)
        {
            return;
        }

        if (type != diceManager.type)
        {
            return;
        }

        if (_Level != diceManager._Level)
        {
            return;
        }

        diceManager.LevelUp();

        Destroy(gameObject);
    }
}