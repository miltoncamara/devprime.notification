using DevPrime.Stack.Foundation;
using DevPrime.Stack.Foundation.Application;
using Application.EventHandlers.Notificacao;
using Domain.Aggregates.Notificacao.Events;
   

namespace Application.EventHandlers
{
    public class EventHandler : IEventHandler
    {
        public EventHandler(IHandler handler)
        {
            handler.Add<NotificacaoCreated,NotificacaoCreatedEventHandler>();
            handler.Add<NotificacaoDeleted,NotificacaoDeletedEventHandler>();
            handler.Add<NotificacaoUpdated,NotificacaoUpdatedEventHandler>();
   
        }
    }
}