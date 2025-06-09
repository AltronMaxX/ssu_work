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

Console.Write("Введите n: ");
int n = int.Parse(Console.ReadLine());

if (tree.IsPerfectlyBalanced())
{
    Console.WriteLine("Дерево уже идеально сбалансировано");
}
else
{
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
        public object inf;
        public Node left;
        public Node right;
        public int counter;

        public Node(object nodeInf)
        {
            inf = nodeInf;
            left = null;
            right = null;
        }

        public static void Add(ref Node r, object nodeInf)
        {
            if (r == null)
            {
                r = new Node(nodeInf);
            }
            else
            {
                r.counter++;
                if (((IComparable)r.inf).CompareTo(nodeInf) > 0)
                    Add(ref r.left, nodeInf);
                else
                    Add(ref r.right, nodeInf);
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
    private List<int> addedNodes = new();

    public BinaryTree()
    {
        tree = null;
    }

    public void Add(object nodeInf)
    {
        Node.Add(ref tree, nodeInf);
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

        var leftBalanced = CheckPerfectlyBalanced(node.left);
        var rightBalanced = CheckPerfectlyBalanced(node.right);
        int lc = node.left != null ? node.left.counter : 0;
        int rc = node.right != null ? node.right.counter : 0;

        bool currentBalanced = leftBalanced && rightBalanced && Math.Abs(lc - rc) <= 1;

        return currentBalanced;
    }

    public bool TryBalanceTree(int maxAdditions)
    {
        addedNodes.Clear();

        while (!IsPerfectlyBalanced())
        {
            var badNodes = GetUnbalancedNodes();
            if (badNodes.Count == 0)
                break;

            foreach (var node in badNodes)
            {
                int left = node.left != null ? node.left.counter : 0;
                int right = node.right != null ? node.right.counter : 0;

                if (Math.Abs(left - right) <= 1) continue;
                if (maxAdditions <= 0) return false;

                int direction = left < right ? -1 : 1;
                int newVal = GenerateNewValueNear((int)node.inf, direction);
                Add(newVal);
                addedNodes.Add(newVal);
                maxAdditions--;

                if (IsPerfectlyBalanced())
                {
                    Console.WriteLine("Успешно сбалансировано:");
                    Console.WriteLine(string.Join(", ", addedNodes));
                    return true;
                }
            }
        }

        if (IsPerfectlyBalanced())
        {
            Console.WriteLine("Успешно сбалансировано:");
            Console.WriteLine(string.Join(", ", addedNodes));
            return true;
        }

        Console.WriteLine("Не удалось сбалансировать дерево с указанным числом вставок.");
        return false;
    }

    private int GenerateNewValueNear(int baseVal, int direction)
    {
        int candidate = baseVal + direction;
        var existing = InorderToList().Select(x => (int)x).ToHashSet();
        while (existing.Contains(candidate))
            candidate += direction;
        return candidate;
    }

    private List<Node> GetUnbalancedNodes()
    {
        var result = new List<Node>();
        GetUnbalancedNodesRecursive(tree, ref result);
        return result;
    }

    private void GetUnbalancedNodesRecursive(Node node, ref List<Node> unbalanced)
    {
        if (node == null) return;

        GetUnbalancedNodesRecursive(node.left, ref unbalanced);
        GetUnbalancedNodesRecursive(node.right, ref unbalanced);

        if (!CheckPerfectlyBalanced(node))
        {
            unbalanced.Add(node);
        }

        return;
    }
}
