
using Dealership.Exceptions;
using Dealership.Models.Contracts;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml.Linq;

namespace Dealership.Models
{
    public class User : IUser
    {
        private const string UsernamePattern = "^[A-Za-z0-9]+$";
        private const string InvalidUsernameFormatError = "Username contains invalid symbols!";
        private const string InvalidUsernameLengthError = "Username must be between 2 and 20 characters long!";

        private const int NameMinLength = 2;
        private const int NameMaxLength = 20;
        private const string InvalidNameError = "name must be between 2 and 20 characters long!";

        private const int PasswordMinLength = 5;
        private const int PasswordMaxLength = 30;
        private const string PasswordPattern = "^[A-Za-z0-9@*_-]+$";
        private const string InvalidPasswordFormatError = "Username contains invalid symbols!";
        private const string InvalidPasswordLengthError = "Password must be between 5 and 30 characters long!";

        private const int MaxVehiclesToAdd = 5;

        private const string NotAnVipUserVehiclesAdd = "You are not VIP and cannot add more than {0} vehicles!";
        private const string AdminCannotAddVehicles = "You are an admin and therefore cannot add vehicles!";
        private const string YouAreNotTheAuthor = "You are not the author of the comment you are trying to remove!";
        private const string NoVehiclesHeader = "--NO VEHICLES--";

        private readonly string _userName;
        private string _firstName;
        private string _lastName;
        private string _password;
        private Role _role;
        private IList<IVehicle> _vehicles = new List<IVehicle>();

        public User(string username, string firstName, string lastName, string password, Role role)
        {
            Validator.ValidateSymbols(username, UsernamePattern, InvalidUsernameFormatError);
            Validator.ValidateIntRange(username.Length, 2, 20, InvalidUsernameLengthError);
            _userName = username;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            _role = role;
        }

        public string Username => _userName;

        public string FirstName
        {
            get => _firstName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidUserInputException("FirstName cannot be null or empty!");
                }
                Validator.ValidateIntRange(value.Length, NameMinLength, NameMaxLength, InvalidNameError);
                _firstName = value;
            }

        }

        public string LastName
        {
            get => _lastName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidUserInputException("LastName cannot be null or empty!");
                }
                Validator.ValidateIntRange(value.Length, NameMinLength, NameMaxLength, InvalidNameError);
                _lastName = value;
            }

        }

        public string Password
        {
            get => _password;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidUserInputException("LastName cannot be null or empty!");
                }
                Validator.ValidateIntRange(value.Length, PasswordMinLength, PasswordMaxLength, InvalidPasswordLengthError);
                Validator.ValidateSymbols(value, PasswordPattern, InvalidPasswordFormatError);
                _password = value;
            }

        }

        public Role Role => _role;

        public IList<IVehicle> Vehicles => new List<IVehicle>(_vehicles);

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            vehicleToAddComment.AddComment(commentToAdd);

        }

        public void AddVehicle(IVehicle vehicle)
        {
            if (Role==Role.Admin)
            {
                throw new AuthorizationException(AdminCannotAddVehicles);
            }else if (Role==Role.Normal && _vehicles.Count>= MaxVehiclesToAdd)
            {
                throw new AuthorizationException(NotAnVipUserVehiclesAdd);
            }
            _vehicles.Add(vehicle);
        }

        public string PrintVehicles()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"--USER {Username}--");
            if (_vehicles.Count==0) {
                sb.AppendLine(NoVehiclesHeader);
                return sb.ToString();
            }
            int vehicleNum = 1;
            foreach (var vehicle in _vehicles)
            {
                sb.Append(vehicleNum++);
                sb.AppendLine(vehicle.ToString());
            }

            return sb.ToString();
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            if (commentToRemove.Author!=Username)
            {
                throw new AuthorizationException(YouAreNotTheAuthor);
            }
            foreach (var vehicle in _vehicles)
            {
                if(vehicle==vehicleToRemoveComment)
                {
                    vehicle.RemoveComment(commentToRemove);
                    break;
                }
            }
            
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            foreach (var vi in _vehicles)
            {
                if(vi==vehicle)
                {
                    _vehicles.Remove(vi);
                    break;
                }
                
            }
        }

        //ToDo
    }
}
