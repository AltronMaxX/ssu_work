uint findSum(uint i, uint n) {
    if (i == n) return i;
    return i + findSum(i+1, n);
}

uint m = uint.Parse(Console.ReadLine());
uint k = uint.Parse(Console.ReadLine());

uint summ1 = findSum(1, m);
uint summ2 = findSum(1, 2 * k);

Console.WriteLine("{0} + {1} = {2}", summ1, summ2, summ1 + summ2);