using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnPoints : MonoBehaviour
{
    // ��ȭ
    public float PlayerMoney = 100f;
    public float BuyMoney = 10f;
    public float DiceUpgrade = 0f;
    private float UpgradePlus = 1f;
    private int UpgradeNeedToMoney = 100;
    public int hike = 1;

    // �ֻ��� ���� Ƚ������(�Ȱɸ� ������)
    public int SpaceCount = 25;

    // ������
    public GameObject[] prefabs;

    // �ؽ�Ʈ
    public TextMeshProUGUI restMoney_TXT;
    public TextMeshProUGUI UpgradeCost_TXT;
    public TextMeshProUGUI DiceUpgradeCost_TXT;
    public TextMeshProUGUI NeedCost_TXT;

    // Dice ��ġ�� �޴� ��
    public bool[,] isDice;
    public static SpawnPoints instance;
    public Transform OriginSpawnTransform;
    private BoxCollider area;
    private List<GameObject> gameObjects = new List<GameObject>();

    // �Ѿ� ������ �������� ��

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

    // ��ġ �������� �ޱ�(�ߺ�����)
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

    // �������� ���� ��ġ�� �������� �ֻ��� ����
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
        if (PlayerMoney >= UpgradeNeedToMoney && BuyMoney > 15) // �÷��̾� �Ӵϰ� ���׷��̵� ��뺸�� Ŭ ��
        {
            PlayerMoney -= UpgradeNeedToMoney; // �÷��̾�Ӵ� -= ���׷��̵� ���

            hike++;
            UpgradeNeedToMoney = hike * 100;

            DiceUpgrade++;
            UpgradePlus++;

            //Bullet.instance_B.DamageUp();
        }
    }
}
