// Статический класс для удобства доступа к параметрам игры 
public static class Parameters 
{
    //Параметры игрового поля
    public static readonly int maxWidth = 1200;
    public static readonly int maxHeight = 900;
    public static int colorScheme;

    //Параметры матрицы
    public static int rowsNum = 10;
    public static int colsNum = 16;
    public static int colorsNum = 3;

    //Флаги и идентификаторы    
    public static bool isRestarted = true;
    public static bool isMatrixUpdated = false;
    public static int clickedBlockId;

    //Различные статичные значения
    public static int score = 0;

    //Метод, управляющий (пере)созданием матриц    
    private static Matrix gameMatrix;   
    public static Matrix GetGameMatrix()
    {
        if (isRestarted == true)
        {
            gameMatrix = new Matrix();
            isRestarted = false;
        }
        return gameMatrix;
    }
    public static bool IsInRange(int col, int row)
    {
        if (col < 0 || col >= Parameters.colsNum || row < 0 || row >= Parameters.rowsNum) return false;
        else return true;
    }
}
