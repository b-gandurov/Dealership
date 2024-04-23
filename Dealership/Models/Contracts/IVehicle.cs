namespace Dealership.Models.Contracts
{
    public interface IVehicle
    {
        string Make { get; }

        string Model { get; }

        VehicleType Type { get; }

        int Wheels { get; }
    }
}
