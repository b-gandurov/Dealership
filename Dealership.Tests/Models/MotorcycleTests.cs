using Dealership.Exceptions;
using Dealership.Models;
using Dealership.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using static Dealership.Tests.Helpers.TestData;

namespace Dealership.Tests.Models
{
    [TestClass]
    public class MotorcycleTests
    {
        [TestMethod]
        public void Motorcycle_Should_ImplementIMotorcycleInterface()
        {
            var type = typeof(Motorcycle);
            var isAssignable = typeof(IMotorcycle).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Motorcycle class does not implement IMotorcycle interface!");
        }

        [TestMethod]
        public void Motorcycle_Should_ImplementIVehicleInterface()
        {
            var type = typeof(Motorcycle);
            var isAssignable = typeof(IVehicle).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Motorcycle class does not implement IVehicle interface!");
        }

        [TestMethod]
        public void Motorcycle_Should_DeriveFromVehicle()
        {
            var type = typeof(Motorcycle);
            var isAssignable = typeof(Vehicle).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Motorcycle class does not derive from Vehicle base class!");
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_MakeLenghtIsTooShort()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Motorcycle(
                    "1",
                    VehicleData.ValidModel,
                    VehicleData.ValidPrice,
                    MotorcycleData.ValidCategory));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_MakeLenghtIsTooLong()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Motorcycle(
                    "1234567890123456",
                    VehicleData.ValidModel,
                    VehicleData.ValidPrice,
                    MotorcycleData.ValidCategory));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_ModelLenghtIsTooShort()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Motorcycle(
                    VehicleData.ValidMake,
                    "",
                    VehicleData.ValidPrice,
                    MotorcycleData.ValidCategory));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_ModelLenghtIsTooLong()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Motorcycle(
                    VehicleData.ValidMake,
                    "1234567890123456",
                    VehicleData.ValidPrice,
                    MotorcycleData.ValidCategory));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_PriceIsNegative()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Motorcycle(
                    VehicleData.ValidMake,
                    VehicleData.ValidModel,
                    -10,
                    MotorcycleData.ValidCategory));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_PriceIsAbove100000()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Motorcycle(
                    VehicleData.ValidMake,
                    VehicleData.ValidModel,
                    1000001.0m,
                    MotorcycleData.ValidCategory));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_CategoryLenghtIsBelowMinLength()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Motorcycle(
                    VehicleData.ValidMake,
                    VehicleData.ValidModel,
                    VehicleData.ValidPrice,
                    ""));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_CategoryLenghtIsAboveMaxLength()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Motorcycle(
                    VehicleData.ValidMake,
                    VehicleData.ValidModel,
                    VehicleData.ValidPrice,
                    "12345678901"));
        }

        [TestMethod]
        public void Constructor_Should_CreateNewMotorcycle_When_ParametersAreCorrect()
        {
            // Arrange, Act
            var motorcycle = new Motorcycle(
                    VehicleData.ValidMake,
                    VehicleData.ValidModel,
                    VehicleData.ValidPrice,
                    MotorcycleData.ValidCategory);

            // Assert
            Assert.AreEqual(VehicleData.ValidMake, motorcycle.Make);
            Assert.AreEqual(VehicleData.ValidModel, motorcycle.Model);
            Assert.AreEqual(VehicleData.ValidPrice, motorcycle.Price);
            Assert.AreEqual(MotorcycleData.ValidCategory, motorcycle.Category);
        }
    }
}
