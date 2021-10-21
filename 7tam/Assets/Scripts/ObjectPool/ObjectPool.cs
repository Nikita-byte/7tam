using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public sealed class ObjectPool
{
    private static ObjectPool _objectPool;
    private GameObject _pool;

    private GameObject _camera;
    private GameObject _backGround;
    private GameObject _table;
    private GameObject _pig;
    private GameObject _dog;
    private GameObject _farmer;

    private int _countStoneInPool = 32;
    private int _countExplosionsInPool = 10;
    private int _countBombsInPool = 10;
    private int _countTextsInPool = 5;
    private Queue<GameObject> _stones;
    private Queue<GameObject> _explosions;
    private Queue<GameObject> _bombs;
    private Queue<GameObject> _texts;

    private ObjectFactory _objectFactory;

    public static ObjectPool Instance
    {
        get
        {
            if (_objectPool == null)
            {
                _objectPool = new ObjectPool();
            }
            return _objectPool;
        }
    }

    public ObjectPool()
    {
        _objectFactory = new ObjectFactory();
        _pool = new GameObject("[Pool]");
        _stones = new Queue<GameObject>();
        _explosions = new Queue<GameObject>();
        _bombs = new Queue<GameObject>();
        _texts = new Queue<GameObject>();

        _backGround = _objectFactory.BackGround;
        _camera = _objectFactory.Camera;
        _table = _objectFactory.Table;
        _pig = _objectFactory.Pig;
        _dog = _objectFactory.Dog;
        _farmer = _objectFactory.Farmer;

        GameObject go;

        for (int i = 0; i < _countStoneInPool; i++)
        {
            go = _objectFactory.Stone;
            go.transform.SetParent(_pool.transform);
            _stones.Enqueue(go);
            go.SetActive(false);
        }

        for (int i = 0; i < _countExplosionsInPool; i++)
        {
            go = _objectFactory.Explosion;
            go.transform.SetParent(_pool.transform);
            _explosions.Enqueue(go);
            go.SetActive(false);
        }

        for (int i = 0; i < _countBombsInPool; i++)
        {
            go = _objectFactory.Bomb;
            go.transform.SetParent(_pool.transform);
            _bombs.Enqueue(go);
            go.SetActive(false);
        }

        for (int i = 0; i < _countTextsInPool; i++)
        {
            go = _objectFactory.Text;
            go.transform.SetParent(_pool.transform);
            _texts.Enqueue(go);
            go.SetActive(false);
        }
    }

    public GameObject GetObject(ObjectType objectType)
    {
        GameObject go;

        switch (objectType)
        {
            case ObjectType.BackGround:
                go = _backGround;
                go.transform.position = Vector3.zero;
                break;
            case ObjectType.Camera:
                go = _camera;
                break;
            case ObjectType.Table:
                go = _table;
                break;
            case ObjectType.Pig:
                go = _pig;
                break;
            case ObjectType.Dog:
                go = _dog;
                break;
            case ObjectType.Farmer:
                go = _farmer;
                break;
            case ObjectType.Text:
                go = _texts.Dequeue();
                break;
            case ObjectType.Stone:
                go = _stones.Dequeue();
                break;
            case ObjectType.Explosion:
                go = _explosions.Dequeue();
                break;
            case ObjectType.Bomb:
                go = _bombs.Dequeue();
                break;

            default:
                go = null;
                break;
        }

        //go.SetActive(true);

        return go;
    }

    public void ReturnInPool(ObjectType objectType, GameObject gameObject)
    {
        gameObject.SetActive(false);
        gameObject.transform.SetParent(_pool.transform);

        switch (objectType)
        {
            case ObjectType.BackGround:
                break;
            case ObjectType.Camera:
                break;
            case ObjectType.Table:
                break;
            case ObjectType.Text:
                _texts.Enqueue(gameObject);
                break;
            case ObjectType.Stone:
                _stones.Enqueue(gameObject);
                break;
            case ObjectType.Explosion:
                _explosions.Enqueue(gameObject);
                break;
            case ObjectType.Bomb:
                _bombs.Enqueue(gameObject);
                break;
        }
    }

    public Dictionary<string, Sprite> GetSprites()
    {
        return _objectFactory.Sprites;
    }
}
