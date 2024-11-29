uint findNod(uint a, uint b) {
    while (a>0 && b>0)
    {
        if (a>b)
            a%=b;
        else
            b%=a;
    }
    return a+b;
}

uint a = uint.Parse(Console.ReadLine());
uint b = uint.Parse(Console.ReadLine());

uint nodAB = findNod(a, b);

Console.WriteLine("Задание a");
Console.WriteLine("{0}/{1}={2}/{3}", a, b, a/nodAB, b/nodAB);

Console.WriteLine("Задание b");
Console.WriteLine("НОК: {0}/{1}={2}", a, b, a*b / nodAB);

Console.WriteLine("Задание c");
uint d = uint.Parse(Console.ReadLine());
uint c = uint.Parse(Console.ReadLine());

uint chisl = (a*c) + (d*b);
uint znam = c*b;

uint drobNod = findNod(chisl, znam);

Console.WriteLine("{0}/{1}+{2}/{3}={4}/{5}", a, b, d, c, chisl/drobNod, znam/drobNod);

Console.WriteLine("Задание d");

List<uint> numbers = new List<uint>();
uint number;

do
{
    number = uint.Parse(Console.ReadLine());
    if (number != 0)
    {
        numbers.Add(number);
    }
} while (number != 0);

uint result = numbers[0];
for (int i = 1; i < numbers.Count; i++)
{
    result = findNod(result, numbers[i]);
}

Console.WriteLine("НОД: {0}", result);