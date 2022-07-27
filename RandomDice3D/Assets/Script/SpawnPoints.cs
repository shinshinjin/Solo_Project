using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnPoints : MonoBehaviour
{
    public GameObject[] prefabs;
    public static SpawnPoints Instance;
    public bool[,] isDice;
    public float PlayerMoney = 100f;
    public float BuyMoney = 10f;
    public Transform OriginSpawnTransform;

    private float SpaceCount = 25;
    private BoxCollider area;
    private List<GameObject> gameObjects = new List<GameObject>();
    private Transform[,] spawnPositions;

    public TextMeshProUGUI restMoney_TXT;

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
    }

    public void Dice_Generate_BTN()
    {
        if (PlayerMoney >= BuyMoney)
        {
            if ( SpaceCount > 0)
            {
                Spawn();
                SpaceCount--;
                PlayerMoney -= BuyMoney;
                BuyMoney += 10f;

                
            }
        }
    }

    // ��ġ �������� �ޱ�(�ߺ�����)
    private Vector3 GetRandomPosition()
    {
        int randomRow = 0;
        int randomCol = 0;
        do
        {
            randomRow = Random.Range(0, 5);
            randomCol = Random.Range(0, 5);

        } while (isDice[randomRow, randomCol]);

        isDice[randomRow, randomCol] = true;

        Vector3 toRet = OriginSpawnTransform.position;
        toRet.x += randomCol * -2f;
        toRet.z += randomRow * -2f;

        return toRet;
    }

    // �������� ���� ��ġ�� �������� �ֻ��� ����
    private void Spawn()
    {
        int selection = Random.Range(0, prefabs.Length);
        GameObject selectedPrefab = prefabs[selection];

        Vector3 spawnPos = GetRandomPosition();

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        gameObjects.Add(instance);   
    }
}
