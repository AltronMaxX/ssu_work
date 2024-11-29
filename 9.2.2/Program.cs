using (StreamReader reader = new StreamReader("./f.txt"))
using (StreamWriter writeG = new StreamWriter("./g.txt"))
using (StreamWriter writeH = new StreamWriter("./h.txt")) {
    while (!reader.EndOfStream) {
        string line = reader.ReadLine();

        foreach (string strnum in line.Split(',', StringSplitOptions.RemoveEmptyEntries)) {
            int num = int.Parse(strnum);
            if (num < 0) {
                writeG.WriteLine(num);
            } else {
                writeH.WriteLine(num);
            }
        }
    }
}