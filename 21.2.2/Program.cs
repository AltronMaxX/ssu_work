AVLTree tree = new();

using (StreamReader reader = new("./input.txt"))
{
    while (!reader.EndOfStream)
    {
        string[] numbers = reader.ReadLine().Split([',', '\n', '\t'], StringSplitOptions.RemoveEmptyEntries);
        foreach (var num in numbers)
        {
            if (int.TryParse(num, out int val))
            {
                tree.Add(val);
            }
        }
    }
}

int nodeToFind;
Console.WriteLine("Введите значение узла");
while (!int.TryParse(Console.ReadLine(), out nodeToFind))
{
    Console.WriteLine("Введите значение узла");
}

int height = tree.FindNodeHeight(nodeToFind);

Console.WriteLine("Высота заданного узла: " + height);

public class AVLTree
{
    private class Node
    {
        public int inf; // Информационное поле
        public int height; // Высота узла
        public Node? left;  // Левое поддерево
        public Node? rigth; // Правое поддерево

        public Node(int nodeInf)
        {
            inf = nodeInf;
            height = 1;
            left = null;
            rigth = null;
        }

        public int Height
        {
            get { return (this != null) ? this.height : 0; }
        }

        public void NewHeight()
        {
            int rh = (this.rigth != null) ? this.rigth.Height : 0;
            int lh = (this.left != null) ? this.left.Height : 0;
            this.height = ((rh > lh) ? rh : lh) + 1;
        }

        public static void Add(ref Node? r, int nodeInf)
        {
            if (r == null)
                r = new Node(nodeInf);
            else
            {
                if (((IComparable)r.inf).CompareTo(nodeInf) > 0)
                    Add(ref r.left, nodeInf);
                else
                    Add(ref r.rigth, nodeInf);
            }
            r.NewHeight();
        }

        public static int FindNodeHeight(ref Node? r, int nodeInf)
        {
            if (r == null) return -1;
            if (r.inf == nodeInf) return r.Height;
            if (((IComparable)r.inf).CompareTo(nodeInf) > 0)
                return FindNodeHeight(ref r.left, nodeInf);
            else
                return FindNodeHeight(ref r.rigth, nodeInf);
        }
    }

    private Node? tree;

    public AVLTree()
    {
        tree = null;
    }

    public void Add(int nodeInf)
    {
        Node.Add(ref tree, nodeInf);
    }

    public int FindNodeHeight(int nodeInf)
    {
        return Node.FindNodeHeight(ref tree, nodeInf);
    }
}
