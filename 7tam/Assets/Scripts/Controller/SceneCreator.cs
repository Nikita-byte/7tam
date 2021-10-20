using UnityEngine;


public class SceneCreator : ITurnOn
{
    private GameObject _table;

    public void TurnOn()
    {
        Initialize();
    }

    public void TurnOff()
    {
    }

    private void Initialize()
    {
        _table = ObjectPool.Instance.GetObject(ObjectType.Table);
    }
}
