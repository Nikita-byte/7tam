using UnityEngine;
using System.Collections.Generic;


public class PlayerController : ITurnOn, IUpdate
{
    private BaseCharacter _pig;
    private Table _table;
    private Vector2 _startPosition = Vector2.zero;
    private float width;
    private float height;
    private Touch _touch;

    public void TurnOn()
    {
        _pig = ObjectPool.Instance.GetObject(ObjectType.Pig).GetComponent<BaseCharacter>();
        _table = ObjectPool.Instance.GetObject(ObjectType.Table).GetComponent<Table>();

        _pig.SetPosition(_startPosition); 
        _pig.gameObject.SetActive(true);

        EventManager.Instance.AddListener(EventType.PlantBomb, PlantBomb);
        EventManager.Instance.AddListener(EventType.Up, Up);
        EventManager.Instance.AddListener(EventType.Down, Down);
        EventManager.Instance.AddListener(EventType.Left, Left);
        EventManager.Instance.AddListener(EventType.Right, Right);
    }

    public void TurnOff()
    {
        EventManager.Instance.RemoveListener(EventType.PlantBomb, PlantBomb);

        EventManager.Instance.RemoveListener(EventType.Up, Up);
        EventManager.Instance.RemoveListener(EventType.Down, Down);
        EventManager.Instance.RemoveListener(EventType.Left, Left);
        EventManager.Instance.RemoveListener(EventType.Right, Right);
    }

    public void Update()
    {
        if (Application.isEditor)
        {

            if (Input.GetKeyDown(KeyCode.W))
            {
                _pig.MoveTo(Direction.Up);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                _pig.MoveTo(Direction.Down);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                _pig.MoveTo(Direction.Left);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                _pig.MoveTo(Direction.Right);
            }
        }
    }

    public void FixedUpdate()
    {
    }

    public void LateUpdate()
    {
    }

    private void PlantBomb()
    {
        Debug.Log("Bomb");

        if (!_pig.IsMoving)
        {
            Vector2 plantPosition = _pig.CellPosition;

            _table.SetCellType(plantPosition, CellType.Bomb);
        }
    }

    private void Up()
    {
        _pig.MoveTo(Direction.Up);
    }

    private void Down()
    {
        _pig.MoveTo(Direction.Down);
    }

    private void Left()
    {
        _pig.MoveTo(Direction.Left);
    }

    private void Right()
    {
        _pig.MoveTo(Direction.Right);
    }
}
