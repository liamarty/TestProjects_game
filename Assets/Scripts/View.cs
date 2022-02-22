using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ��������� ��������� ���� �� �����
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

    // ����� ������������ �����, �������������� ������� � ������ �������
    private void RenderBlocks(List<Cell> matrix, float blockSide)
    {
        GameObject blockPref = Resources.Load<GameObject>("Prefabs/BlockPref");     //������ �����
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

    // ����� ��������� ���������� �������� ������
    private void SetGameArea(float blockSide)
    {
        //��������� ���������� � ����������� ����������� �������
        GameObject.Find("Canvas").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/background_" + Parameters.colorScheme);

        //��������� �������� �������� ����       
        gameArea.GetComponent<RectTransform>().sizeDelta = new Vector2(Parameters.colsNum * blockSide, Parameters.rowsNum * blockSide);

        //��������� ����� ��� ���������� ������
        grid.cellSize = new Vector2(0.9f * blockSide, 0.9f * blockSide);
        grid.spacing = new Vector2(0.1f * blockSide, 0.1f * blockSide);
    }

    // ������� ��������� ������� �� ������, ����� ����� ���� ������������� ���� � ������ ����������� ����
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
