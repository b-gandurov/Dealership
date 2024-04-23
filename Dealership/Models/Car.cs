
using Dealership.Models;
using Dealership.Models.Contracts;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Dealership.Models
{
    public class Car : Vehicle, ICar
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
        public const int MinSeats = 1;
        public const int MaxSeats = 10;
        public const string InvalidSeatsError = "Seats must be between 1 and 10!";
        private readonly int _seats;

        public Car(string make, string model, decimal price,int seats) 
            : base(make, model, price, VehicleType.Car)
        {
            
            Validator.ValidateIntRange(make.Length,MakeMinLength, MakeMaxLength, InvalidMakeError);
            Validator.ValidateIntRange(model.Length, ModelMinLength, ModelMaxLength,  InvalidModelError);
            Validator.ValidateDecimalRange(price, MinPrice, MaxPrice,  InvalidPriceError);
            Validator.ValidateIntRange(seats, MinSeats, MaxSeats,  InvalidSeatsError);
            _seats = seats;

        }

        public int Seats
        {
            get { return _seats; }
            
        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($". Car:");
            sb.Append(base.ToString());
            sb.Append($"  Seats: {Seats}");
            

            return sb.ToString();
        }

    }

   
}


