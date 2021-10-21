using UnityEngine;
using System.Collections.Generic;


public class ObjectFactory
{
    private Dictionary<string, Sprite> _sprites;

    public ObjectFactory()
    {
        _sprites = new Dictionary<string, Sprite>();
        Sprite[] sprites = Resources.LoadAll<Sprite>(AssetsPath.Path[ObjectType.Sprites]);
        GameObject[] gameobjects = Resources.LoadAll<GameObject>(AssetsPath.Path[ObjectType.Sound]);

        foreach (Sprite sprite in sprites)
        {
            _sprites.Add(sprite.name, sprite);
        }
    }

    public Dictionary<string, Sprite> Sprites 
    {
        get 
        {
            return _sprites;
        }
    }

    public GameObject Camera
    {
        get
        {
            GameObject camera = GameObject.Instantiate(Resources.Load<GameObject>(AssetsPath.Path[ObjectType.Camera]));
            return camera;
        }
    }

    public GameObject BackGround
    {
        get
        {
            GameObject bg = GameObject.Instantiate(Resources.Load<GameObject>(AssetsPath.Path[ObjectType.BackGround]));
            //bg.GetComponent<SpriteRenderer>().sprite = _sprites["bg"];
            return bg;
        }
    }

    public GameObject Table
    {
        get
        {
            GameObject table = GameObject.Instantiate(Resources.Load<GameObject>(AssetsPath.Path[ObjectType.Table]));
            table.GetComponent<Table>().InitializeTable();
            return table;
        }
    }

    public GameObject Pig
    {
        get
        {
            GameObject pig = GameObject.Instantiate(Resources.Load<GameObject>(AssetsPath.Path[ObjectType.Pig]));
            return pig;
        }
    }

    public GameObject Stone
    {
        get
        {
            GameObject stone = GameObject.Instantiate(Resources.Load<GameObject>(AssetsPath.Path[ObjectType.Stone]));
            return stone;
        }
    }

    public GameObject Explosion
    {
        get
        {
            GameObject explosion = GameObject.Instantiate(Resources.Load<GameObject>(AssetsPath.Path[ObjectType.Explosion]));
            return explosion;
        }
    }

    public GameObject Bomb
    {
        get
        {
            GameObject bomb = GameObject.Instantiate(Resources.Load<GameObject>(AssetsPath.Path[ObjectType.Bomb]));
            return bomb;
        }
    }

    public GameObject Dog
    {
        get
        {
            GameObject dog = GameObject.Instantiate(Resources.Load<GameObject>(AssetsPath.Path[ObjectType.Dog]));
            return dog;
        }
    }

    public GameObject Farmer
    {
        get
        {
            GameObject farmer = GameObject.Instantiate(Resources.Load<GameObject>(AssetsPath.Path[ObjectType.Farmer]));
            return farmer;
        }
    }

    public GameObject Text
    {
        get
        {
            GameObject text = GameObject.Instantiate(Resources.Load<GameObject>(AssetsPath.Path[ObjectType.Text]));
            return text;
        }
    }
}
