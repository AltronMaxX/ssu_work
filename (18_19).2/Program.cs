using System.Xml.Serialization;

List<Function> functions;
XmlSerializer xmlSerializer = new(typeof(List<Function>));


if (!File.Exists("./data.xml")) 
{
    functions = new();
    using (StreamReader reader = new("./input.txt")) {
        while (!reader.EndOfStream) {
            string[] funcInfo = reader.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            switch (funcInfo[0]) {
                case "line":
                    functions.Add(new Line(float.Parse(funcInfo[1]), float.Parse(funcInfo[2])));
                    break;
                case "kub":
                    functions.Add(new Kub(float.Parse(funcInfo[1]), float.Parse(funcInfo[2]), float.Parse(funcInfo[3])));
                    break;
                case "hyperbola":
                    functions.Add(new Hyperbola(float.Parse(funcInfo[1]), float.Parse(funcInfo[2])));
                    break;
                default:
                    Console.WriteLine($"Unknown function {funcInfo[0]}!");
                    continue;
            }
        }
    }   
}
else 
{
    using (FileStream fileStream = new ("./data.xml", FileMode.OpenOrCreate, FileAccess.Read)) 
    {
        functions = (List<Function>)xmlSerializer.Deserialize(fileStream);
    }
}

Console.WriteLine("Введите x: ");
float x;
string line = Console.ReadLine();

while (!float.TryParse(line, out x)) {
    Console.WriteLine("Неверно введён x!");
    Console.WriteLine("Введите x: ");
    line = Console.ReadLine();
}

functions.Sort();

Console.WriteLine("Сортировка по a");

foreach (Function func in functions) {
    string msg = func.PrintInfo(x);
    Console.WriteLine(msg);
}


using (FileStream fileStream = new ("./data.xml", FileMode.OpenOrCreate, FileAccess.Write)) 
{
    xmlSerializer.Serialize(fileStream, functions);
}
