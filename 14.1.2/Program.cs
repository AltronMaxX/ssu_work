SPoint[] points = [new SPoint(10, 12, 1), new SPoint(1, 11, 12), new SPoint(4, 3, 2), new SPoint(11, 1, 12)];

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

