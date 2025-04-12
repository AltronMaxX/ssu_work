using System.Text;

List<int> list = new();

using (StreamReader reader = new("./input.txt"))
{
    while (!reader.EndOfStream)
    {
        string[] numbers = reader.ReadLine().Split([',', '\n', '\t'], StringSplitOptions.RemoveEmptyEntries);
        foreach (var num in numbers)
        {
            if (int.TryParse(num, out int val))
            {
                list.AddEnd(val);
            }
        }
    }
}

Console.WriteLine("Введите x: ");
int x;
string line = Console.ReadLine();
while (!int.TryParse(line, out x))
{
    Console.WriteLine("Неверно введён x!");
    Console.WriteLine("Введите x: ");
    line = Console.ReadLine();
}

using (StreamWriter streamWriter = new("./output.txt"))
{
    Console.WriteLine(list);
    streamWriter.WriteLine(list.ToString());
    streamWriter.WriteLine("");
    list.ReplaceRepeats(x);
    Console.WriteLine(list);
    streamWriter.WriteLine(list.ToString());
}

public class List<T>
{
    class Node<T>
    {
        public T Inf;
        public Node<T> Next;
        public Node(T nodeInfo)
        {
            Inf = nodeInfo;
            Next = null;
        }
    }

    private Node<T> head;
    private Node<T> tail;

    public List()
    {
        head = null;
        tail = null;
    }

    public void AddEnd(T nodeInfo)
    {
        Node<T> r = new Node<T>(nodeInfo);
        if (head == null)
        {
            head = r;
            tail = r;
        }
        else
        {
            tail.Next = r;
            tail = r;
        }
    }

    public T TakeBegin()
    {
        if (head == null)
        {
            throw new Exception("Список пуст");
        }
        else
        {
            Node<T> r = head;
            head = head.Next;
            if (head == null)
            {
                tail = null;
            }
            return r.Inf;
        }
    }

    public T TakeEnd()
    {
        if (head == null)
        {
            throw new Exception("Список пуст");
        }
        else
        {
            Node<T> r = head;
            if (head.Next == null)
            {
                head = null;
                tail = null;
            }
            else
            {
                while (r.Next != tail)
                {
                    r = r.Next;
                }
                Node<T> temp = tail;
                tail = r;
                r = temp;
                tail.Next = null;
            }
            return r.Inf;
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new();
        Node<T> r = head;
        while (r != null)
        {
            stringBuilder.Append($"{r.Inf} ");
            r = r.Next;
        }
        return stringBuilder.ToString();
    }

    public void ReplaceRepeats(T x)
    {
        Node<T> prevNode = null;
        Node<T> curNode = head;
        while (curNode != null && curNode.Next != null)
        {
            if (((IComparable)curNode.Inf).CompareTo(curNode.Next.Inf) == 0)
            {
                T duplicateValue = curNode.Inf;
                Node<T> lastNode = curNode.Next;
                while (lastNode != null && ((IComparable)lastNode.Inf).CompareTo(duplicateValue) == 0)
                {
                    lastNode = lastNode.Next;
                }
                Node<T> newNode = new(x);
                newNode.Next = lastNode;
                if (prevNode == null)
                {
                    head = newNode;
                }
                else
                {
                    prevNode.Next = newNode;
                }

                if (lastNode == tail)
                {
                    tail = newNode;
                }
                curNode = newNode;
            }
            else
            {
                prevNode = curNode;
                curNode = curNode.Next;
            }
        }
    }
}
