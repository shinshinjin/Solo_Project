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
        // 1. ���콺 ��ư�� ������ �� 
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

        // TO DO : ��ġ ����

        // ���� ��, ���࿡ ����ִ°Ͱ� �������°��� ���� Ÿ���̶�� ������

        // �ƴ϶�� ���� �ڸ��� ���ư�

        _pickedDice.transform.position = _dicePrevPosition;

        _pickedDice = null;
        _dicePrevPosition = Vector3.zero;
    }
}
