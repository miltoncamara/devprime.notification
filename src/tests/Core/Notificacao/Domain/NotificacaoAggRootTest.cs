using Domain.Aggregates.Notificacao.Events;
using DevPrime.Stack.Test;
using System;
using Xunit;
using DevPrime.Stack.Foundation.Exceptions;

namespace Tests_Domain.Notificacao
{
    public partial class NotificacaoAggRootTest
    {
        #region ValidateFields
        [Fact]
        [Trait("Category", "Validate")]
        [Trait("Category", "Success")]
        public void ValidateFields_FieldsAreValid_Success()
        {
            //Arrange
            var agg = MockNotificacao();
            //Act
            agg.DevPrimeCallMethod("ValidFields");
            //Assert
            Assert.True(agg.Dp.Notifications.IsValid);
        }
        #endregion ValidateFields
        #region Add
        [Fact]
        [Trait("Category", "Add")]
        [Trait("Category", "Success")]
        public void Add_AllFieldsFilled_TriggerEventNotificacaoCreated()
        {
            //Arrange
            var agg = MockNotificacao();
            //Act
            agg.Add();
            //Assert
            Assert.True(agg.Dp.GetDomainEvent() is NotificacaoCreated);
        }

        #endregion Add
        #region Update
        [Fact]
        [Trait("Category", "Update")]
        [Trait("Category", "Success")]
        public void Update_FieldsFilled_TriggerEventNotificacaoUpdated()
        {
            //Arrange
            var agg = MockNotificacao();
            //Act
            agg.Update();
            //Assert
            Assert.True(agg.Dp.GetDomainEvent() is NotificacaoUpdated);
        }
        #endregion Update
        #region Delete
        [Fact]
        [Trait("Category", "Delete")]
        [Trait("Category", "Success")]
        public void Delete_FieldsFilled_TriggerEventNotificacaoDeleted()
        {
            //Arrange
            var agg = MockNotificacao();
            agg.ID = Guid.NewGuid();
            //Act
            agg.Delete();
            //Assert
            Assert.True(agg.Dp.GetDomainEvent() is NotificacaoDeleted);
        }
        [Fact]
        [Trait("Category", "Delete")]
        [Trait("Category", "Failure")]
        public void Delete_FieldsNotFilled_DontTriggerEvent()
        {
            //Arrange
            var agg = MockNotificacao();
            agg.ID = Guid.Empty;
            //Act
            agg.Delete();
            //Assert
            Assert.False(agg.Dp.GetDomainEvent() is NotificacaoDeleted);
        }
        #endregion Delete
    }
}