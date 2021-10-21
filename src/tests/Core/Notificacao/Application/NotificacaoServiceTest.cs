using DevPrime.Stack.Test;
using Domain.Aggregates.Notificacao.Events;
using System;
using Xunit;

namespace Tests_Application.Notificacao
{
    public class NotificacaoServiceTest
    {
        [Fact]
        [Trait("Category", "Add")]
        [Trait("Category", "Success")]
        public void Add_Command_Result()
        {
            //Arrange
            var serviceMock = new NotificacaoServiceMock();
            var command = serviceMock.MockCommand();
            var service = serviceMock.MockNotificacaoService();
            //Act
            service.Add(command);
            //Assert
            Assert.NotNull(serviceMock.OutPutDomainEvents[0] as NotificacaoCreated);
        }
        [Fact]
        [Trait("Category", "Update")]
        [Trait("Category", "Success")]
        public void Update_Command_Result()
        {
            //Arrange
            var serviceMock = new NotificacaoServiceMock();
            var command = serviceMock.MockCommand();
            var service = serviceMock.MockNotificacaoService();
            //Act
            service.Update(command);
            //Assert
            Assert.NotNull(serviceMock.OutPutDomainEvents[0] as NotificacaoUpdated);
        }
        [Fact]
        [Trait("Category", "Delete")]
        [Trait("Category", "Success")]
        public void Delete_Command_Result()
        {
            //Arrange
            var serviceMock = new NotificacaoServiceMock();
            var command = serviceMock.MockCommand();
            var service = serviceMock.MockNotificacaoService();
            //Act
            service.Delete(command);
            //Assert
            Assert.NotNull(serviceMock.OutPutDomainEvents[0] as NotificacaoDeleted);
        }
    }
 }
