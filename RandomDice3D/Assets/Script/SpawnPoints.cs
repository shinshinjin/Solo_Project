using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnPoints : MonoBehaviour
{
    // 재화
    public float PlayerMoney = 100f;
    public float BuyMoney = 10f;

    // 주사위 생성 횟수제한(안걸면 폭발함)
    public int SpaceCount = 25;

    // 프리팹
    public GameObject[] prefabs;

    // 텍스트
    public TextMeshProUGUI restMoney_TXT;
    public TextMeshProUGUI UpgradeCost_TXT;

    // Dice 위치값 받는 곳
    public bool[,] isDice;
    public static SpawnPoints Instance;
    public Transform OriginSpawnTransform;
    private BoxCollider area;
    private List<GameObject> gameObjects = new List<GameObject>();

    //private Transform[,] spawnPositions;


    void Start()
    {
        isDice = new bool[5, 5];
        area = GetComponent<BoxCollider>();
    }

    void Update()
    {
        Texting();
    }
    void Texting()
    {
        restMoney_TXT.text = PlayerMoney.ToString();
        UpgradeCost_TXT.text = BuyMoney.ToString();
    }

    public void Dice_Generate_BTN()
    {
        if (PlayerMoney >= BuyMoney)
        {
            if (SpaceCount > 0)
            {
                Spawn();
                SpaceCount--;
                PlayerMoney -= BuyMoney;
                BuyMoney += 10f;
            }
        }
    }

    // 위치 랜덤으로 받기(중복없이)
    private Vector3 GetRandomPosition(out int col, out int row)
    {
        int randomRow = 0;
        int randomCol = 0;
        do
        {
            randomRow = Random.Range(0, 5);
            randomCol = Random.Range(0, 5);

        } while (isDice[randomRow, randomCol]);

        isDice[randomRow, randomCol] = true;
        col = randomCol;
        row = randomRow;

        Vector3 toRet = OriginSpawnTransform.position;
        toRet.x += randomCol * -2f;
        toRet.z += randomRow * -2f;

        return toRet;
    }

    // 랜덤으로 받은 위치에 랜덤으로 주사위 생성
    private void Spawn()
    {
        int selection = Random.Range(0, prefabs.Length);
        GameObject selectedPrefab = prefabs[selection];

        int col;
        int row;
        Vector3 spawnPos = GetRandomPosition(out col, out row);

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        instance.GetComponent<DiceManager>().DiceIndex = new int[2] { col, row };
        gameObjects.Add(instance);
    }
}
