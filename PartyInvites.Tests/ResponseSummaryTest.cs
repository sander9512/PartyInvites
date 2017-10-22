using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using PartyInvites.Models;
using PartyInvites.Controllers;
using Moq;
using System.Linq;
namespace PartyInvites.Tests
{
    public class ResponseSummaryTest
    {
        private IRepository Repository;
        [Fact]
        public void AttendeesTest()
        {
            //Arrange
            var mock = new Mock<IRepository>();
            mock.SetupGet(r => r.Responses).Returns(new[] { new GuestResponse
            { Name = "Sander", Address = "TestAdres", Email = "test@mail.com", Phone = "12345", WillAttend = true},
            new GuestResponse { Name = "Sander2", Address = "TestAdres2", Email = "Test2@email.com", Phone = "5431", WillAttend = false}
            });
            var controller = new HomeController(Repository = mock.Object);

            //Act
            IEnumerable<GuestResponse> Responses = Repository.Responses.Where(r => r.WillAttend == true);

            //Assert
            Assert.Equal(1, Responses.Count());
        }
        [Fact]
        public void TotalResponsesTest()
        {
            //Arrange
            var mock = new Mock<IRepository>();
            mock.SetupGet(r => r.Responses).Returns(new[] { new GuestResponse
            { Name = "Sander", Address = "TestAdres", Email = "test@mail.com", Phone = "12345", WillAttend = true},
            new GuestResponse { Name = "Sander2", Address = "TestAdres2", Email = "Test2@email.com", Phone = "5431", WillAttend = false}
            });
            var controller = new HomeController(Repository = mock.Object);

            //Act
            IEnumerable<GuestResponse> Responses = mock.Object.Responses;

            //Assert
            Assert.Equal(2, Responses.Count());
        }
    }
}
