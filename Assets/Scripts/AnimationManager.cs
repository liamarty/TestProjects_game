using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class AnimationManager
{
    //********* ���������� ��������� �������� ��������� � ���������� **********
    public static void ManageInvalidInputs(bool isInvalid)
    {
        PaintFields(isInvalid);
        if(isInvalid) ShowAlert("������ � ������: �� 10 �� 50, �����  ������: �� 3 �� 5");
    }
    private static void PaintFields(bool isInvalid)
    {
        Text height = GameObject.Find("Text_height").GetComponent<Text>();
        Text width = GameObject.Find("Text_width").GetComponent<Text>(); ;
        Text colors = GameObject.Find("Text_colors").GetComponent<Text>(); ;

        Color color;
        if (isInvalid) color = Color.red;
        else color = Color.black;

        height.GetComponent<Text>().color = color;
        width.GetComponent<Text>().color = color;
        colors.GetComponent<Text>().color = color;
    }
    public static void ShowAlert(string message)
    {      
        GameObject alert = GameObject.Find("Message");
        alert.GetComponent<Text>().text = message;
        Animator animatorText = alert.GetComponent<Animator>();        
        animatorText.Play("TextAlert");      
    }
    //***********************************************************************


    //************* ���������� ���������� ������ ****************************
    public static void EmptyBlocksAnimation(int[] blockForDeleteIDs)
    {
        Animator blockAnimator;
        foreach (int blockID in blockForDeleteIDs)
        {
            blockAnimator = GameObject.Find("block_" + blockID).GetComponent<Animator>();
            blockAnimator.Play("EmptyBlock");
        }
    }

    public static void UpdateScore()
    {
        GameObject score = GameObject.Find("Score");
        Text scoreText = score.GetComponent<Text>();
        Animator animator = score.GetComponent<Animator>();

        scoreText.text = Parameters.score.ToString();
        animator.Play("AddScore");

    }
    public static void UpdateMatrixView()
    {
       Matrix matrix = Parameters.GetGameMatrix();
        List<Cell> cellsForDelete = new List<Cell>(); 


        cellsForDelete = matrix.cells.FindAll(c => c.isEmpty == true);
        
        int[] IDs = new int[cellsForDelete.Count];
        
        for (int i = 0; i < IDs.Length; i++) IDs[i] = cellsForDelete[i].id;

        EmptyBlocksAnimation(IDs);
    }




}
