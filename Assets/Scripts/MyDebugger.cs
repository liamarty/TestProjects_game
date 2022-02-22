using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Debug.Log(string.Format(" {},{},{},{},{}", , , , , ));
public static class MyDebugger
{
    public static void MSG(string msg)
    {
        Debug.Log("***" + msg + "***");
    }
    public static void Alert(string msg)
    {
        Debug.Log("#####################" + msg + "###############################");
    }

    static public void PrintCell(Cell C)
    {
        Debug.Log(string.Format("Ячейка ( {0}, {1} ) Цвет - {2}, Пустая = {3}", C.col, C.row, C.color, C.isEmpty));
    }
    static public void PrintCell(Neighbour N)
    {
        Debug.Log(string.Format("Сосед ( {0}, {1} ) Проверен - {2}, Целевой - {3}", N.col, N.row, N.isChecked, N.isTheSame));
    }

    public static void PrintAllCells(List<Cell> cells)
    {
        foreach (Cell item in cells) PrintCell(item);
    }

    public static void PrintAllCells(Cell[] cells)
    {
        foreach (Cell item in cells) PrintCell(item);
    }

    public static void PrintAllCells(Neighbour [] cells)
    {
        foreach (Cell item in cells) PrintCell(item);
    }
    public static void PrintAllCells(List<Neighbour> cells)
    {
        foreach (Neighbour item in cells) PrintCell(item);           
    }
    public static void PrintComparedCells(List<Cell> C, List<Neighbour> N)
    {
        for (int i = 0; i < C.Count; i++)
        {           
            Debug.Log(string.Format("Ячейка ( {0}, {1} ) имеет цвет {2}", C[i].col, C[i].row, C[i].color));
            Debug.Log(string.Format("Сосед ( {0}, {1} ) имеет цвет {2}, флаги: проверен - {3}, хороший сосед - {4}", N[i].col, N[i].row, N[i].color, N[i].isChecked, N[i].isTheSame));
        }
           
    }


    public static void LogSomething(string source, string formatedMSG, IList values )
    {
        string message = "*" + source + " говорит*: ";
        message += formatedMSG;
        Debug.Log(string.Format(message, values));
    }
}
