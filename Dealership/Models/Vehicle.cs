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
                    _make=value;
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
