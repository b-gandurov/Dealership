using Dealership.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public abstract class Vehicle : IVehicle, IPriceable
    {
        private string _make;
        private string _model;
        private VehicleType _vehicleType;
        private int _wheels;
        private decimal _price;
        public Vehicle(string make, string model, decimal price, VehicleType vehicleType)
        {
            Make = make;
            Model = model;
            Price = price;
            Type = vehicleType;
            Wheels = _wheels;
        }
        public string Make
        {
            get { return _make; }
            private set { _make = value; }
        }

        public string Model
        {
            get { return _model; }
            private set { _model = value; }
        }

        public VehicleType Type
        {
            get { return _vehicleType; }
            private set { _vehicleType = value; }
        }

        public int Wheels
        {
            get { return _wheels; }
            private set { _wheels = (int)Type; }
        }

        public decimal Price
        {
            get { return _price; }
            private set { _price = value; }
        }
    }
}
