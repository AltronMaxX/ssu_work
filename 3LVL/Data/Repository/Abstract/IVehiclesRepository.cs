using Entity;

namespace Data.Repository.Abstract;

public interface IVehiclesRepository
{
    void AddVehicle(VehicleEntity vehicle);
    void UpdateVehicle(VehicleEntity vehicle);

    VehicleEntity GetVehicleById(int Id);
    void DeleteVehicleById(int Id);
}
