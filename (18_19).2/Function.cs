using System.Xml.Serialization;

[Serializable]
[XmlInclude(typeof(Kub))]
[XmlInclude(typeof(Line))]
[XmlInclude(typeof(Hyperbola))]
public abstract class Function : IComparable<Function>
{
    public float a;
    public float b;

    public abstract float F(float x);
    public abstract string PrintInfo(float x);

    public int CompareTo(Function? other)
    {
        return a.CompareTo(other?.a);
    }
}