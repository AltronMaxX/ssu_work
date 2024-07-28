

int main()
{
    Stack<char> stack = new Stack<char>();
    
    string s = Console.In.ReadLine();

    foreach (char c in s)
    {
        stack.Push(c);
    }

    for (int i = 0; i < s.Length; i++)
    {
        char c = s[i];
        if ((c == '(' && s[i + 1] == ')') 
            || (c == '[' && s[i+1] == ']') 
            || (c == '{' && s[i + 1] == '}') && s.Length > i+1)
        {
            stack.Pop();
        }
        else if (s.Length > i + 1 && (s[i - 1] == '(' && c == ')')
            || (s[i - 1] == '[' && c == ']')
            || (s[i - 1] == '{' && c == '}'))
        {
            stack.Pop();
        }
    }

    if (stack.Count == 0)
    {
        Console.WriteLine(true);
    }
    else
    {
        Console.WriteLine(false);
    }

    return 0;
}

main();