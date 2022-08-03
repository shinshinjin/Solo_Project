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
    public float DiceUpgrade = 0f;
    private float UpgradePlus = 1f;
    private int UpgradeNeedToMoney = 100;
    public int hike = 1;

    // 주사위 생성 횟수제한(안걸면 폭발함)
    public int SpaceCount = 25;

    // 프리팹
    public GameObject[] prefabs;

    // 텍스트
    public TextMeshProUGUI restMoney_TXT;
    public TextMeshProUGUI UpgradeCost_TXT;
    public TextMeshProUGUI DiceUpgradeCost_TXT;
    public TextMeshProUGUI NeedCost_TXT;

    // Dice 위치값 받는 곳
    public bool[,] isDice;
    public static SpawnPoints instance;
    public Transform OriginSpawnTransform;
    private BoxCollider area;
    private List<GameObject> gameObjects = new List<GameObject>();

    // 총알 데미지 가져오는 곳

    private void Awake()
    {
        if (SpawnPoints.instance == null)
        {
            SpawnPoints.instance = this;
        }
    }

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
        DiceUpgradeCost_TXT.text = DiceUpgrade.ToString();
        NeedCost_TXT.text = UpgradeNeedToMoney.ToString();
    }

    public void Dice_Generate_BTN()
    {
        if (PlayerMoney >= BuyMoney && SpaceCount > 0)
        {
            Spawn();
            SpaceCount--;
            PlayerMoney -= BuyMoney;
            BuyMoney += 10f;
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
        if (prefabs != null)
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

    public void Dice_Upgrade_BTN()
    {
        if (PlayerMoney >= UpgradeNeedToMoney && BuyMoney > 15) // 플레이어 머니가 업그레이드 비용보다 클 때
        {
            PlayerMoney -= UpgradeNeedToMoney; // 플레이어머니 -= 업그레이드 비용

            hike++;
            UpgradeNeedToMoney = hike * 100;

            DiceUpgrade++;
            UpgradePlus++;

            //Bullet.instance_B.DamageUp();
        }
    }
}

