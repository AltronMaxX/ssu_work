using System.Xml.Serialization;
using Entities.Abstract;

namespace Data;

public class FunctionRepository
{
    private const string FilePath = "./Functions.xml";

    public List<Function> GetAll()
    {
        if (!File.Exists(FilePath))
            return new List<Function>();

        var serializer = new XmlSerializer(typeof(List<Function>));
        using var stream = new FileStream(FilePath, FileMode.Open);
        return (List<Function>)serializer.Deserialize(stream);
   }

    public Function GetById(int Id)
    {
        var all = GetAll();

        if (Id < 0 || Id >= all.Count)
            throw new IndexOutOfRangeException($"Объекта с заданным индексом ({Id}) не существует!");

        return all[Id];
    }

    public void RemoveById(int Id)
    {
        var all = GetAll();

        if (Id < 0 || Id >= all.Count)
            throw new IndexOutOfRangeException($"Объекта с заданным индексом ({Id}) не существует!");

        all.Remove(all[Id]);
        SaveAll(all);
    }

    public void SaveAll(List<Function> functions)
    {
        var serializer = new XmlSerializer(typeof(List<Function>));
        using var stream = new FileStream(FilePath, FileMode.Create);
        serializer.Serialize(stream, functions);
    }
}