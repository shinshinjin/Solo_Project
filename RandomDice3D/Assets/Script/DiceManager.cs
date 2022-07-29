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
    public int _Level;  // �ֻ����� ����
    public DiceType type; // �ֻ����� Ÿ��
    public int[] DiceIndex = new int[2]; // �� �Ἥ ��ġ ����

    Renderer diceColor; // �ֻ����� ����
    SpawnPoints spawnPoints;
    Bullet bullet;

    private List<GameObject> LevelBulletList;
    private bool isPicked = false;

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

        Debug.Log("���� ���̽���!");

        diceManager.LevelUp();
        Destroy(gameObject);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    DiceManager DM;
    //    DM = other.gameObject.GetComponent<DiceManager>();

    //    GameManager GM;
    //    GM = GameObject.Find("GameManager").GetComponent<GameManager>();

    //    SpawnPoints SP;
    //    SP = GameObject.Find("SpawnPoints").GetComponent<SpawnPoints>();

    //    if (GM.TempGameOBJ == this.gameObject)
    //    {
    //        if (other.gameObject.tag == "Dice")
    //        {
    //            //Debug.Log(other.gameObject.name + "�� Ʈ���� ��");
    //            //Debug.LogError("��ġ��");
    //            if (GM.IsTouch == true)
    //            {
    //                if (DM._Level == _Level && DM.type == type)
    //                {
    //                    //SP.isDice[,] = false;

    //                    Destroy(GM.TempGameOBJ);
    //                    DM.type = (DiceType)Random.Range(0, 5);
    //                    DM.LevelUp();

    //                    // SP.isDice[GM.index_X, GM.index_Z] = false;
    //                    //spawnPoints.SpaceCount++;
    //                }
    //            }
    //        }
    //    }
    //}
}