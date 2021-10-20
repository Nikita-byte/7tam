using UnityEngine;


public class Table : MonoBehaviour
{
    private int _maxXcells = 17;
    private int _maxYcells = 9;

    private Vector2 _firstPoint = new Vector2(-8.398f, 3.494f);
    private Vector2 _step = new Vector2(-0.132f, 0);
    private float _Xstep = 1.104f;
    private float _Ystep = -1.005f;
    private Cell[,] _cells;

    
    //private Vector2[,] _positions = new Vector2[9, 17];


    public void InitializeTable()
    {
        _cells = new Cell[_maxYcells, _maxXcells];
        Vector2 tempPosition = _firstPoint;

        for (int i = 0; i < _maxYcells; i++)
        {
            for (int k = 0; k < _maxXcells; k++)
            {
                _cells[i, k] = new Cell(tempPosition + new Vector2(_Xstep * k, _Ystep * i));

                if ((i % 2 != 0 ) && (k % 2 != 0)) 
                {
                    SetCellType(new Vector2(i, k), CellType.Stone);
                }
            }

            tempPosition += _step;
        }

        //foreach (Vector2 vector2 in _positions)
        //{
        //    GameObject go = new GameObject();
        //    go.transform.position = vector2;
        //}
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
                go.SetActive(true);
                go.transform.position = _cells[(int)position.y, (int)position.x].Cellposition;
                break;
            case CellType.Bomb:
                break;
        }

        _cells[(int)position.y, (int)position.x].CellType = cellType;
        //_cells[(int)position.y, (int)position.x].CellType = cellType;
        //return _cells[(int)position.x, (int)position.y].Cellposition;
    }
}
