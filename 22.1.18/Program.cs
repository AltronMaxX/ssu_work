Graph g=new Graph("./matrix.txt"); //Пример из методички :)
Console.WriteLine("Исходный граф:");
g.Show();
Console.WriteLine();

Console.WriteLine("Введите вес каждого ребра для новой точки в формате A, B, C....");

string line = Console.ReadLine();
List<int> weights = new();
foreach (var str in line.Split(',', StringSplitOptions.RemoveEmptyEntries))
{
    int weight = int.Parse(str);
    weights.Add(weight);
}

g.AddNewPoint(weights.ToArray());
Console.WriteLine("Новый граф:");
g.Show();

public class Graph
{
    private class Node //вложенный класс для скрытия данных и алгоритмов
    {
        private int[,] array; //матрица смежности
        public int this[int i, int j] //индексатор для обращения к матрице смежности
        {
            get
            {
                return array[i, j];
            }
            set
            {
                array[i, j] = value;
            }
        }
        public int Size //свойство для получения размерности матрицы смежности
        {
            get
            {
                return array.GetLength(0);
            }
        }
        private bool[] nov; //вспомогательный массив: если i-ый элемент массива равен
                            //true, то i-ая вершина еще не просмотрена; если i-ый
                            //элемент равен false, то i-ая вершина просмотрена
        public void NovSet() //метод помечает все вершины графа как непросмотреные
        {
            for (int i = 0; i < Size; i++)
            {
                nov[i] = true;
            }
        }
        //конструктор вложенного класса, инициализирует матрицу смежности и
        // вспомогательный массив
        public Node(int[,] a)
        {
            array = a;
            nov = new bool[a.GetLength(0)];
        }

        public void AddNewPoint(int[] weights)
        {
            ResizeGraph(array.GetLength(0) + 1);
            int len = array.GetLength(0);
            for (int i = 0; i < len - 1; i++)
            {
                int numToPaste = 0;
                if (weights.Length > i)
                {
                    numToPaste = weights[i];
                }
                array[i, len - 1] = numToPaste;
            }
            for (int j = 0; j < len - 1; j++)
            {
                int numToPaste = 0;
                if (weights.Length > j)
                {
                    numToPaste = weights[j];
                }
                array[len - 1, j] = numToPaste;
            }
        }
        private void ResizeGraph(int newLen)
        {
            int[,] new_g = new int[newLen, newLen];
            int oldLen = array.GetLength(0);
            for (int i = 0; i < oldLen; i++)
            {
                for (int j = 0; j < oldLen; j++)
                {
                    new_g[i, j] = array[i, j];
                }
            }
            array = new_g;
        }
    } //конец вложенного клаcса
    private Node graph; //закрытое поле, реализующее АТД «граф»
    public Graph(string name) //конструктор внешнего класса
    {
        using (StreamReader file = new StreamReader(name))
        {
            int n = int.Parse(file.ReadLine());
            int[,] a = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                string line = file.ReadLine();
                string[] mas = line.Split(' ');
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = int.Parse(mas[j]);
                }
            }
            graph = new Node(a);
        }
    }
    //метод выводит матрицу смежности на консольное окно
    public void Show()
    {
        for (int i = 0; i < graph.Size; i++)
        {
            for (int j = 0; j < graph.Size; j++)
            {
                Console.Write("{0,4}", graph[i, j]);
            }
            Console.WriteLine();
        }
    }

    public void AddNewPoint(int[] weights)
    {
        graph.AddNewPoint(weights);
    }
}