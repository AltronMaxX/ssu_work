[Serializable]
public class Kub : Function
{
    public float c;

    public Kub() {
        a = 0;
        b = 0;
        c = 0;
    }

    public Kub(float a, float b, float c) {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public override float F(float x)
    {
        return a * (x*x) + b * x + c;
    }

    public override string PrintInfo(float x)
    {
        return $"{a} * {x}^2 + {b} * {x} + {c} = {F(x)}";
    }
}