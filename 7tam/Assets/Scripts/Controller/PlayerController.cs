using UnityEngine;


public class PlayerController : ITurnOn, IUpdate
{
    private BaseCharacter _pig;
    private Table _table;
    private Vector2 _startPosition = Vector2.zero;

    public void TurnOn()
    {
        _pig = ObjectPool.Instance.GetObject(ObjectType.Pig).GetComponent<BaseCharacter>();
        _table = ObjectPool.Instance.GetObject(ObjectType.Table).GetComponent<Table>();

        _pig.SetPosition(_startPosition);
    }

    public void TurnOff()
    {
    }

    public void Update()
    {
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 pos = GameObject.FindObjectOfType<Camera>().ScreenToWorldPoint(Input.mousePosition);


            }

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
}
