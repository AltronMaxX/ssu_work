Console.WriteLine("1 Задание\n");
int a,b;
Console.WriteLine("a= ");
a = int.Parse(Console.ReadLine());

Console.WriteLine("b= ");
b = int.Parse(Console.ReadLine());

Console.WriteLine("{0}+{1}={2}", a, b, a+b);

Console.WriteLine("\n2 Задание\n");

Console.WriteLine("{0}+{1}={1}+{0}", a, b);

Console.WriteLine("\n5 Задание\n");

double c,d;
Console.WriteLine("c= ");
c = double.Parse(Console.ReadLine());

Console.WriteLine("d= ");
d = double.Parse(Console.ReadLine());

Console.WriteLine("{0}/{1}={2:#0.###}", c, d, c/d);

Console.WriteLine("\n7 Задание\n");

int e,f;
Console.WriteLine("Номинал купюры = ");
e = int.Parse(Console.ReadLine());
Console.WriteLine("Количество купюр = ");
f = int.Parse(Console.ReadLine());

Console.WriteLine("Сумма денег = {0:#0.00}р", e*f);

Console.WriteLine("\n9 Задание\n");

double sum, per;
Console.WriteLine("Сумма вклада = ");
sum = double.Parse(Console.ReadLine());

Console.WriteLine("Процент вклада = ");
per = double.Parse(Console.ReadLine());

Console.WriteLine("Через год сумма на вкладе = {0:#0.00}р", sum + (sum * (per/100)));