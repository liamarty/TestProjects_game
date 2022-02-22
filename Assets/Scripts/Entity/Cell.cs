using UnityEngine;

public class Cell
{
    public int id;
    public int col;
    public int row;
    public Color color;   
    public bool isEmpty = false;

    public Cell(int cellColumn, int cellRow, Color cellColor)
    {
        col = cellColumn;
        row = cellRow;
        color = cellColor;

        id = Parameters.colsNum * row + col;
    }

    public void SetEmpty()
    {
        isEmpty = true;
        color = new Color(0f,0f, 0f,0f);
    }
}
