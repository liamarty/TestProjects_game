using System.Collections.Generic;
using UnityEngine;

public class Matrix
{
    public int cols; public int rows; public int colorsNum;

    // —писок €чеек (блоков), содержащихс€ в матрице
    public List<Cell> cells = new List<Cell>();

    public Matrix()
    {
        GetParameters();        // ѕри создании экземпл€ра матрицы берутс€ дефолтные или заданные игроком параметры
        CreateMatrixCells();    // —оздание €чеек матрицы и присваивание им случайного цвета 
    }

    private void GetParameters()
    {
        cols = Parameters.colsNum;
        rows = Parameters.rowsNum;
        colorsNum = Parameters.colorsNum;
    }

    private void CreateMatrixCells()
    {
        System.Random rand = new System.Random();

        Color[] colorSet = Colors.GetColorSet();

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
                cells.Add(new Cell(x, y, colorSet[rand.Next(colorsNum)]));
        }
    }



    //:(
    /*
    public void UpdateMatrix(int[] deletedCellsID)
    {
  
        foreach (int id in deletedCellsID)
            this.cells[id].SetEmpty();       

        MoveCells();
      
          //AnimationManager.EmptyBlocksAnimation(ForDelete());
        Parameters.isMatrixUpdated = true;
       // MyDebugger.PrintAllCells(cells);

    }    

    private void MoveCells()
    {       
        for (int col = 0; col < cols; col++)        
            AssessColumn(col);        
    }

    private void AssessColumn(int col)
    {
        //—писок элементов, которые должны упасть
        List<Cell> cellsToFall = new List<Cell>();
        int offset = 0;

        for (int row = 0; row < rows; row++)
        {
            Cell current = GetCellByXY(col,row);

            if (!current.isEmpty)            
                cellsToFall.Add(current);
            
            if (row < rows - 1)
            {
                if (GetCellByXY(col, row + 1).isEmpty)
                {
                    row++;
                    while (row < rows && GetCellByXY(col, row).isEmpty)
                    {
                        row++;
                        offset++;
                        if (row == rows) break;
                    }

                    if (row < rows)
                    {
                        foreach (Cell c in cellsToFall)
                        {                          
                            GetCellByXY(col, c.row + offset).color = c.color;
                            GetCellByXY(col, c.row + offset).isEmpty = false;                            
                        }
                        for (int i = 0; i < offset; i++)
                        {
                            cellsToFall[i].SetEmpty();
                        }
                    }
                }
            }
        }
        
    }
 

    public int[] ForDelete()
    {
        List<Cell> cellsForDelete = cells.FindAll(c => c.isEmpty == true);
        int[] forDel = new int[cellsForDelete.Count];
        int i = 0;
        foreach (Cell c in cellsForDelete)
        {
            forDel[i] = c.id; 
            i++;
        }
                return forDel;
    }
   
     public Cell GetCellByXY(int X, int Y)
    {
        foreach (Cell item in cells)
        {
            if (item.col == X && item.row == Y) return item;
        }
        return null;
    }*/

   /* public Cell[,] ListCellsToArray()
    {
        Cell[,] cell = new Cell[cols, rows];

        for (int row = 0; row < rows; row++)

            for (int col = 0; col < cols; col++)
                cell[col, row] = GetCellByXY(col, row);

        return cell;
    }*/

}





