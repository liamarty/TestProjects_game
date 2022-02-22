using UnityEngine;
using UnityEngine.EventSystems;

public class ClickController : MonoBehaviour, IPointerClickHandler
{
    // ������ ��������� ������� �� ����
    public void OnPointerClick(PointerEventData eventData)
    {
        // ��������� �������������� �������� �����
        int ID = int.Parse(gameObject.name.Substring(6));

        //���������� �������� ����������� ������ ��� �������� �����     
        int[] neighbours = Algorithm.GetAllNeighboursID(ID, Parameters.GetGameMatrix());
        
        if (neighbours.Length > 2)
        {
            Parameters.score += neighbours.Length;
            AnimationManager.UpdateScore();            
            AnimationManager.EmptyBlocksAnimation(neighbours);
            //������� ������
            //Parameters.GetGameMatrix().UpdateMatrix(neighbours);     
        }
       

    }
}
