List<Triangle> triangles = new List<Triangle>();

using (StreamReader reader = new StreamReader("./triangles.txt")) {
    while (!reader.EndOfStream) {
        string line = reader.ReadLine();
        string[] sides = line.Split(';', StringSplitOptions.RemoveEmptyEntries);
        triangles.Add(new Triangle(int.Parse(sides[0]), int.Parse(sides[1]), int.Parse(sides[2])));
    }
}

triangles.Add(new Triangle());

Triangle copy = new Triangle(triangles.Last());
triangles.Add(copy);
Console.WriteLine(copy);

Triangle zero = new Triangle();
zero *= 4;

Console.WriteLine(zero);
triangles.Add(zero);

var first = triangles.First();
Console.WriteLine(first);
first++;
Console.WriteLine(first++);
Console.WriteLine(first);

Console.WriteLine(copy);
Triangle copy2 = new Triangle(copy);
copy2.SetScale(2);
Console.WriteLine(copy2);
triangles.Add(copy2);

foreach(var triangle in triangles) {
    Console.WriteLine(triangle);
    Console.WriteLine(triangle.GetHashCode());
    if (triangle) {
        Console.WriteLine("Треугольник существует");
    } else {
        Console.WriteLine("Треугольник не существует");
    }
}

for (int i = 0; i < triangles.Count - 1; i++) {
    var trig1 = triangles[i];
    for (int j = 0; j < triangles.Count; j++) {
        if (j == i) continue;
        var trig2 = triangles[j];
        if (trig1.Equals(trig2)) {
            Console.WriteLine($"Треугольники \n{trig1}\n{trig2}\n равны");
        } else {
            Console.WriteLine($"Треугольники \n{trig1}\n{trig2}\n не равны");
        }
    }
}

class Triangle {
    private int a;
    private int b;
    private int c;

    public Triangle() {
        a = 1;
        b = 1;
        c = 1;
    }

    public Triangle(int a, int b, int c) {
        if (a <= 0 || b <= 0 || c <= 0 || a + b <= c || a + c <= b || b + c <= a)
            throw new Exception($"Треугольник ({a}|{b}|{c}) не существует");

        this.a = a;
        this.b = b;
        this.c = c;
    }

    public Triangle(Triangle other) {
        a = other.a;
        b = other.b;
        c = other.c;
    }

    public int GetPerimeter() {
        return a + b + c;
    }

    public double GetSquare() {
        int p = GetPerimeter() / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public void SetScale(int s) {
        a *= s;
        b *= s;
        c *= s;
    }

    public override string ToString()
    {
        return $"{a}|{b}|{c}|{GetPerimeter()}|{GetSquare()}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Triangle) {
            Triangle triangle = (Triangle) obj;
            List<int> trig1 = new List<int>();
            List<int> trig2 = new List<int>();
    
            trig1.Add(a);
            trig1.Add(b);
            trig1.Add(c);

            trig2.Add(triangle.a);
            trig2.Add(triangle.b);
            trig2.Add(triangle.c);

            trig1.Sort();
            trig2.Sort();

            return trig1[0] == trig2[0] && trig1[1] == trig2[1] && trig1[2] == trig2[2];
        }
        throw new Exception($"Невозможно сравнить {obj.GetType()} с {this.GetType()}");
    }

    public override int GetHashCode()
    {
        return a.GetHashCode() ^ b.GetHashCode() ^ c.GetHashCode();
    }

    public int A
    {
        get{
            return a;
        } 
        set{
            if (value <= 0 || value + b <= c || value + c <= b || b + c <= value)
                throw new Exception("Установка недопустимого значения A");
            a = value;
        }
    }

    public int B
    {
        get{
            return b;
        } 
        set{
            if (value <= 0 || a + value <= c || a + c <= value || value + c <= a)
                throw new Exception("Установка недопустимого значения B");
            b = value;
        }
    }

    public int C
    {
        get{
            return c;
        } 
        set{
            if (value <= 0 || a + b <= value || a + value <= b || b + value <= a)
                throw new Exception("Установка недопустимого значения C");
            c = value;
        }
    }

    private bool IsExists() {
        return a + b > c && a + c > b && b + c > a;
    }

    public int this[int i] {
        get{
            switch(i) {
                case 0:
                    return a;
                case 1:
                    return b;
                case 2:
                    return c;
                default:
                    throw new Exception("Обращение по недопустимому индексу!");
            }
        }
        set {
            switch(i) {
                case 0:
                    if (value <= 0 || value + b <= c || value + c <= b || b + c <= value)
                        throw new Exception("Установка недопустимого значения A");
                    a = value;
                    break;
                case 1:
                    if (value <= 0 || a + value <= c || a + c <= value || value + c <= a)
                        throw new Exception("Установка недопустимого значения B");
                    b = value;
                    break;
                case 2:
                    if (value <= 0 || a + b <= value || a + value <= b || b + value <= a)
                        throw new Exception("Установка недопустимого значения C");
                    c = value;
                    break;
                default:
                    throw new Exception("Обращение по недопустимому индексу!");
            }
        }
    }

    public static Triangle operator ++(Triangle t) {
        Triangle temp = new Triangle(t);
        temp.a+=1;
        temp.b+=1;
        temp.c+=1;
        return temp;
    }

    public static Triangle operator --(Triangle t) {
        Triangle temp = new Triangle(t);
        temp.a-=1;
        temp.a-=1;
        temp.a-=1;
        return temp;
    }

    public static bool operator true(Triangle t){
        return t.IsExists();
    }

    public static bool operator false(Triangle t){
        return t.IsExists();
    }

    public static Triangle operator *(Triangle t, int scalar) {
        return new Triangle(t.A * scalar, t.B * scalar, t.C * scalar);
    }


    public static Triangle operator * (int scalar, Triangle t) {
        return t * scalar;
    }
}