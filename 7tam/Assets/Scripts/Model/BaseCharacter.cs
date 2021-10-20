using UnityEngine;


public class BaseCharacter : MonoBehaviour
{
    private CellType _cellType;
    private Direction _direction;
    private Table _table;
    private Vector2 _cellPosition;

    public CellType CellType => _cellType;
    public Direction Direction => _direction;

    private void Start()
    {
        _table = ObjectPool.Instance.GetObject(ObjectType.Table).GetComponent<Table>();
    }

    public void SetPosition(Vector2 position)
    {
        _cellPosition = position;
       _table.SetCellType(position, CellType.Pig);
        transform.position = _table.GetPosition(position);
    }

    public void MoveTo(Direction direction)
    {
        _direction = direction;

        switch (_direction)
        {
            case Direction.Down:
                if (_table.CheckCell(_cellPosition + Vector2.up))
                {
                    _cellPosition = _cellPosition + Vector2.up;
                }
                break;
            case Direction.Up:
                if (_table.CheckCell(_cellPosition + Vector2.down))
                {
                    _cellPosition = _cellPosition + Vector2.down;
                }
                break;
            case Direction.Left:
                if (_table.CheckCell(_cellPosition + Vector2.left))
                {
                    _cellPosition = _cellPosition + Vector2.left;
                }
                break;
            case Direction.Right:
                if (_table.CheckCell(_cellPosition + Vector2.right))
                {
                    _cellPosition = _cellPosition + Vector2.right;
                }
                break;
        }

        transform.position = _table.GetPosition(_cellPosition);
    }
}
