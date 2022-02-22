using UnityEngine;

//GameObject GameArea 
// �������� ���������� �������� ����

public class GameController : MonoBehaviour
{
    Matrix gameMatrix;
    View view;

    void Start()    
    {  
        gameMatrix = Parameters.GetGameMatrix();
        gameObject.AddComponent<View>();
        view = gameObject.GetComponent<View>();
        view.RenderView(gameMatrix.cells, GetBlockSide());
    }

    void Update()
    {
        if (Parameters.isRestarted)
        {
            view.RenderView(Parameters.GetGameMatrix().cells, GetBlockSide());
            Parameters.score = 0;
            AnimationManager.UpdateScore();
            Parameters.isRestarted = false;           
        }    
    }

    //����� ������������ �������, ����������� �������� ��� ����� � ������� �������
    float GetBlockSide()
    {
        float blockSide;        
        float byWidth = Parameters.maxWidth / Parameters.colsNum;
        float byHeight = Parameters.maxHeight / Parameters.rowsNum;
        blockSide = System.Math.Min(byWidth, byHeight);
        return blockSide;
    }


}