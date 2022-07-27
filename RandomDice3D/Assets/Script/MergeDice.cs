using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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

        //vpos.y = 0;
        transform.position = new Vector3(vpos.x,10f , vpos.z) ;
        Debug.Log(vpos);
        //Debug.Log(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        isClick = true;
    }

    private void OnTriggerStay(Collider other)
    {
        
    }
}