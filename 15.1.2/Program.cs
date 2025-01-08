List<int> numbers = new List<int>();

using (StreamReader reader = new StreamReader("./numbers.txt")) {
    while (!reader.EndOfStream) {
        string line = reader.ReadLine();
        foreach(string strnum in line.Split(",", StringSplitOptions.RemoveEmptyEntries)) {
            numbers.Add(int.Parse(strnum));
        }
    }
}

var negNumbers = from n in numbers where n < 0 orderby n select n;

using (StreamWriter writer = new StreamWriter("./negNumbers.txt")) {
    foreach (int num in negNumbers) {
        writer.WriteLine(num);
    }
}