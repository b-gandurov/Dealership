using Dealership.Exceptions;
using Dealership.Models;
using Dealership.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using static Dealership.Tests.Helpers.TestData;

namespace Dealership.Tests.Models
{
    [TestClass]
    public class TruckTests
    {
        [TestMethod]
        public void Truck_Should_ImplementITruckInterface()
        {
            var type = typeof(Truck);
            var isAssignable = typeof(ITruck).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Truck class does not implement ITruck interface!");
        }

        [TestMethod]
        public void Truck_Should_ImplementIVehicleInterface()
        {
            var type = typeof(Truck);
            var isAssignable = typeof(IVehicle).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Truck class does not implement IVehicle interface!");
        }

        [TestMethod]
        public void Truck_Should_DeriveFromVehicle()
        {
            var type = typeof(Truck);
            var isAssignable = typeof(Vehicle).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Truck class does not derive from Vehicle base class!");
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_MakeLenghtIsTooShort()
        {
            Assert.ThrowsException<InvalidUserInputException>(() => 
                new Truck(
                    "1",
                    VehicleData.ValidModel,
                    VehicleData.ValidPrice,
                    TruckData.MinCapacity));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_MakeLenghtIsTooLong()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Truck(
                    "1234567890123456",
                    VehicleData.ValidModel,
                    VehicleData.ValidPrice,
                    TruckData.MinCapacity));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_ModelLenghtIsTooShort()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Truck(
                    VehicleData.ValidMake,
                    "",
                    VehicleData.ValidPrice,
                    TruckData.MinCapacity));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_ModelLenghtIsTooLong()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Truck(
                    VehicleData.ValidMake,
                    "1234567890123456",
                    VehicleData.ValidPrice,
                    TruckData.MinCapacity));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_PriceIsNegative()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Truck(
                    VehicleData.ValidMake,
                    VehicleData.ValidModel,
                    -10,
                    TruckData.MinCapacity));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_PriceIsAbove100000()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Truck(
                    VehicleData.ValidMake,
                    VehicleData.ValidModel,
                    1000001.0m,
                    TruckData.MinCapacity));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_WeightCapacityIsNegative()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
               new Truck(
                   VehicleData.ValidMake,
                   VehicleData.ValidModel,
                   VehicleData.ValidPrice,
                   -10));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_WeightCapacityIsAbove100()
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
               new Truck(
                   VehicleData.ValidMake,
                   VehicleData.ValidModel,
                   VehicleData.ValidPrice,
                   101));
        }

        [TestMethod]
        public void Constructor_Should_CreateNewTruck_When_ParametersAreCorrect()
        {
            // Arrange, Act
            Truck truck = new Truck(
                   VehicleData.ValidMake,
                   VehicleData.ValidModel,
                   VehicleData.ValidPrice,
                   TruckData.MinCapacity);

            // Assert
            Assert.AreEqual(VehicleData.ValidMake, truck.Make);
            Assert.AreEqual(VehicleData.ValidModel, truck.Model);
            Assert.AreEqual(VehicleData.ValidPrice, truck.Price);
            Assert.AreEqual(TruckData.MinCapacity, truck.WeightCapacity);
        }
    }
}
