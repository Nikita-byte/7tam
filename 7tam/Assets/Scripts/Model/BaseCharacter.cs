using UnityEngine;
using DG.Tweening;


public class BaseCharacter : MonoBehaviour
{
    [SerializeField] private CellType _cellType;
    private Direction _direction;
    private Table _table;
    private Vector2 _cellPosition;

    private float _stepTime = 0.5f;
    private float _currentStepTime = 0;
    private bool _isMoving = false;
    private Animator _animator;

    public bool IsMoving => _isMoving;
    public CellType CellType => _cellType;
    public Direction Direction => _direction;
    public Vector2 CellPosition => _cellPosition;

    private void Start()
    {
        _table = ObjectPool.Instance.GetObject(ObjectType.Table).GetComponent<Table>();
        _animator = GetComponent<Animator>();
        gameObject.SetActive(true);
    }

    private void Update()
    {
        if (_isMoving)
        {
            _currentStepTime += Time.deltaTime;

            if (_currentStepTime >= _stepTime)
            {
                _currentStepTime = 0;
                _isMoving = false;

                switch (_table.CheckItemCell(_cellPosition))
                {
                    case CellType.Bomb:
                        GameObject go = ObjectPool.Instance.GetObject(ObjectType.Explosion);
                        go.transform.position = _table.GetPosition(_cellPosition);
                        go.SetActive(true);
                        _table.RemoveCellType(_cellPosition);
                        gameObject.SetActive(false);

                        EventManager.Instance.ShakeCamera();
                        SoundManager.Instance.PlaySound(SoundType.Boom);

                        if (VibroManager.Instance.IsEnabled)
                        {
                            Handheld.Vibrate();
                        }

                        break;
                }
            }
        }
    }

    public virtual void SetPosition(Vector2 position)
    {
        _cellPosition = position;
       _table.SetCellType(position, CellType.Pig);
        transform.position = _table.GetPosition(position);
    }

    public virtual void MoveTo(Direction direction)
    {
        if (!_isMoving)
        {
            _direction = direction;

            switch (_direction)
            {
                case Direction.Down:
                    if (_table.CheckCell(_cellPosition + Vector2.up))
                    {
                        _cellPosition = _cellPosition + Vector2.up;
                    }

                    if (_animator != null)
                    {
                        _animator.SetInteger("Direction", 1);
                    }
                    break;
                case Direction.Up:
                    if (_table.CheckCell(_cellPosition + Vector2.down))
                    {
                        _cellPosition = _cellPosition + Vector2.down;
                    }

                    if (_animator != null)
                    {
                        _animator.SetInteger("Direction", 0);
                    }
                    break;
                case Direction.Left:
                    if (_table.CheckCell(_cellPosition + Vector2.left))
                    {
                        _cellPosition = _cellPosition + Vector2.left;
                    }

                    if (_animator != null)
                    {
                        _animator.SetInteger("Direction", 3);
                    }
                    break;
                case Direction.Right:
                    if (_table.CheckCell(_cellPosition + Vector2.right))
                    {
                        _cellPosition = _cellPosition + Vector2.right;
                    }

                    if (_animator != null)
                    {
                        _animator.SetInteger("Direction", 2);
                    }
                    break;
            }
            _isMoving = true;

            transform.DOMove(_table.GetPosition(_cellPosition), _stepTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_cellType == CellType.Pig)
        {
            gameObject.SetActive(false);
            Announcer.Instance.DisplayText("Death", Vector3.zero);
        }
    }
}
