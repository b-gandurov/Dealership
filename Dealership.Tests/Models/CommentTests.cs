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
    public class CommentTests
    {
        private const int ContentMinLength = 3;
        private const int ContentMaxLength = 200;


        [TestMethod]
        public void Comment_Should_ImplementICommentInterface()
        {
            var type = typeof(Comment);
            var isAssignable = typeof(IComment).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Comment class does not implement IComment interface!");
        }

        [TestMethod]
        [DataRow(ContentMinLength - 1)]
        [DataRow(ContentMaxLength + 1)]
        public void Constructor_Should_Throw_When_ContentLenghtOutOfBounds(int contentLength)
        {
            string content = TestHelpers.GetTestString(contentLength);
            Assert.ThrowsException<InvalidUserInputException>(() => new Comment(content, CommentData.ValidAuthor));
        }

        [TestMethod]
        public void Constructor_Should_CreateNewComment_When_ParametersAreCorrect()
        {
            // Arrange, Act
            Comment comment = new Comment(CommentData.ValidContent, CommentData.ValidAuthor);

            // Assert
            Assert.AreEqual(CommentData.ValidContent, comment.Content);
            Assert.AreEqual(CommentData.ValidAuthor, comment.Author);
        }
    }
}
