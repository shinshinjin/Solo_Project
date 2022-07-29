using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 체력 감소 (적이 골인하면)
// 게임오브젝트 하나 받아서 충돌체에 닿으면 적 사라지고, 체력 감소

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool IsTouch;
    public Transform[] target;
    public GameObject TempGameOBJ;
    public DiceManager _pickedDice;

    private bool IsFirst;
    private Vector3 resetPosition;

    private int _layerMask;
    private Vector3 _dicePrevPosition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        LayerMask mask = LayerMask.NameToLayer("Dice");
        _layerMask = (1 << mask.value);
    }

    private void Update()
    {
        // 1. 마우스 버튼을 눌렀을 때 
        if (Input.GetMouseButtonDown(0))
        {
            pickDice();
            IsFirst = true;
            IsTouch = false;
        }

        if (Input.GetMouseButton(0))
        {
            moveDice();
        }

        if (Input.GetMouseButtonUp(0))
        {
            releaseDice();
            IsTouch = true;
        }
    }

    private void pickDice()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, _layerMask))
        {
            _pickedDice = hit.collider.GetComponent<DiceManager>();
            Debug.Assert(_pickedDice != null);

            _dicePrevPosition = _pickedDice.transform.position;

            Vector3 diceNewPosition = _dicePrevPosition;
            diceNewPosition.y += PICKED_HEIGHT;
            _pickedDice.transform.position = diceNewPosition;
        }
    }

    private static readonly float PICKED_HEIGHT = 1f;

    private void moveDice()
    {
        if (_pickedDice == null)
        {
            return;
        }

        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.y = _pickedDice.transform.position.y;
        _pickedDice.transform.position = newPosition;
    }

    private void releaseDice()
    {
        if (_pickedDice == null)
        {
            return;
        }

        // TO DO : 위치 정렬

        // 뒀을 때, 만약에 들고있는것과 내려놓는것이 같은 타입이라면 합쳐짐

        // 아니라면 원래 자리로 돌아감

        _pickedDice.transform.position = _dicePrevPosition;

        _pickedDice = null;
        _dicePrevPosition = Vector3.zero;
    }
}
