using Entity;
using Domain;

namespace Mappers;

public static class VehicleMapper
{
    public static VehicleEntity ToEntity(this Vehicle vehicle)
    {
        return new VehicleEntity
        {
            Model = vehicle.Model,
            GovermentNumber = vehicle.GovermentNumber,
            DriverId = vehicle.DriverId
        };
    }
}
