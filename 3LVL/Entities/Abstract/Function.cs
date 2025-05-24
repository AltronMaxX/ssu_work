namespace Entities.Abstract;

using System.Xml.Serialization;

[Serializable]
[XmlInclude(typeof(Kub))]
[XmlInclude(typeof(Line))]
[XmlInclude(typeof(Hyperbola))]
public abstract class Function : IComparable<Function>
{
    public float A;
    public float B;

    public abstract float F(float x);
    public abstract string PrintInfo(float x);

    public int CompareTo(Function? other)
    {
        return A.CompareTo(other?.A);
    }
}