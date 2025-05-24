using Entities.Abstract;

namespace Entities;

[Serializable]
public class Hyperbola : Function
{
    public Hyperbola(){
        A = 0;
        B = 0;
    }

    public Hyperbola(float a, float b) {
        A = a;
        B = b;
    }

    public override float F(float x)
    {
        return A/x + B;
    }

    public override string PrintInfo(float x)
    {
        return $"{A} / {x} + {B} = {F(x)}";
    }

    public override string ToString()
    {
        return $"{A} / x + {B}";
    }
}