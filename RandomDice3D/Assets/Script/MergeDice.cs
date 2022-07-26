using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeDice : MonoBehaviour
{
    private bool isClick;

    private void OnMouseDown()
    {
        isClick = false;
    }

    private void OnMouseDrag()
    {
        Vector3 vpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vpos.z = 0f;
        transform.position = vpos;
    }

    private void OnMouseUp()
    {
        isClick = true;
    }

    private void OnTriggerStay(Collider other)
    {
        string clickObject = transform.name.Substring(transform.name.LastIndexOf("_") + 1);
        string collisionObject = other.name.Substring(other.name.LastIndexOf("_") + 1);
        int codeNumber = int.Parse(clickObject) + int.Parse(collisionObject);

        if (isClick && clickObject == collisionObject)
        {
            GameObject newObject = (GameObject)Instantiate(Resources.Load("FireDice_" + codeNumber), transform.position, Quaternion.identity);
            newObject.name = "FireDice_" + codeNumber;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}