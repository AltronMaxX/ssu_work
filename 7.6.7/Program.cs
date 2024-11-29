int[][] DeleteColumns(int[][] matrix, int n)
{
    bool[] needToRemove = new bool[n];

    for (int i = 0; i < n; i++)
    {
        needToRemove[i] = matrix[0][i] > matrix[n - 1][i] ? true : false;
    }

    if (needToRemove.All(bol => bol)) return [[]];

    int[][] ret = new int[n][];
    int newRowsCount = needToRemove.Count(bol => !bol);
    for (int i = 0; i < n; i++) {
        ret[i] = new int[newRowsCount];
    }

    for (int i = 0; i < n; i++) {
        int colCount = 0;
        for (int j = 0; j < n; j++) {  
            if (needToRemove[j]) 
                continue;  
            ret[i][colCount] = matrix[i][j];
            colCount++;   
        }   
    }

    return ret;
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

const int n = 4;

int[][] matrix = [
    [ 1, 11, 6, 19 ],
    [ 5, 6, 7, 8 ],
    [ 9, 10, 11, 12 ],
    [ 13, 3, 7, 16 ]
];

Console.WriteLine("Исходная матрица:");
PrintMatrix(matrix);

matrix = DeleteColumns(matrix, n);

Console.WriteLine("\nИзмененная матрица:");
PrintMatrix(matrix);