void DeleteColumns(int[][] matrix)
{
    Transpose(matrix);
    int newColumnsCount = matrix.Length - matrix.Count(col => col.First() > col.Last());
    for (int i = 0; i < matrix.Length; i++)
    {
        if (matrix[i].First() > matrix[i].Last())
        {
            for (int j = matrix.Length - 1; j >= 0 && j != i; j--) {
                matrix[i] = matrix[j];
                matrix[j] = new int[matrix.Length];
            }
        }
    }

    Transpose(matrix);
    for (int i = 0; i < matrix.Length; i++) {
        Array.Resize(ref matrix[i], newColumnsCount);
    }
}

void Transpose(int[][] matrix)
{
    for (int i = 0; i < matrix.Length; i++)
    {
        for (int j = i + 1; j < matrix[i].Length; j++)
        {
            int temp = matrix[i][j];
            matrix[i][j] = matrix[j][i];
            matrix[j][i] = temp;
        }
    }
}

void PrintMatrix(int[][] matrix)
{
    for (int i = 0; i < matrix.Length; i++)
    {
        for (int j = 0; j < matrix[i].Length; j++)
        {
            Console.Write($"{matrix[i][j]} ");
        }
        Console.WriteLine();
    }
}

int[][] matrix = [
    [ 1, 1, 69, 19 ],
    [ 5, 6, 7, 8 ],
    [ 9, 10, 11, 12 ],
    [ 13, 3, 7, 16 ]
];

Console.WriteLine("Исходная матрица:");
PrintMatrix(matrix);

DeleteColumns(matrix);

Console.WriteLine("\nИзмененная матрица:");
PrintMatrix(matrix);