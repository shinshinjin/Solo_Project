using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeDice : MonoBehaviour
{
    private bool isClick;
    public DiceManager diceManager;

    private void OnMouseDown()
    {
        isClick = false;
        diceManager = GetComponent<DiceManager>();
    }

    private void OnMouseDrag()
    {
        Vector3 vpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(vpos);
        vpos.y = 0;
        transform.position = vpos;
    }

    private void OnMouseUp()
    {
        isClick = true;
    }

    private void OnTriggerStay(Collider other)
    {
        
    }
}