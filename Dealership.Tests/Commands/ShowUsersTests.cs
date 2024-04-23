using Dealership.Commands;
using Dealership.Commands.Contracts;
using Dealership.Core;
using Dealership.Core.Contracts;
using Dealership.Exceptions;
using Dealership.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static Dealership.Tests.Helpers.TestData;

namespace Dealership.Tests.Commands
{
    [TestClass]
    public class ShowUsersTests
    {
        private IRepository repository;
        private ICommand command;

        [TestInitialize]
        public void InitTest()
        {
            repository = new Repository();
            command = new ShowUsersCommand(repository);
        }

        [TestMethod]
        public void Should_ThrowException_When_NoUserIsLoggedIn()
        {
            Assert.ThrowsException<AuthorizationException>(() => command.Execute());
        }

        [TestMethod]
        public void should_ThrowException_When_LoggedInUserIsNotAdmin()
        {
            // Arrange
            var user = new User(
                        UserData.ValidUsername,
                        UserData.ValidFirstName,
                        UserData.ValidLastName,
                        UserData.ValidPassword,
                        Role.Normal);

            repository.LogUser(user);

            // Act, Assert
            Assert.ThrowsException<AuthorizationException>(() => command.Execute());
        }
    }
}
