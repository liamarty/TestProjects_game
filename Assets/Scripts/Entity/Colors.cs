using System.Collections.Generic;
using UnityEngine;

public static class Colors
{          
    static List<Color>[] colorPool = new List<Color>[3];   

    private static  void InitColors()
    {
        // Варианты палитр для блоков
        colorPool[0] = new List<Color>() { new Color(0.74f, 0.45f, 0.14f),   new Color(0.82f, 0.78f, 0.20f),  new Color(0.15f, 0.20f, 0.31f),
                                           new Color(0.61f, 0.75f, 0.82f),   new Color(0.77f, 0.84f, 0.72f)};

        colorPool[1] = new List<Color>() { new Color(0.60f, 0.21f, 0.15f),   new Color(0.71f, 0.56f, 0.39f),  new Color(0.14f, 0.20f, 0.31f),
                                           new Color(0.43f, 0.56f, 0.70f ),  new Color(0.78f, 0.78f, 0.82f),  new Color(0.86f, 0.56f, 0.24f )};

        colorPool[2] = new List<Color>() { new Color(0.85f, 0.25f, 0.4f),    new Color(0.53f, 0.82f, 0.96f),  new Color(0.49f, 0.2f, 0.45f),
                                           new Color(0.64f, 0.36f, 0.52f ),  new Color(0.5f, 0.38f, 0.55f),   new Color(0.22f, 0.14f, 0.24f) };
    }
    public static Color[] GetColorSet()
    {  
        InitColors();
        List<Color> colorSet = new List<Color>(3);

        // Выбирается рандомная палитра и рандомные цвета  из неё, которые соответсвуют требуемому количеству цветов

        System.Random rand = new System.Random();
        int poolID = rand.Next(colorPool.Length);     
        Parameters.colorScheme = poolID ;                 // Поле служит для отрисовки соответсвующего фона        
        int itemsNum;
        int randInd;

        for (int i = 0; i < Parameters.colorsNum; i++)
        {
            itemsNum = colorPool[poolID].Count;
            randInd = rand.Next(itemsNum);
            colorSet.Add(colorPool[poolID][randInd]);    
            colorPool[poolID].RemoveAt(randInd);
        }

        return colorSet.ToArray();
    }

}
