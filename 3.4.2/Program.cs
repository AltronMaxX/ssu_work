int a, b;
Console.WriteLine("Введите A ");
a = int.Parse(Console.ReadLine());
Console.WriteLine("Введите B ");
b = int.Parse(Console.ReadLine());

for (int i = a % 2 == 0 ? a : a + 1; i <= b; i+=2) {
    Console.WriteLine(i*i);
}