using Dealership.Exceptions;
using Dealership.Models;
using Dealership.Models.Contracts;
using Dealership.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using static Dealership.Tests.Helpers.TestData;

namespace Dealership.Tests.Models
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void User_Should_ImplementIUserInterface()
        {
            var type = typeof(User);
            var isAssignable = typeof(IUser).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "User class does not implement IUser interface!");
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_UsernameLenghtIsTooShort()
        {
            Assert.ThrowsException<InvalidUserInputException>(() => 
                new User(
                    "u",
                    UserData.ValidFirstName,
                    UserData.ValidLastName,
                    UserData.ValidPassword,
                    Role.Normal));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_UsernameLenghtIsTooLong()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new User(
                    "abcdefghijklmnopqrstu",
                    UserData.ValidFirstName,
                    UserData.ValidLastName,
                    UserData.ValidPassword,
                    Role.Normal));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_UsernameIsInvalid()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new User(
                    "U$$ernam3",
                    UserData.ValidFirstName,
                    UserData.ValidLastName,
                    UserData.ValidPassword,
                    Role.Normal));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_FirstNameLenghtIsTooShort()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new User(
                    UserData.ValidUsername,
                    "f",
                    UserData.ValidLastName,
                    UserData.ValidPassword,
                    Role.Normal));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_FirstNameLenghtIsTooLong()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new User(
                    UserData.ValidUsername,
                    "abcdefghijklmnopqrstu",
                    UserData.ValidLastName,
                    UserData.ValidPassword,
                    Role.Normal));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_LastNameLenghtIsTooShort()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new User(
                    UserData.ValidUsername,
                    UserData.ValidFirstName,
                    "l",
                    UserData.ValidPassword,
                    Role.Normal));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_LastNameLenghtIsTooLong()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new User(
                    UserData.ValidUsername,
                    UserData.ValidFirstName,
                    "abcdefghijklmnopqrstu",
                    UserData.ValidPassword,
                    Role.Normal));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_PasswordLenghtIsTooShort()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new User(
                    UserData.ValidUsername,
                    UserData.ValidFirstName,
                    UserData.ValidLastName,
                    "pass",
                    Role.Normal));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_PasswordLenghtIsTooLong()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new User(
                    UserData.ValidUsername,
                    UserData.ValidFirstName,
                    UserData.ValidLastName,
                    "passwordpasswordpasswordpassword",
                    Role.Normal));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_PasswordIsInvalid()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
               new User(
                   UserData.ValidUsername,
                   UserData.ValidFirstName,
                   UserData.ValidLastName,
                   "Pa-$$_w0rD",
                   Role.Normal));
        }

        [TestMethod]
        public void Constructor_Should_CreateNewUser_When_ParametersAreCorrect()
        {
            // Arrange, Act
            var user = new User(
                   UserData.ValidUsername,
                   UserData.ValidFirstName,
                   UserData.ValidLastName,
                   UserData.ValidPassword,
                   Role.Normal);

            // Assert
            Assert.AreEqual(UserData.ValidUsername, user.Username);
        }

        [TestMethod]
        public void Vehicles_Should_ReturnCopyOfTheCollection()
        {
            // Arrange
            var user = TestHelpers.InitializeTestUser();

            // Act
            user.Vehicles.Add(TestHelpers.InitializeTestCar());

            // Assert
            Assert.AreEqual(0, user.Vehicles.Count);
        }

        [TestMethod]
        public void AddComment_Should_AddCommentToTheCollection()
        {
            // Arrange
            var user = TestHelpers.InitializeTestUser();
            var car = TestHelpers.InitializeTestCar();
            user.AddVehicle(car);

            // Act
            user.AddComment(TestHelpers.InitializeTestComment(), car);

            // Assert
            Assert.AreEqual(1, car.Comments.Count);
        }

        [TestMethod]
        public void AddVehicle_Should_AddVehicle_WhenNormalUser()
        {
            // Arrange
            var user = TestHelpers.InitializeTestUser();

            // Act
            user.AddVehicle(TestHelpers.InitializeTestCar());

            // Assert
            Assert.AreEqual(1, user.Vehicles.Count);
        }

        [TestMethod]
        public void AddVehicle_Should_ThrowException_WhenNormalUserReachedLimit()
        {
            // Arrange
            var user = TestHelpers.InitializeTestUser();
            for (int i = 0; i < 5; i++)
            {
                user.AddVehicle(TestHelpers.InitializeTestCar());
            }

            // Act, Assert
            Assert.ThrowsException<AuthorizationException>(() => user.AddVehicle(TestHelpers.InitializeTestCar()));
        }

        [TestMethod]
        public void AddVehicle_Should_ThrowException_WhenAdminUser()
        {
            // Arrange
            var user = new User(
                        UserData.ValidUsername,
                        UserData.ValidFirstName,
                        UserData.ValidLastName,
                        UserData.ValidPassword,
                        Role.Admin);

            // Act, Assert
            Assert.ThrowsException<AuthorizationException>(() => user.AddVehicle(TestHelpers.InitializeTestCar()));
        }

        [TestMethod]
        public void AddVehicle_Should_AddVehicle_WhenVipUser()
        {
            // Arrange
            var user = new User(
                        UserData.ValidUsername,
                        UserData.ValidFirstName,
                        UserData.ValidLastName,
                        UserData.ValidPassword,
                        Role.VIP);

            // Act
            user.AddVehicle(TestHelpers.InitializeTestCar());

            // Assert
            Assert.AreEqual(1, user.Vehicles.Count);
        }

        [TestMethod]
        public void AddVehicle_Should_AddVehicle_WhenVipUserAndMoreThan5Vehicles()
        {
            // Arrange
            var user = new User(
                        UserData.ValidUsername,
                        UserData.ValidFirstName,
                        UserData.ValidLastName,
                        UserData.ValidPassword,
                        Role.VIP);

            for (int i = 0; i < 5; i++)
            {
                user.AddVehicle(TestHelpers.InitializeTestCar());
            }

            // Act
            user.AddVehicle(TestHelpers.InitializeTestCar());

            // Assert
            Assert.AreEqual(6, user.Vehicles.Count);
        }

        [TestMethod]
        public void RemoveComment_Should_RemoveComment_When_AuthorMatch()
        {
            // Arrange
            var user = new User(
                        "user1",
                        UserData.ValidFirstName,
                        UserData.ValidLastName,
                        UserData.ValidPassword,
                        Role.Normal);
            var car = TestHelpers.InitializeTestCar();
            var comment = new Comment(CommentData.ValidContent, "user1");
            user.AddVehicle(car);
            user.AddComment(comment, car);

            // Act
            user.RemoveComment(comment, car);

            // Assert
            Assert.AreEqual(0, car.Comments.Count);
        }

        [TestMethod]
        public void RemoveComment_Should_ThrowException_When_AuthorNotMatch()
        {
            // Arrange
            // Arrange
            var user = new User(
                        "user1",
                        UserData.ValidFirstName,
                        UserData.ValidLastName,
                        UserData.ValidPassword,
                        Role.Normal);
            var car = TestHelpers.InitializeTestCar();
            var comment = new Comment(CommentData.ValidContent, "user2");
            user.AddVehicle(car);
            user.AddComment(comment, car);
            user.AddVehicle(car);
            user.AddComment(comment, car);

            // Act, Assert
            Assert.ThrowsException<AuthorizationException>(() => user.RemoveComment(comment, car));
        }

        [TestMethod]
        public void RemoveVehicle_Should_RemoveVehicle_FromTheCollection()
        {
            // Arrange
            var user = TestHelpers.InitializeTestUser();
            var car = TestHelpers.InitializeTestCar();
            user.AddVehicle(car);
            
            // Act
            user.RemoveVehicle(car);

            // Assert
            Assert.AreEqual(0, user.Vehicles.Count);
        }
    }
}
