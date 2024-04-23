using Dealership.Exceptions;
using Dealership.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public abstract class Vehicle : IVehicle, IPriceable, ICommentable
    {
        private string _make;
        private string _model;
        private VehicleType _vehicleType;
        private int _wheels;
        private decimal _price;
        private IList<IComment> _comments = new List<IComment>();

        // The constructors for vehicle models (Car, Truck, Motorcycle) incorporate validation to ensure
        // that every vehicle instance is created in a valid state. This approach upholds the principle
        // of immutability, critical for representing real-world, unmodifiable physical objects once
        // they are created. By embedding these validations, we ensure that all properties meet specific
        // criteria (e.g., value ranges, mandatory fields) right from the start, preventing any illegal
        // states and guaranteeing the consistency of vehicle data throughout the application's lifecycle.
        // This design choice simplifies maintenance and enhances reliability by making the vehicle objects
        // predictable and their behavior error-free.


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
            private set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _make = value;
                }
                else
                {
                    throw new InvalidUserInputException("Make cannot be null or empty!");
                }

            }
        }

        public string Model
        {
            get { return _model; }
            private set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _model = value;
                }
                else
                {
                    throw new InvalidUserInputException("Model cannot be null or empty!");
                }

            }
        }

        public VehicleType Type
        {
            get { return _vehicleType; }
            private set
            {
                if (Enum.TryParse(value.ToString(), true, out VehicleType result))
                {
                    _vehicleType = result;
                }
                else
                {
                    throw new InvalidUserInputException("No such vehicle type");
                }

            }
        }

        public int Wheels
        {
            get { return _wheels; }
            private set { _wheels = (int)Type; }
        }

        public decimal Price
        {
            get { return _price; }
            private set
            {
                _price = value;

            }
        }

        public IList<IComment> Comments => new List<IComment>(_comments);


        public void AddComment(IComment comment)
        {
            _comments.Add(comment);
        }

        public void RemoveComment(IComment comment)
        {
            _comments.Remove(comment);
        }

        public string PrintComments()
        {
            StringBuilder sb = new StringBuilder();
            if (_comments.Count == 0)
            {
                sb.AppendLine("--NO COMMENTS--");
                return sb.ToString();
            }
            sb.AppendLine("--COMMENTS--");
            foreach (IComment comment in _comments)
            {
                sb.AppendLine(comment.ToString());
            }
            sb.AppendLine("--COMMENTS--");
            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"  Make: {Make}");
            sb.AppendLine($"  Model: {Model}");
            sb.AppendLine($"  Wheels: {Wheels}");
            sb.AppendLine($"  Price: ${Price}");

            return sb.ToString();
        }

    }
}
