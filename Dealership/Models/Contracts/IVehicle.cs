namespace Dealership.Models.Contracts
{
    public interface IVehicle:ICommentable
    {
        string Make { get; }

        string Model { get; }

        VehicleType Type { get; }

        int Wheels { get; }
    }
}
