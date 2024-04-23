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
    public class CarTests
    {
        public const int ValidSeats = 4;

        [TestMethod]
        public void Car_Should_ImplementICarInterface()
        {
            var type = typeof(Car);
            var isAssignable = typeof(ICar).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Car class does not implement ICar interface!");
        }

        [TestMethod]
        public void Car_Should_ImplementIVehicleInterface()
        {
            var type = typeof(Car);
            var isAssignable = typeof(IVehicle).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Car class does not implement IVehicle interface!");
        }

        [TestMethod]
        public void Car_Should_DeriveFromVehicle()
        {
            var type = typeof(Car);
            var isAssignable = typeof(Vehicle).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Car class does not derive from Vehicle base class!");
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_MakeLenghtIsTooShort()
        {
            Assert.ThrowsException<InvalidUserInputException>(() => 
                new Car(
                    "1",
                    VehicleData.ValidModel,
                    VehicleData.ValidPrice,
                    ValidSeats));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_MakeLenghtIsTooLong()
        {
            Assert.ThrowsException<InvalidUserInputException>(() => 
                new Car(
                    "1234567890123456",
                    VehicleData.ValidModel,
                    VehicleData.ValidPrice,
                    ValidSeats));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_ModelLenghtIsTooShort()
        {
            Assert.ThrowsException<InvalidUserInputException>(() => 
                new Car(
                    VehicleData.ValidMake,
                    "",
                    VehicleData.ValidPrice,
                    ValidSeats));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_ModelLenghtIsTooLong()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Car(
                    VehicleData.ValidMake,
                    "1234567890123456",
                    VehicleData.ValidPrice,
                    ValidSeats));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_PriceIsNegative()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Car(
                    VehicleData.ValidMake,
                    VehicleData.ValidModel,
                    -10,
                    ValidSeats));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_PriceIsAbove1000000()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
            new Car(
                    VehicleData.ValidMake,
                    VehicleData.ValidModel,
                    1000001.0m,
                    ValidSeats));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_SeatsIsNegative()
        {
            Assert.ThrowsException<InvalidUserInputException>(() => 
                new Car(
                    VehicleData.ValidMake,
                    VehicleData.ValidModel,
                    VehicleData.ValidPrice,
                    -4));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_SeatsIsAbove10()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Car(
                    VehicleData.ValidMake,
                    VehicleData.ValidModel,
                    VehicleData.ValidPrice,
                    11));
        }

        [TestMethod]
        public void Constructor_Should_CreateNewCar_When_ParametersAreCorrect()
        {
            // Arrange, Act
            var car = new Car(
                    VehicleData.ValidMake,
                    VehicleData.ValidModel,
                    VehicleData.ValidPrice,
                    ValidSeats);

            // Assert
            Assert.AreEqual(VehicleData.ValidMake, car.Make);
            Assert.AreEqual(VehicleData.ValidModel, car.Model);
            Assert.AreEqual(VehicleData.ValidPrice, car.Price);
            Assert.AreEqual(ValidSeats, car.Seats);
        }

        [TestMethod]
        public void Comments_Should_ReturnCopyOfTheCollection()
        {
            // Arrange
            var car = TestHelpers.InitializeTestCar();

            // Act
            var comment = TestHelpers.InitializeTestComment();
            car.Comments.Add(comment);

            // Assert
            Assert.AreEqual(0, car.Comments.Count);
        }

        [TestMethod]
        public void AddComment_Should_AddCommentToTheCollection()
        {
            // Arrange
            var car = TestHelpers.InitializeTestCar();

            // Act
            var comment = TestHelpers.InitializeTestComment();
            car.AddComment(comment);

            // Assert
            Assert.AreEqual(1, car.Comments.Count);
        }

        [TestMethod]
        public void RemoveComment_Should_RemoveCommentFromTheCollection()
        {
            // Arrange
            var car = TestHelpers.InitializeTestCar();
            var comment = TestHelpers.InitializeTestComment();
            car.AddComment(comment);
            
            // Act
            car.RemoveComment(comment);

            // Assert
            Assert.AreEqual(0, car.Comments.Count);
        }
    }
}
