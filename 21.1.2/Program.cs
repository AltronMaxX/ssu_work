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

int countevennumbers = tree.CountEvenNodes();

Console.WriteLine("Количество чётных чисел: " + countevennumbers);

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

        public int BalanceFactor
        {
            get
            {
                int rh = (this.rigth != null) ? this.rigth.Height : 0;
                int lh = (this.left != null) ? this.left.Height : 0;
                return rh - lh;
            }
        }

        public void NewHeight()
        {
            int rh = (this.rigth != null) ? this.rigth.Height : 0;
            int lh = (this.left != null) ? this.left.Height : 0;
            this.height = ((rh > lh) ? rh : lh) + 1;
        }

        public static void RotationRigth(ref Node t)
        {
            Node x = t.left;
            t.left = x.rigth;
            x.rigth = t;
            t.NewHeight();
            x.NewHeight();
            t = x;
        }
        public static void RotationLeft(ref Node t)
        {
            Node x = t.rigth;
            t.rigth = x.left;
            x.left = t;
            t.NewHeight();
            x.NewHeight();
            t = x;
        }

        public static void Rotation(ref Node t)
        {
            t.NewHeight();
            if (t.BalanceFactor == 2) //узел нужно повернуть влево, т.к. его правое поддерево перегружено
            {
                if (t.rigth.BalanceFactor < 0) //проверка условия выполнения большого поворота налево
                {
                    RotationRigth(ref t.rigth);
                }
                RotationLeft(ref t);
            }
            if (t.BalanceFactor == -2) //узел нужно повернуть вправо, т.к. его левое поддерево перегружено
            {
                if (t.left.BalanceFactor > 0) //проверка условия выполнения большого поворота направо
                {
                    RotationLeft(ref t.left);
                }
                RotationRigth(ref t);
            }
        }


        public static void Add(ref Node? r, int nodeInf)
        {
            if (r == null)
                r = new Node(nodeInf);
            else
            {
                if (((IComparable)(r.inf)).CompareTo(nodeInf) > 0)
                    Add(ref r.left, nodeInf);
                else
                    Add(ref r.rigth, nodeInf);
            }
            Rotation(ref r);
        }

        public static int CountEvenNodes(Node? node)
        {
            if (node == null) return 0;

            return node.inf % 2 + CountEvenNodes(node.rigth) + CountEvenNodes(node.left);
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

    public int CountEvenNodes()
    {
        return Node.CountEvenNodes(tree);
    }
}
