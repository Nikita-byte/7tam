using UnityEngine;
using System.Collections.Generic;


public class EnemyController : ITurnOn, IUpdate
{
    private List<BaseCharacter> _enemies;
    private Table _table;

    public void TurnOn()
    {
        if (_enemies == null)
        {
            _enemies = new List<BaseCharacter>();
        }

        if (_table == null)
        {
            _table = ObjectPool.Instance.GetObject(ObjectType.Table).GetComponent<Table>();
        }

        InitiateEnemies();
    }

    public void TurnOff()
    {
        _enemies.Clear();
    }

    public void Update()
    {
        ChoseDirection();
    }

    public void FixedUpdate()
    {
    }

    public void LateUpdate()
    {
    }

    private void InitiateEnemies()
    {
        _enemies.Add(ObjectPool.Instance.GetObject(ObjectType.Dog).GetComponent<BaseCharacter>());
        _enemies.Add(ObjectPool.Instance.GetObject(ObjectType.Farmer).GetComponent<BaseCharacter>());

        _enemies[0].SetPosition(new Vector2(_table.MaxXCells - 1,0));
        _enemies[1].SetPosition(new Vector2(_table.MaxXCells - 1, _table.MaxYCells - 1));

        foreach (BaseCharacter go in _enemies)
        {
            go.gameObject.SetActive(true);
        }
    }

    private void ChoseDirection()
    {
        foreach (BaseCharacter enemy in _enemies)
        {
            if (!enemy.IsMoving)
            {
                Direction direction;

                if (Random.Range(0, 100) > 25)
                {
                    direction = enemy.Direction;
                }
                else
                {
                    do
                    {
                        int random = Random.Range(0, 4);
                        switch (random)
                        {
                            case 0:
                                direction = Direction.Up;
                                break;
                            case 1:
                                direction = Direction.Down;
                                break;
                            case 2:
                                direction = Direction.Right;
                                break;
                            case 3:
                                direction = Direction.Left;
                                break;
                            default:
                                direction = Direction.Up;
                                break;
                        }
                    } while (direction == enemy.Direction);
                }


                enemy.MoveTo(direction);
            }
        }
    }
}
