[Serializable]
public class Hyperbola : Function
{
    public Hyperbola(){
        a = 0;
        b = 0;
    }

    public Hyperbola(float a, float b) {
        this.a = a;
        this.b = b;
    }

    public override float F(float x)
    {
        return a/x + b;
    }

    public override string PrintInfo(float x)
    {
        return $"{a} / {x} + {b} = {F(x)}";
    }
}