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
    public DiceType type; // 주사위의 타입
    Renderer diceColor;
    public Transform shooter;

    void Start()
    {
        type = (DiceType)Random.Range(0, 5);
        diceColor = gameObject.GetComponent<Renderer>();
        shooter = GetComponent<Transform>();
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
    }
}
