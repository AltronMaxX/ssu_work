using Entity;

namespace Data.Repository.Abstract;

public interface IDriversRepository
{
    void AddDriver(DriverEntity driver);
    void UpdateDriver(DriverEntity Id);

    DriverEntity GetDriverById(int Id);
    void DeleteDriverById(int Id);

    List<DriverEntity> GetAllDrivers();
}
