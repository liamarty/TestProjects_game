using System.Collections.Generic;
using UnityEngine;

// ������, � ������� ���������� ������ ��������� ������ ������� ������ �������� �����
// ��������� ���������: ��� �������� ����� ��������� 4 �������� ����� (������, ������, �����, �����), ������ ����� ����������� �� ���������� ����� � ������� ������.
// ��� ������� ������������ ������ � ���� ������� ��� �� ��������� ������ � ��� ����� ��� ������� �������� ������� �����. ��������  �������� �� ��������, ����� ����� ������� ������ �� �������  
static public class Algorithm
{
    static Neighbour origin;
    static Color targetColor;
    static List<Neighbour> neighbours;

    //������� ��� ���������� ������� ������, ������, ����� � �����
    static readonly int[] offsetX = { 0, 1, 0, -1 };
    static readonly int[] offsetY = { -1, 0, 1, 0 };

    // ����� ����� � ��������
    static public int[] GetAllNeighboursID(int clickedBlockId, Matrix matrix)
    {                
        InitData(clickedBlockId, matrix);
        Neighbour[] allNeighbours = GetTheSame();  
        int[] IDs = new int[allNeighbours.Length];
        int i = 0;
        foreach (Neighbour neighbour in allNeighbours)
        {
            IDs[i] = neighbour.id;
            i++;
        }
        return IDs;
    }
    
    // ����� ���������� ������ ���� ����������� �������
    private static Neighbour[] GetTheSame()
    {
        // ������, ���������� ������� ������� �� ������ ������
        // ������� - �������� ��������. �� ������ �������� ��������� ����� ������ �������

        List<Neighbour[]> levels = new List<Neighbour[]>();

        //������ �������� (����� ������� ��� �������� �����) 
        Neighbour[] firstN = GetNearestForN(origin);

        if (firstN != null)  levels.Add(firstN);            
                      
       
        // ����� �� ����� �������� �� ����� �������� ����� ���������� ������ - ����� �������� 
        int i = 0;
        while (levels[i].Length != 0)
        {   
            List<Neighbour> totalOnNextLevel = new List<Neighbour>();       //������ ��� ���������� ���������� ������� �� �������� 

            foreach (Neighbour item in levels[i])
            {
                Neighbour[] forItem = GetNearestForN(item);
                if (forItem == null) continue;
                foreach (Neighbour n in forItem)
                {
                    if (n != null)
                        totalOnNextLevel.Add(n);
                }
            }

            if (totalOnNextLevel != null)
            {
                levels.Add(totalOnNextLevel.ToArray());
                i++;               
            }
            else break;
        }
 
        int num = 0;   
        foreach (Neighbour[] level in levels)
        {
            foreach (Neighbour n in level)            
                num++;               
        }

        Neighbour[] total = new Neighbour[num];

        num = 0;
        foreach (Neighbour[] level in levels)
        {
            foreach (Neighbour n in level)
            {
                total[num] =  n;
                num++;
            }
        }
        return total;
    }

    private static Neighbour[] GetNearestForN(Neighbour N_origin)
    {
        Neighbour N;
        List<Neighbour> simularN = new List<Neighbour>();

        for (int i = 0; i < 4; i++)
        {
            if (IsCellExist(N_origin.col + offsetX[i], N_origin.row + offsetY[i]))
            {
                N = GetNeighbourByXY(N_origin.col + offsetX[i], N_origin.row + offsetY[i]);

                if (!N.isChecked)
                {
                    if (N.color == targetColor)
                    {
                        N.isTheSame = true;
                        simularN.Add(N);
                    }
                    N.isChecked = true;
                }
            }
        }
        return simularN.ToArray(); 

    }
    public static bool IsCellExist(int X, int Y)
    {
        if (X < 0 || X >= Parameters.colsNum || Y < 0 || Y >= Parameters.rowsNum) return false;
        else return true;
    }
    public static Neighbour GetNeighbourByXY(int X, int Y)
    {
        foreach (Neighbour neighbour in neighbours)
        {
            if (neighbour.col == X && neighbour.row == Y) return neighbour;
        }
        return null;
    }

    private static void InitData(int ID, Matrix matrix)
    {
        // �������� ������� ������� �� ������ ����� �������� �������
        List<Cell> cells = matrix.cells;                  
        neighbours = new List<Neighbour>();
       
        foreach (Cell cell in cells)
            neighbours.Add(new Neighbour(cell.col, cell.row, cell.color, cell.id));            

        // ������������� ������� ��������: ������� ���� � ������� ���� 
        origin = neighbours[ID];
        targetColor = origin.color;
    }
}
