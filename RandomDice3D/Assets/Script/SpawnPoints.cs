using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public GameObject[] prefabs;
    public static SpawnPoints Instance;
    public bool[,] isDice;
    public float PlayerMoney = 10000f;
    public float BuyMoney = 10f;
    public Transform OriginSpawnTransform;

    private float SpaceCount = 25;
    private BoxCollider area;
    private List<GameObject> gameObjects = new List<GameObject>();
    private Transform[,] spawnPositions;


    void Start()
    {
        isDice = new bool[5, 5];
        area = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (PlayerMoney >= BuyMoney)
        {
            if (Input.GetKeyDown(KeyCode.Space) && SpaceCount > 0)
            {
                Spawn();
                SpaceCount--;
            }
        }
    }

    // 위치 랜덤으로 받기(중복없이)
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

    // 랜덤으로 받은 위치에 랜덤으로 주사위 생성
    private void Spawn()
    {
        int selection = Random.Range(0, prefabs.Length);
        GameObject selectedPrefab = prefabs[selection];

        Vector3 spawnPos = GetRandomPosition();

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        gameObjects.Add(instance);   
    }
}
