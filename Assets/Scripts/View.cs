using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Компонент отрисовки игры на экран
public class View : MonoBehaviour 
{
    GameObject gameArea;
    GridLayoutGroup grid;       

    public void RenderView(List<Cell> matrix, float blockSide)
    {
        gameArea = GameObject.Find("GameArea");
        grid = gameArea.GetComponent<GridLayoutGroup>();
      
        ClearGameArea();
        SetGameArea(blockSide);
        RenderBlocks(matrix, blockSide);
    }

    // Метод отрисовывает блоки, соответсвующие ячейкам в модели матрицы
    private void RenderBlocks(List<Cell> matrix, float blockSide)
    {
        GameObject blockPref = Resources.Load<GameObject>("Prefabs/BlockPref");     //шаблон блока
        int i = 0;
        foreach (Cell cell in matrix)
        {
            GameObject block = Instantiate(blockPref, gameArea.transform);
            block.name = "block_" + cell.id;
            block.GetComponent<RectTransform>().sizeDelta = new Vector2(blockSide * 0.9f, blockSide * 0.9f);
            block.GetComponent<RectTransform>().localPosition = new Vector2(blockSide * i, blockSide * i);
                Color clr;
                if (cell.isEmpty) clr = Color.black;
                else clr = cell.color;
            block.GetComponent<Image>().color = clr;
            
            i++;
        }
    }

    // Метод настройки параметров игрового экрана
    private void SetGameArea(float blockSide)
    {
        //установка бэкграунда в соответсвие подобранной палитре
        GameObject.Find("Canvas").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/background_" + Parameters.colorScheme);

        //настройка размеров игрового поля       
        gameArea.GetComponent<RectTransform>().sizeDelta = new Vector2(Parameters.colsNum * blockSide, Parameters.rowsNum * blockSide);

        //настройка сетки для размещения блоков
        grid.cellSize = new Vector2(0.9f * blockSide, 0.9f * blockSide);
        grid.spacing = new Vector2(0.1f * blockSide, 0.1f * blockSide);
    }

    // Очищает игрововую область от блоков, чтобы можно было перезапустить игру с новыми параметрами поля
    private void ClearGameArea()
    {
        GameObject block;
        int blocksNum = gameArea.transform.childCount;
        
        for (int i = 0; i < blocksNum; i++)
        {
            block = GameObject.Find("block_" + i);
            Destroy(block);
        }
    }

}
