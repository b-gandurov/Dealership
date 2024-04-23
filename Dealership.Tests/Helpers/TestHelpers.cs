using Dealership.Models;
using Dealership.Models.Contracts;

using static Dealership.Tests.Helpers.TestData;

namespace Dealership.Tests.Helpers
{
    public static class TestHelpers
    {
        public static string GetTestString(int size)
        {
            return new string('x', size);
        }

        public static ICar InitializeTestCar()
        {
            return new Car(
                    VehicleData.ValidMake,
                    VehicleData.ValidModel,
                    VehicleData.ValidPrice,
                    4);
        }

        public static IUser InitializeTestUser()
        {
            return new User(
                    UserData.ValidUsername,
                    UserData.ValidFirstName,
                    UserData.ValidLastName,
                    UserData.ValidPassword,
                    Role.Normal);
        }

        public static IComment InitializeTestComment()
        {
            return new Comment(CommentData.ValidContent, CommentData.ValidAuthor);
        }
    }
}
