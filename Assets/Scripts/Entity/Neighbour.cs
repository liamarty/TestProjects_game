using UnityEngine;

// ќбъекты класса Neighnour хран€т €чейки  исходной  матрицы, с которыми провод€тс€ операции, чтобы вы€вить соседние и однотипные блоки 
public class Neighbour : Cell
{
    public bool isChecked;
    public bool isTheSame;

    public Neighbour(int cellColumn, int cellRow, Color cellColor, int id) : base(cellColumn, cellRow, cellColor)
    {
        isChecked = false;
        isTheSame = false;
    
    }

}
