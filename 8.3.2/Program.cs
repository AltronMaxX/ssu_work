string a;
a = Console.ReadLine();

uint n = 0;
n = uint.Parse(Console.ReadLine());

string[] words = a.Split(new char[] { ' ', ',', '.', '!', '?', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

foreach (string word in words) {
    if (word.Length <= n) {
        Console.WriteLine(word);
    }
}