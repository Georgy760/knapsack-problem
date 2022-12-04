namespace BackpackTask;

public class BackPack_OLD
{
    public int[] weights = Array.Empty<int>();
    public int[] values = Array.Empty<int>();
    public int maxCapacity;
    
    public static int CountMax(int maxCapacity, int[] values, int[] weights) 
    {
        //строим массив и закладываем место на ячейки пустышки 
        //выходящие из левого верхнего угла
        int[,] arr = new int[weights.Length + 1, maxCapacity + 1];

        //проходим по всем вещам
        for (int i = 0; i <= weights.Length; i++)
        {
            //проходим по всем рюкзакам
            for (int j = 0; j <= maxCapacity; j++)
            {
                //попадаем в ячейку пустышку
                if (i == 0 || j == 0)
                {
                    arr[i, j] = 0;
                }
                else
                {   
                    //если вес текущей вещи больше размера рюкзака
                    //казалось бы откуда значение возьмется для первой вещи 
                    //при таком условии. А оно возьмется из ряда пустышки
                    if (weights[i - 1] > j)
                    {
                        arr[i, j] = arr[i - 1, j];
                    }
                    else
                    {
                        //здесь по формуле. Значение над текущей ячейкой
                        var prev = arr[i - 1, j];
                        //Значение по вертикали: ряд вверх
                        //и по горизонтали: вес рюкзака - вес текущей вещи
                        var byFormula = values[i - 1] + arr[i - 1, j - weights[i - 1]];
                        arr[i, j] = Math.Max(prev, byFormula);
                    }
                }
            }
        }

        // возвращаем правую нижнюю ячейку
        return arr[weights.Length, maxCapacity];
    }
}