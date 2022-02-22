using UnityEngine;
using UnityEngine.UI;

//GameObject ButtonRestart
//���������� ������ ������, ��������� ������, ����������� � �����������

public class InputManager : MonoBehaviour
{
    public InputField inputWidth;
    public InputField inputHeight;
    public InputField inputColorsNum;


    // ���������� ��� ������� �� ������ ������: �������� ������� ������ � ������������ �� ��������� 
    public void SetInputs()
    {
        int inputWidthValue = int.Parse(inputWidth.text);
        int inputHeightValue = int.Parse(inputHeight.text);
        int inputColorsValue = int.Parse(inputColorsNum.text);

        if (InputValidate(inputWidthValue, inputHeightValue, inputColorsValue))
        {
            Parameters.colsNum = inputWidthValue;
            Parameters.rowsNum = inputHeightValue;
            Parameters.colorsNum = inputColorsValue;
            Parameters.isRestarted = true;
        }
    }

    private bool InputValidate(int inputWidth, int inputHeight, int inputColors)
    {
        if (inputWidth >= 10 && inputWidth <= 50 &&
            inputHeight >= 10 && inputHeight <= 50 &&
            inputColors >= 3 && inputColors <= 5)
        {
            AnimationManager.ManageInvalidInputs(false);
            return true;
        }

        else
        {
            AnimationManager.ManageInvalidInputs(true);
            return false;
        }
    }
}


