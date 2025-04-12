using Entity;
using Domain;

namespace Mappers;

public static class DriverMapper
{
    public static DriverEntity ToEntity(this Driver driver)
    {
        return new DriverEntity
        {
            Name = driver.Name,
            Age = driver.Age.ToString()
        };
    }
}
