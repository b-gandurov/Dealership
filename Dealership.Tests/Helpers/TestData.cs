
namespace Dealership.Tests.Helpers
{
    public static class TestData
    {
        public static class VehicleData
        {
            private const int MakeMinLength = 2;
            private const int ModelMinLength = 1;
            private const decimal MinPrice = 0.0m;

            public static string ValidMake = TestHelpers.GetTestString(MakeMinLength + 1);
            public static string ValidModel = TestHelpers.GetTestString(ModelMinLength + 1);
            public static decimal ValidPrice = MinPrice + 1;
        }

        public static class MotorcycleData
        {
            private const int CategoryMinLength = 3;

            public static string ValidCategory = TestHelpers.GetTestString(CategoryMinLength + 1);
        }

        public static class TruckData
        {
            public const int MinCapacity = 1;
        }

        public static class UserData
        {
            public const string ValidUsername = "username";
            public const string ValidFirstName = "firstName";
            public const string ValidLastName = "lastName";
            public const string ValidPassword = "password";
        }

        public static class CommentData
        {
            public const string ValidContent = "Content";
            public const string ValidAuthor = "Author";
        }

    }
}
