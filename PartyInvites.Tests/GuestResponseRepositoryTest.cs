using System;
using System.Collections.Generic;
using System.Text;
using PartyInvites.Models;
using Moq;
using Xunit;
using PartyInvites.Controllers;
using System.Linq;

namespace PartyInvites.Tests
{
    public class GuestResponseRepositoryTest
    {
        private IRepository Repository;
        [Fact]
        public void AddResponseTest()
        {
            //Arrange
            var mock = new Mock<IRepository>();
            mock.SetupGet(r => r.Responses).Returns(new[] { new GuestResponse
            { Name = "Sander", Address = "TestAdres", Email = "test@mail.com", Phone = "12345", WillAttend = true},
            new GuestResponse { Name = "Sander2", Address = "TestAdres2", Email = "Test2@email.com", Phone = "5431", WillAttend = false}
            });
            var controller = new HomeController(Repository = mock.Object);

            //Act
            GuestResponse res = new GuestResponse();
            res.Email = "test@mail.com";
            res.Name = "TestName";
            Repository.AddResponse(res);
            //Controleren of 3e response niet toegevoegd wordt.
            //Assert
            Assert.Equal(2, Repository.Responses.Count());
        }
    }
}
