
using Dealership.Models.Contracts;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Dealership.Models
{
    public class Motorcycle : Vehicle, IMotorcycle
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
        public const int CategoryMinLength = 3;
        public const int CategoryMaxLength = 10;
        public const string InvalidCategoryError = "Category must be between 3 and 10 characters long!";
        private readonly string _category;

        public Motorcycle(string make, string model, decimal price,string category) 
            : base(make, model, price, VehicleType.Motorcycle)
        {
            Validator.ValidateIntRange(make.Length, MakeMinLength, MakeMaxLength, InvalidMakeError);
            Validator.ValidateIntRange(model.Length, ModelMinLength, ModelMaxLength, InvalidModelError);
            Validator.ValidateDecimalRange(price, MinPrice, MaxPrice, InvalidPriceError);
            Validator.ValidateIntRange(category.Length, CategoryMinLength, CategoryMaxLength, InvalidCategoryError);
            _category = category;
        }

        public string Category
        {
            get { return _category; }
        }

        public override string ToString()
        {
            //#. Motorcycle:
            //Make: { make}
            //Model: { model}
            //Wheels: { wheels}
            //Price: ${ price}
            //Category: { category}


            StringBuilder sb = new StringBuilder();
            sb.AppendLine($". Motorcycle:");
            sb.Append(base.ToString());
            sb.AppendLine($"  Category: {Category}");

            return sb.ToString();
        }

    }
}
