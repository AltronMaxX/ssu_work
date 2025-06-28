BinaryTree tree = new();

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

Console.WriteLine("Исходное дерево:");
tree.Print();

if (tree.IsPerfectlyBalanced())
{
    Console.WriteLine("Дерево уже идеально сбалансировано");
}
else
{
    Console.Write("Введите n: ");
    int n = int.Parse(Console.ReadLine());
    if (tree.TryBalanceTree(n))
    {
        Console.WriteLine("Итоговое дерево");
        tree.Print();
    }
}

public class BinaryTree
{
    private class Node
    {
        public int inf;
        public Node left;
        public Node right;
        public int counter;
        public int maxRange = 200;
        public int minRange = -200;

        public Node(int nodeInf)
        {
            inf = nodeInf;
            left = null;
            right = null;
            counter = 1;
        }

        public static void Add(ref Node r, int nodeInf, int minVal, int maxVal)
        {
            if (r == null)
            {
                r = new Node(nodeInf);
                r.minRange = minVal;
                r.maxRange = maxVal;
            }
            else
            {
                r.counter++;
                if (nodeInf < r.inf)
                {
                    Add(ref r.left, nodeInf, minVal, r.inf);
                }
                else
                {
                    Add(ref r.right, nodeInf, r.inf, maxVal);
                }
            }
        }

        public static void Inorder(Node r)
        {
            if (r != null)
            {
                Inorder(r.left);
                Console.Write($"{r.inf} ");
                Inorder(r.right);
            }
        }

        public static void InorderToList(Node r, List<object> list)
        {
            if (r != null)
            {
                InorderToList(r.left, list);
                list.Add(r.inf);
                InorderToList(r.right, list);
            }
        }
    }

    Node tree;
    private HashSet<int> existingValues = new HashSet<int>();
    private List<int> addedNodes = new List<int>();

    public BinaryTree()
    {
        tree = null;
    }

    public void Add(int nodeInf)
    {
        Node.Add(ref tree, nodeInf, int.MinValue, int.MaxValue);
    }

    public void Inorder()
    {
        Node.Inorder(tree);
    }

    public List<object> InorderToList()
    {
        var result = new List<object>();
        Node.InorderToList(tree, result);
        return result;
    }

    public void Print()
    {
        Print(tree, 0);
    }

    private void Print(Node node, int indent)
    {
        if (node == null) return;
        Print(node.right, indent + 4);
        Console.WriteLine(new string(' ', indent) + $"{node.inf}");
        Print(node.left, indent + 4);
    }

    public bool IsPerfectlyBalanced()
    {
        return CheckPerfectlyBalanced(tree);
    }

    private bool CheckPerfectlyBalanced(Node node)
    {
        if (node == null)
            return true;

        int lc = node.left != null ? node.left.counter : 0;
        int rc = node.right != null ? node.right.counter : 0;

        return Math.Abs(lc - rc) <= 1 &&
               CheckPerfectlyBalanced(node.left) &&
               CheckPerfectlyBalanced(node.right);
    }

    public bool TryBalanceTree(int maxAdditions)
    {
        addedNodes.Clear();
        int added = 0;

        while (!IsPerfectlyBalanced() && added < maxAdditions)
        {
            Node unbalancedNode = FindUnbalancedNode(tree);
            if (unbalancedNode == null) break;

            int lc = unbalancedNode.left != null ? unbalancedNode.left.counter : 0;
            int rc = unbalancedNode.right != null ? unbalancedNode.right.counter : 0;

            try
            {
                int valToAdd;
                if (lc > rc)
                {
                    valToAdd = FindValueToAdd(unbalancedNode, false);
                }
                else
                {
                    valToAdd = FindValueToAdd(unbalancedNode, true);
                }
                Add(valToAdd);
                addedNodes.Add(valToAdd);
                added++;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Невозможно сбалансировать дерево: невозможно найти подходящее значение");
                return false;
            }
        }

        if (IsPerfectlyBalanced())
        {
            Console.WriteLine($"Дерево сбалансировано с добавлением {added} узлов: {string.Join(", ", addedNodes)}");
            return true;
        }
        else
        {
            Console.WriteLine($"Невозможно сбалансировать дерево с добавлением не более {maxAdditions} узлов");
            return false;
        }
    }

    private Node FindUnbalancedNode(Node node)
    {
        if (node == null) return null;

        int lc = node.left != null ? node.left.counter : 0;
        int rc = node.right != null ? node.right.counter : 0;

        if (Math.Abs(lc - rc) > 1)
            return node;

        Node leftUnbalanced = FindUnbalancedNode(node.left);
        if (leftUnbalanced != null)
            return leftUnbalanced;

        return FindUnbalancedNode(node.right);
    }

    private int FindValueToAdd(Node node, bool toLeft)
    {
        int val;
        if (toLeft)
        {
            int maxVal = node.inf;
            int minVal = GetMinVal(node);
            val = maxVal - 1;
        }
        else
        {
            int minVal = node.inf;
            int maxVal = GetMaxVal(node);
            val = minVal + 1;
        }
        return val;
    }

    private int GetMinVal(Node node)
    {
        Node current = tree;
        while (current != null)
        {
            if (current == node)
                return -200;
            if (node.inf < current.inf)
            {
                if (current.left == node)
                    return current.inf;
                current = current.left;
            }
            else
            {
                current = current.right;
            }
        }
        return -200;
    }

    private int GetMaxVal(Node node)
    {
        Node current = tree;
        while (current != null)
        {
            if (current == node)
                return 200;
            if (node.inf > current.inf)
            {
                if (current.right == node)
                    return current.inf;
                current = current.right;
            }
            else
            {
                current = current.left;
            }
        }
        return 200;
    }
}
