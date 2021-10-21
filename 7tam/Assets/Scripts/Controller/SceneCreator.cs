using UnityEngine;


public class SceneCreator : ITurnOn
{
    private Table _table;

    public void TurnOn()
    {
        Initialize();
    }

    public void TurnOff()
    {
        _table.TurnOff();
    }

    private void Initialize()
    {
        _table = ObjectPool.Instance.GetObject(ObjectType.Table).GetComponent<Table>();

        for (int i = 0; i < _table.MaxYCells ; i++)
        {
            for (int k = 0; k < _table.MaxXCells; k++)
            {
                if ((i % 2 != 0) && (k % 2 != 0))
                {
                    Vector2 vector = new Vector2(k, i);
                    _table.SetCellType(vector, CellType.Stone);
                }
            }
        }
    }
}
