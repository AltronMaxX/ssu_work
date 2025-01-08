List<SPoint> points = new List<SPoint>();
using (StreamReader pointsReader = new StreamReader("./points.txt")) {
    while (!pointsReader.EndOfStream) {
        string line = pointsReader.ReadLine();
        string[] coords = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
        if (coords.Length == 3) {
            points.Add(new SPoint(int.Parse(coords[0]), int.Parse(coords[1]), int.Parse(coords[2])));
        } else {
            Console.WriteLine("Неверно заданна точка в строке {0}", line);
        }
    }
}

List<SPoint> maxPoints = new List<SPoint>();

foreach (SPoint point in points) {
    if (maxPoints.Count > 0 && point.Distance() > maxPoints[0].Distance()) {
        maxPoints.Clear();
        maxPoints.Add(point);
    } else if (maxPoints.Count > 0 && point.Distance() == maxPoints[0].Distance()) {
        maxPoints.Add(point);
    } else if (maxPoints.Count == 0) {
        maxPoints.Add(point);
    }
}

foreach (SPoint point in maxPoints) {
    point.Show();
}

struct SPoint {
    public float x, y, z;

    public SPoint (float x, float y, float z) {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public double Distance() {
        return Math.Sqrt(x*x + y*y + z*z);
    }

    public void Show() {
        Console.WriteLine($"x:{x}\ty:{y}\tz:{z}");
    }
}

