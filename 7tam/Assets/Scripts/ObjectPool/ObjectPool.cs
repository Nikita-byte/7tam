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

    private int _countStoneInPool = 25;
    private Queue<GameObject> _stones;

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

        _backGround = _objectFactory.BackGround;
        _camera = _objectFactory.Camera;
        _table = _objectFactory.Table;
        _pig = _objectFactory.Pig;


        for (int i = 0; i < _countStoneInPool; i++)
        {
            GameObject go = _objectFactory.Stone;
            go.transform.SetParent(_pool.transform);
            _stones.Enqueue(go);
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
            case ObjectType.Stone:
                go = _stones.Dequeue();
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
            case ObjectType.Stone:
                _stones.Enqueue(gameObject);
                break;
        }
    }

    public Dictionary<string, Sprite> GetSprites()
    {
        return _objectFactory.Sprites;
    }
}
