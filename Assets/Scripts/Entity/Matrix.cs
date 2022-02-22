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

    public void UpdateMatrix(int[] deletedCellsID)
    {
        foreach (int id in deletedCellsID)
            this.cells[id].isEmpty = true;       

        MoveCells();

        AnimationManager.EmptyBlocksAnimation(ForDelete());
        Parameters.isMatrixUpdated = true;
        MyDebugger.PrintAllCells(cells);

    }

    int offset = 0;

    private void MoveCells()
    {
       
        for (int col = 0; col < cols; col++)
        {
            AssessColumn(col);
        }
    }

    private void AssessColumn(int col)
    {
        List<Cell> cellsToFall = new List<Cell>();

        for (int row = 0; row < rows; row++)
        {
            Cell current = GetCellByXY(col,row);

            if (!current.isEmpty)
            {
                cellsToFall.Add(current);
            }
            if ((row + 1) < rows)
            {
                if (GetCellByXY(col, row + 1).isEmpty)
                {
                    row++;
                    while (row < rows && GetCellByXY(col, row).isEmpty)
                    {
                        row++;
                        offset++;
                    }

                    if (row < rows)
                    {
                        foreach (Cell c in cellsToFall)
                        {                          
                            GetCellByXY(col, c.row + offset-1).color = c.color;
                            GetCellByXY(col, c.row + offset-1).isEmpty = false;
                            c.isEmpty = true;
                        }
                    }
                }
            }
        }
        cellsToFall.Clear(); offset = 0;
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
   

   
    public Cell[,] ListCellsToArray()
    {
        Cell[,] cell = new Cell[cols, rows];

        for (int row = 0; row < rows; row++)

            for (int col = 0; col < cols; col++)
                cell[col, row] = GetCellByXY(col,row);

        return cell;
    }

    public Cell GetCellByXY(int X, int Y)
    {
        foreach (Cell item in cells)
        {
            if (item.col == X && item.row == Y) return item;
        }
        return null;
    }


}

/*
 *  for (int row = 0; row < rows; row++)
            {
                if (!(GetCellByXY(col,row)).isEmpty) cellsToFall.Add(GetCellByXY(col,row));
                {
                    if (Algorithm.IsCellExist(col, row + 1))
                    {
                        if (GetCellByXY(col,(row+1)).isEmpty)
                        {
                            row++;
                            while (GetCellByXY(col,row).isEmpty)
                            {
                                row++;
                                offset++;
                                if (row == rows) break;
                            }
                        }

                        for (int i = ((cellsToFall.Count) - 1); i >= 0; i--)
                        {
                            if (Algorithm.IsCellExist(col, cellsToFall[i].row + offset))
                            {
                                GetCellByXY(col, cellsToFall[i].row + offset).color = cellsToFall[i].color;
                                GetCellByXY(col, cellsToFall[i].row + offset).isEmpty = false;
                            }
                        }
                        foreach (Cell item in cellsToFall)
                        {
                            item.isEmpty = true;
                        }
                        offset = 0;
                    }
                }
            }    cellsToFall.Clear();
 * 
  public void UpdateMatrix(int[] deletedCellsID)  
    {       
        foreach (int id in deletedCellsID)        
            this.cells[id].isEmpty = true;

        MoveCells();
        Parameters.isMatrixUpdated = true;
    }

    Cell[,] cell;

    List<Cell> cellsToFall;

    int offset = 0;

    private void MoveCells() 
    {
        cell = ListCellsToArray();

        cellsToFall = new List<Cell>();   


        for (int col = 0; col < cols; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                if (!cell[col, row].isEmpty) cellsToFall.Add(cell[col, row]);
                {
                    if (Algorithm.IsCellExist(col, row + 1))
                    {
                        if (cell[col, row + 1].isEmpty)
                        {
                            row++;
                            while (cell[col, row].isEmpty)
                            {
                                row++;
                                offset++;
                                if (row == rows) break;
                            }
                        }

                        for (int i = ((cellsToFall.Count) - 1); i >= 0; i--)
                        {
                            if (Algorithm.IsCellExist(col, cellsToFall[i].row + offset)) {
                                cell[col, cellsToFall[i].row + offset].color = cellsToFall[i].color;
                                cell[col, cellsToFall[i].row + offset].isEmpty = false;
                            }
                        }
                        foreach (Cell item in cellsToFall)
                        {
                            item.isEmpty = true;
                        }
                        offset = 0;
                    }
                }
            }



        }
        cellsToFall.Clear();
    }
 */




