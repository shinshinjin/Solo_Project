using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾� ü�� ���� (���� �����ϸ�)
// ���ӿ�����Ʈ �ϳ� �޾Ƽ� �浹ü�� ������ �� �������, ü�� ����

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    public bool IsTouch;
    public Transform[] target;

    private Ray ray;
    private RaycastHit hit;

    DiceManager DM;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsFirst = true;
            IsTouch = false;
        }
        if (Input.GetMouseButton(0))
        {
            raycast_Check();
        }
        if (Input.GetMouseButtonUp(0))
        {
            IsTouch = true;

            StartCoroutine(DelayReset());
        }
    }

    IEnumerator DelayReset()
    {
        yield return new WaitForSeconds(0.1f);
        //���� ��ġ�� ����
        if (TempGameOBJ != null)
        {
            TempGameOBJ.transform.position = resetPosition;
        }
    }

    private bool IsFirst;
    private Vector3 resetPosition;

    public GameObject TempGameOBJ;

    void raycast_Check()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);

            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
            Vector3 vec3 = Camera.main.ScreenToWorldPoint(mousePos);

            if (hit.collider.gameObject.name == "dicePrefab2 1(Clone)")
            {
                if (IsFirst == true)
                {
                    TempGameOBJ = hit.collider.gameObject;
                    resetPosition = hit.collider.transform.position;
                    IsFirst = false;
                }

                TempGameOBJ.transform.position = new Vector3(vec3.x, 0.05f, vec3.z);
            }
        }
    }
}
