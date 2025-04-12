using Domain;
using Services.Abstract;
using Data.Repository.Abstract;
using Mappers;

namespace Services;

public class DriversService : IDriverService
{
    private readonly IDriversRepository _driversRepository;

    public DriversService(IDriversRepository driversRepository)
    {
        _driversRepository = driversRepository;
    }

    public void AddDriver(Driver driver)
    {
        _driversRepository.AddDriver(driver.ToEntity());
    }

    public void DeleteDriverById(int Id)
    {
        _driversRepository.DeleteDriverById(Id);
    }

    public Driver GetDriverById(int Id)
    {
        throw new NotImplementedException();
    }

    public void UpdateDriverById(Driver driver)
    {
        throw new NotImplementedException();
    }
}
