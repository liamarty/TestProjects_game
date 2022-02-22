using System.Collections.Generic;
using UnityEngine;

// Модуль, в котором происходит работа алгоритма поиска соседей одного целевого цвета
// Концепция алгоритма: для нажатого блока находятся 4 соседних блока (сверху, справа, снизу, слева), каждый сосед проверяется на совпадение цвета с нажатым блоком.
// Для каждого одноцветного соседа в свою очередь так же находятся соседи и так далее для каждого элемента нужного цвета. Алгоритм  закончен на итерации, когда новые похожие соседи не найдены  
static public class Algorithm
{
    static Neighbour origin;
    static Color targetColor;
    static List<Neighbour> neighbours;

    //Отступы для нахождения соседей сверху, справа, снизу и слева
    static readonly int[] offsetX = { 0, 1, 0, -1 };
    static readonly int[] offsetY = { -1, 0, 1, 0 };

    // Точка входа в алгоритм
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
    
    // Метод возвращает массив всех одноцветных соседей
    private static Neighbour[] GetTheSame()
    {
        // список, содержащий целевых соседей на каждом уровне
        // уровень - итерация алгорита. На каждой итерации находится новый массив соседей

        List<Neighbour[]> levels = new List<Neighbour[]>();

        //первая итерация (поиск соседей для нажатого блока) 
        Neighbour[] firstN = GetNearestForN(origin);

        if (firstN != null)  levels.Add(firstN);            
                      
       
        // когда на новой итерации не будут получены новые подходящие соседи - поиск оркончен 
        int i = 0;
        while (levels[i].Length != 0)
        {   
            List<Neighbour> totalOnNextLevel = new List<Neighbour>();       //список для сохранения подходящих соседей на итерации 

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
        // создание области соседей на основе ячеек исходной матрицы
        List<Cell> cells = matrix.cells;                  
        neighbours = new List<Neighbour>();
       
        foreach (Cell cell in cells)
            neighbours.Add(new Neighbour(cell.col, cell.row, cell.color, cell.id));            

        // инициализация целевых значений: нажатый блок и целевой цвет 
        origin = neighbours[ID];
        targetColor = origin.color;
    }
}
