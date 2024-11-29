void printDel(uint i, uint n) {
    if (n % i == 0) {
        if (i * i == n) {
            Console.WriteLine("{0} ", i);
        } else {
            Console.WriteLine("{0} {1}", i, n/i);
        }
    }
    if (i * i <= n - 1) printDel(i+1, n);
}

uint n = uint.Parse(Console.ReadLine());

printDel(1, n);