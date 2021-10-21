using UnityEngine;
using System.Collections.Generic;


public class Table : MonoBehaviour
{
    private int _maxXcells = 17;
    private int _maxYcells = 9;

    private Vector2 _firstPoint = new Vector2(-8.398f, 3.494f);
    private Vector2 _step = new Vector2(-0.132f, 0);
    private float _Xstep = 1.104f;
    private float _Ystep = -1.005f;
    private Cell[,] _cells;
    private List<GameObject> _objectsOnTable;
    private Dictionary<Vector2, GameObject> _bombs;

    public int MaxXCells => _maxXcells;
    public int MaxYCells => _maxYcells;


    public void InitializeTable()
    {
        _cells = new Cell[_maxYcells, _maxXcells];
        Vector2 tempPosition = _firstPoint;
        _objectsOnTable = new List<GameObject>();
        _bombs = new Dictionary<Vector2, GameObject>();

        for (int i = 0; i < _maxYcells; i++)
        {
            for (int k = 0; k < _maxXcells; k++)
            {
                _cells[i, k] = new Cell(tempPosition + new Vector2(_Xstep * k, _Ystep * i));
            }

            tempPosition += _step;
        }
    }

    public void TurnOff()
    {
        foreach (GameObject go in _objectsOnTable)
        {
            ObjectPool.Instance.ReturnInPool(ObjectType.Stone, gameObject);
        }

        _objectsOnTable.Clear();
        _bombs.Clear();
    }

    public bool CheckCell(Vector2 position)
    {
        if ((int)position.x < 0 || (int)position.x >= _maxXcells ||
            (int)position.y < 0 || (int)position.y >= _maxYcells ||
            _cells[(int)position.y, (int)position.x].CellType == CellType.Stone)
        {
            return false;
        }

        return true;
    }

    public CellType CheckItemCell(Vector2 position)
    {
        return _cells[(int)position.y, (int)position.x].CellType;
    }

    public Vector2 GetPosition(Vector2 cellPosition)
    {
        return _cells[(int)cellPosition.y, (int)cellPosition.x].Cellposition;
    }

    public void SetCellType(Vector2 position, CellType cellType)
    {
        GameObject go;
        switch (cellType)
        {
            case CellType.Stone:
                go = ObjectPool.Instance.GetObject(ObjectType.Stone);
                _objectsOnTable.Add(go);
                go.SetActive(true);
                go.transform.position = _cells[(int)position.y, (int)position.x].Cellposition;
                break;
            case CellType.Bomb:
                go = ObjectPool.Instance.GetObject(ObjectType.Bomb);
                go.SetActive(true);
                _bombs.Add(position, go);
                go.transform.position = _cells[(int)position.y, (int)position.x].Cellposition;
                break;
        }

        _cells[(int)position.y, (int)position.x].CellType = cellType;
    }

    public void RemoveCellType(Vector2 position)
    {
        GameObject go;
        switch (_cells[(int)position.y, (int)position.x].CellType)
        {
            case CellType.Stone:
                break;
            case CellType.Bomb:
                go = _bombs[position];
                ObjectPool.Instance.ReturnInPool(ObjectType.Bomb, go);
                _bombs.Remove(position);
                break;
        }

        _cells[(int)position.y, (int)position.x].CellType = CellType.None;
    }
}
