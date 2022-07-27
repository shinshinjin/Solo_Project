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
    public DiceType type; // �ֻ����� Ÿ��
    Renderer diceColor;
    public Transform shooter;

    private List<GameObject> LevelBulletList;

    void Start()
    {
        type = (DiceType)Random.Range(0, 5);
        diceColor = gameObject.GetComponent<Renderer>();
        shooter = GetComponent<Transform>();

        _Level = 0;
        LevelBulletList = new List<GameObject>();

        for (int i = 0; i < 7; i++)
        {
            LevelBulletList.Add(gameObject.transform.GetChild(i).gameObject);
        }
    }

    void Update()
    {
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

    public int _Level;

    public void LevelUp()
    {
        _Level += 1;
    }

    void LevelBulletCheck(int Level)
    {
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

    private void OnTriggerExit(Collider other)
    {
        DiceManager DM;
        DM = other.gameObject.GetComponent<DiceManager>();

        GameManager GM;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (GM.TempGameOBJ == this.gameObject)
        {
            if (other.gameObject.tag == "Dice")
            {
                //Debug.Log(other.gameObject.name + "�� Ʈ���� ��");
                //Debug.LogError("��ġ��");
                if (GM.IsTouch == true)
                {
                    if (DM._Level == _Level && DM.type == type)
                    {
                        Destroy(GM.TempGameOBJ);
                        DM.LevelUp();
                    }
                }
            }
        }
    }
}
// 1. ���� ������ �������� �� : �� �������, �÷��̾� ü�� ����
// 2. �÷��̾� ü�� 0�� �Ǹ� ���� OVER.
// 3. 