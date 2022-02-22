using UnityEngine;

// ������� ������ Neighnour ������ ������  ��������  �������, � �������� ���������� ��������, ����� ������� �������� � ���������� ����� 
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
