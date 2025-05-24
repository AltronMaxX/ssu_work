using System.Collections;
using System.Numerics;
using System.Text;



Graph g;
using (StreamReader file = new StreamReader("./input.txt"))
{
    int n = int.Parse(file.ReadLine());
    List<City> cities = new();
    for (int i = 0; i < n; i++)
    {
        string[] city = file.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        cities.Add(new City(city[0], int.Parse(city[1]), int.Parse(city[2])));
    }
    int[,] a = new int[n, n];
    for (int i = 0; i < n; i++)
    {
        string l = file.ReadLine();
        string[] mas = l.Split(' ');
        for (int j = 0; j < n; j++)
        {
            a[i, j] = int.Parse(mas[j]) == 1 ? Convert.ToInt32(cities[i].GetDistanceToCity(cities[j])) : 0;
        }
    }
    g = new Graph(a, cities.ToArray()); 
}

Console.WriteLine("Исходный граф:");
g.Show();
Console.WriteLine();

Console.WriteLine("Введите название первого города");
string city_a = Console.ReadLine();

Console.WriteLine("Введите название второго города");
string city_b = Console.ReadLine();

Console.WriteLine("Введите название городов для игнорирования");
string[] ignore = Console.ReadLine().Split([",", " "], StringSplitOptions.RemoveEmptyEntries);

g.FindShortestWay(city_a, city_b, ignore);

public struct City
{
    public string Name;
    public Vector2 Pos;

    public City(string Name, int x, int y)
    {
        this.Name = Name;
        this.Pos = new(x, y);
    }

    public double GetDistanceToCity(City other)
    {
        double a = other.Pos.X - Pos.X;
        double b = other.Pos.Y - Pos.Y;
        return Math.Sqrt(a * a + b * b);
    }
}

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
        private City[] cities;
        public Node(int[,] a, ref City[] cities)
        {
            array = a;
            nov = new bool[a.GetLength(0)];
            this.cities = cities;
        }

        public void FindShortestWay(int a, int b, int[] ignore)
        {
            NovSet();
            int[] p;
            long[] d = Dijkstr(a, ignore, out p);
            Console.WriteLine("Длина кратчайшие пути от города {0} до города {1}", cities[a].Name, cities[b].Name);
            double sum = 0;
            StringBuilder way = new();
            if (d[b] != int.MaxValue)
            {
                Stack items = new Stack();
                WayDijkstr(a, b, p, ref items);
                City prev = cities[a];
                while (items.Count != 0)
                {
                    int item = (int)items.Pop();
                    sum += prev.GetDistanceToCity(cities[item]);
                    way.Append($"{cities[item].Name} ");
                    prev = cities[item];
                }
            }
            Console.Write("равна {0}, ", sum);
            Console.Write($"путь {way.ToString()}");

            Console.WriteLine();
        }

        public long[] Dijkstr(int v, int[] ignore, out int[] p)
        {
            nov[v] = false; // помечаем вершину v как просмотренную
            foreach (var i in ignore) // помечаем игнорируемые вершины как пройденные
            {
                nov[i] = false;
            }
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
    private City[] cities;
    public Graph(int[,] a, City[] cities) //конструктор внешнего класса
    {
        graph = new Node(a, ref cities);
        this.cities = cities;
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

    public void FindShortestWay(string a, string b, string[] ignore)
    {
        int city_a = FindCityIdByName(a);
        int city_b = FindCityIdByName(b);
        int[] ign = ignore.Select(city => FindCityIdByName(city)).ToArray();
        graph.FindShortestWay(city_a, city_b, ign);
    }

    private int FindCityIdByName(string name)
    {
        int index = Array.FindIndex(cities, 0, cities.Count(), city => city.Name == name);
        if (index != -1)
            return index;
        throw new Exception($"Города с таким названием ({name}) не существует!");
    }
}