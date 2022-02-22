using UnityEngine;
using UnityEngine.EventSystems;

public class ClickController : MonoBehaviour, IPointerClickHandler
{
    // Скрипт обработки нажатия на блок
    public void OnPointerClick(PointerEventData eventData)
    {
        // Получение идентификатора нажатого блока
        int ID = int.Parse(gameObject.name.Substring(6));
        Parameters.clickedBlockId = ID;
  
        int[] neighbours = Algorithm.GetAllNeighboursID(ID, Parameters.GetGameMatrix());
        
        if (neighbours.Length > 2)
        {
            Parameters.score += neighbours.Length;
            AnimationManager.UpdateScore();            
            AnimationManager.EmptyBlocksAnimation(neighbours);

           Parameters.GetGameMatrix().UpdateMatrix(neighbours);     
        }
       

    }
}
