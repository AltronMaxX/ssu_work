int[] FindMinInColumns(int[,] matrix, int n)
{
    int[] minElements = new int[n];

    for (int i = 0; i < n; i++)
    {
        minElements[i] = int.MaxValue;
    }

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            minElements[i] = matrix[j, i] < minElements[i] ? matrix[j, i] : minElements[i];
        }
    }
    return minElements;
}


const int n = 3;
int[,] matrix = new int[n, n]
{
    { 1, 4, -10 },
    { 9, 5, 9 },
    { -8, 3, 14 }
};
int[] minElements = FindMinInColumns(matrix, n);

Console.WriteLine("Минимальные элементы в столбцах:");
for (int i = 0; i < n; i++)
{
    Console.WriteLine($"Столбец {i + 1}: {minElements[i]}");
}