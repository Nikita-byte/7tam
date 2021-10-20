using UnityEngine;


public class Cell
{
    public CellType CellType { get; set; } 
    public Vector2 Cellposition { get; set; }

    public Cell(Vector2 position)
    {
        Cellposition = position;
    }
}
