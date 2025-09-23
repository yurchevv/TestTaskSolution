namespace TwoDimensionalArrayTrace;
public class PathHelper
{
    /// <summary>
    /// Метод для подсчета всех возможных путей в двумерном массиве размерности n * m
    /// </summary>
    /// <param name="m"> Первая размерность массива </param>
    /// <param name="n"> Вторая размерность массива </param>
    /// <returns> Количество возможных путей в двумерном массиве </returns>
    public static int GetPathCount(int m, int n)
    {
        /*
            Для вычисления количества возможных путей в двумерном массиве
            есть возможность использовать формулу из комбинаторики вида:
            ((m - 1) + (n - 1))!
            --------------------
            (m - 1)! * (n - 1)!
            При этом зная, что в случае, если одна из размерностей равна единице,
            следовательно и количество возможных путей обхода так же равно единице
            Так же следует заметить, что при подсчете факториала в переменную типа long
            не получится поместить значение, большее, чем факториал 20
        */

        if (m == 1 || n == 1)
        {
            return 1;
        }

        if (m <= 0 || n <= 0)
        {
            throw new ArgumentOutOfRangeException("Размерность не может быть отрицательной или равной нулю");
        }

        if (m + n > 20)
        {
            throw new ArgumentOutOfRangeException("Сумма размерностей превышает допустимое значение");
        }

        var numerator = Factorial((m - 1) + (n - 1));
        var denominator = Factorial(m - 1) * Factorial(n - 1);

        return (int)(numerator / denominator);
    }

    /// <summary>
    /// Рекурсивный метод для подсчета всех возможных путей в двумерном массиве размерности n * m
    /// </summary>
    /// <param name="firstIndexStartingPosition"> Стартовая позиция подсчета первой размерности массива </param>
    /// <param name="secondIndexStartingPosition"> Стартовая позиция подсчета второй размерности массива </param>
    /// <param name="m"> Первая размерность массива </param>
    /// <param name="n"> Вторая размерность массива </param>
    /// <returns> Количество возможных путей в двумерном массиве </returns>
    public static int GetPathCountRecursively(int firstIndexStartingPosition, int secondIndexStartingPosition, int n, int m)
    {
        if (m <= 0 || n <= 0)
        {
            throw new ArgumentOutOfRangeException("Размерность не может быть отрицательной или равной нулю");
        }

        if (firstIndexStartingPosition < 0 || secondIndexStartingPosition < 0)
        {
            throw new ArgumentOutOfRangeException("Стартовая позиция не может быть отрицательной");
        }

        if (m == 1 || n == 1)
        {
            return 1;
        }

        // Если мы дошли либо до последнего индекса n размерности (прижались к границе массива сбоку)
        // или если мы дошли до последнего интекса m размерности (прижались к границе массива снизу)
        // по сути существует только 1 возможный путь до последней ячейки массива (возвращаем единицу)
        if (firstIndexStartingPosition == n - 1 || secondIndexStartingPosition == m - 1)
        {
            return 1;
        }

        // Для каждого сдвига смотрим его пути вправо и его пути вниз на одну ячейку
        return GetPathCountRecursively(firstIndexStartingPosition + 1, secondIndexStartingPosition, n, m)
        + GetPathCountRecursively(firstIndexStartingPosition, secondIndexStartingPosition + 1, n, m);
    }

    /// <summary>
    /// Метод для вычисления факториала числа
    /// </summary>
    /// <param name="number"> Текущее состояние подсчета факториала числа или сам вычисленный факториал </param>
    /// <returns> Текущее значение состояния подсчета или вычисленный факториал числа </returns>
    public static long Factorial(long number)
    {
        if (number == 1 || number == 0)
        {
            return 1;
        }

        return number * Factorial(number - 1);
    }
}