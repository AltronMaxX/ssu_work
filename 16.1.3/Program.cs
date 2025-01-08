int a, b;
List<int> numbers = new List<int>();

using (StreamReader reader = new StreamReader("./numbers.txt")) {
    string[] abline = reader.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);

    a = int.Parse(abline[0]);
    b = int.Parse(abline[1]);
    
    while (!reader.EndOfStream) {
        string line = reader.ReadLine();
        foreach (string strnum in line.Split(',', StringSplitOptions.RemoveEmptyEntries)) {
            numbers.Add(int.Parse(strnum));
        }
    }
}

var numbersInSection = numbers.Where(n => n >= a && n <= b).Order();

using (StreamWriter writer = new StreamWriter("./output.txt")) {
    foreach(int num in numbersInSection) {
        writer.WriteLine(num);
    }   
}