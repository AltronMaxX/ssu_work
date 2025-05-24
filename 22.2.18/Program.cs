using System.Collections;

Graph g=new Graph("./matrix.txt"); //Пример из методички :)
Console.WriteLine("Исходный граф:");
g.Show();
Console.WriteLine();

Console.WriteLine($"Введите вершину a и значение n в формате (A, N)");
string line = Console.ReadLine();
int[] ints = line.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(i => Convert.ToInt32(i)).ToArray();

g.ShowNotInNPeriphery(ints[0], ints[1]);

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

        public void ShowNotInNPeriphery(int a, int n)
        {
            NovSet();
            int[] p;
            long[] d = Dijkstr(a, out p);
            List<int> toShow = new();
            for (int i = 0; i < Size; i++)
            {
                if (i != a)
                {
                    if (d[i] != int.MaxValue)
                    {
                        Stack items = new Stack();
                        WayDijkstr(a, i, p, ref items);
                        if (d[i] <= n)
                        {
                            toShow.Add(i);
                        }
                    }
                }
            }

            Console.WriteLine($"Вершины графа, не попадающие в N-перифирию {a}:");
            foreach (int i in toShow)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        public long[] Dijkstr(int v, out int[] p)
        {
            nov[v] = false; // помечаем вершину v как просмотренную
                            //создаем матрицу с
            int[,] c = new int[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int u = 0; u < Size; u++)
                {
                    if (array[i, u] == 0 || i == u)
                    {
                        c[i, u] = int.MaxValue;
                    }
                    else
                    {
                        c[i, u] = array[i, u];
                    }
                }
            }
            //создаем матрицы d и p
            long[] d = new long[Size];
            p = new int[Size];
            for (int u = 0; u < Size; u++)
            {
                if (u != v)
                {
                    d[u] = c[v, u];
                    p[u] = v;
                }
            }
            for (int i = 0; i < Size - 1; i++) // на каждом шаге цикла
            {
                // выбираем из множества V\S такую вершину w, что D[w] минимально
                long min = int.MaxValue;
                int w = 0;
                for (int u = 0; u < Size; u++)
                {
                    if (nov[u] && min > d[u])
                    {
                        min = d[u];
                        w = u;
                    }
                }
                nov[w] = false; //помещаем w в множество S
                                //для каждой вершины из множества V\S определяем кратчайший путь от
                                // источника до этой вершины
                for (int u = 0; u < Size; u++)
                {
                    long distance = d[w] + c[w, u];
                    if (nov[u] && d[u] > distance)
                    {
                        d[u] = distance;
                        p[u] = w;
                    }
                }
            }
            return d; //в качестве результата возвращаем массив кратчайших путей для
        } //заданного источника
          //восстановление пути от вершины a до вершины b для алгоритма Дейкстры
        public void WayDijkstr(int a, int b, int[] p, ref Stack items)
        {
            items.Push(b); //помещаем вершину b в стек
            if (a == p[b]) //если предыдущей для вершины b является вершина а, то
            {
                items.Push(a); //помещаем а в стек и завершаем восстановление пути
            }
            else //иначе метод рекурсивно вызывает сам себя для поиска пути
            { //от вершины а до вершины, предшествующей вершине b
                WayDijkstr(a, p[b], p, ref items);
            }
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

    public void ShowNotInNPeriphery(int a, int n)
    {
        graph.ShowNotInNPeriphery(a, n);
    }
}