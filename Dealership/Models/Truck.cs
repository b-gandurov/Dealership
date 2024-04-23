
namespace Dealership.Models
{
    public class Truck
    {
        public const int MakeMinLength = 2;
        public const int MakeMaxLength = 15;
        public const string InvalidMakeError = "Make must be between 2 and 15 characters long!";
        public const int ModelMinLength = 1;
        public const int ModelMaxLength = 15;
        public const string InvalidModelError = "Model must be between 1 and 15 characters long!";
        public const decimal MinPrice = 0.0m;
        public const decimal MaxPrice = 1000000.0m;
        public const string InvalidPriceError = "Price must be between 0.0 and 1000000.0!";
        public const int MinCapacity = 1;
        public const int MaxCapacity = 100;
        public const string InvalidCapacityError = "Weight capacity must be between 1 and 100!";

        //ToDo
    }
}
