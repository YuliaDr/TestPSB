namespace TestPSB;

internal class MatchResults
{
    private static string[] _matchesArray = { "3:1", "2:2", "0:1", "4:2", "3:a", "3- 12" };


    // Метод проверки правильности строки с результатом матча.
    private static bool CheckMatch(string match)
    {
        var countColon = 0;

        for (int i = 0; i < match.Length; i++)
        {
            // Выделение i-го симола из строки.
            char c = match[i];


            // Проверка правильности первого и последнего символов (допустимые: 0-9).
            if ((i == 0 || i == match.Length - 1) && (c < 48 || c > 57))
            {
                return false;
            }

            // Проверка отсутствия неправильных символов (допустимые: 0-9, :).
            if (c < 48 || c > 58)
            {
                return false;
            }

            // Подсчет символа ":" в строке.
            if (c == 58)
            {
                countColon += 1;
            }
        }

        // Проверка на единичное вхождение символа ":" в строку.
        return countColon == 1;
    }

    // Метод получения числового счета из правильной строки результата матча.
    private static int[] GetIntScore(string match)
    {
        // Разбиение строки на массив по разделителю ":".
        string[] stringScoreArray = match.Split(':');

        // Преобразование элементов массива в целочисленный тип.
        int[] intScoreArray = Array.ConvertAll(stringScoreArray, int.Parse);

        return intScoreArray;
    }

    // Метод получения очков за матч в соответствии с счетом.
    private static int[] GetPoints(int[] score)
    {
        // Очки при победе первой команды.
        if (score[0] > score[1])
        {
            return new[] { 3, 0 };
        }

        // Очки при победе второй команды.
        if (score[0] < score[1])
        {
            return new[] { 0, 3 };
        }

        // Очки при ничьей.
        return new[] { 1, 1 };
    }

    // Метод вывода результатов на экран.
    private static void PrintMatchResult(int[] score, int[] points)
    {
        Console.WriteLine($"Команда №1 (хозяева) забила голов: {score[0]}.\n" +
                          $"Команда №2 (гости) забила голов: {score[1]}.\n" +
                          $"Очки по итогу матча:\n" +
                          $"Команда №1: {points[0]}.\n" +
                          $"Команда №2: {points[1]}.\n");
    }

    // Точка входа в программу
    public static void Main()
    {
        foreach (string match in _matchesArray)
        {
            Console.WriteLine($"Счет: {match}");
            
            if (CheckMatch(match))
            {
                int[] score = GetIntScore(match);
                int[] points = GetPoints(score);
                
                PrintMatchResult(score, points);
            }
            else
            {
                Console.WriteLine("Неверно введены данные.\n");
            }
        }
    }
}
