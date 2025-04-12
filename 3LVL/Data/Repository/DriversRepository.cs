using Data.Repository.Abstract;
using Entity;

namespace Data.Repository;

internal class DriversRepository : IDriversRepository
{
    private static List<DriverEntity> list = new();

    public void AddDriver(DriverEntity driver)
    {
        throw new NotImplementedException();
    }

    public void DeleteDriverById(int Id)
    {
        throw new NotImplementedException();
    }

    public void UpdateDriver(DriverEntity Id)
    {
        throw new NotImplementedException();
    }
    
    public DriverEntity GetDriverById(int Id)
    {
        throw new NotImplementedException();
    }

    public List<DriverEntity> GetAllDrivers()
    {
        return list;
    }
}
