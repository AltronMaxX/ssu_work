double a,b;
Console.WriteLine("Катет 1 = ");
a = double.Parse(Console.ReadLine());

Console.WriteLine("Катет 2 = ");
b = double.Parse(Console.ReadLine());

Console.WriteLine("Периметр = {0:#0.00}", a + b + Math.Sqrt(a*a + b*b));