using Entities.Abstract;

namespace Entities;

[Serializable]
public class Kub : Function
{
    public float C;

    public Kub() {
        A = 0;
        B = 0;
        C = 0;
    }

    public Kub(float a, float b, float c) {
        A = a;
        B = b;
        C = c;
    }

    public override float F(float x)
    {
        return A * (x*x) + B * x + C;
    }

    public override string PrintInfo(float x)
    {
        return $"{A} * {x}^2 + {B} * {x} + {C} = {F(x)}";
    }

    public override string ToString()
    {
        return $"{A} * x^2 + {B} * x + {C}";
    }
}