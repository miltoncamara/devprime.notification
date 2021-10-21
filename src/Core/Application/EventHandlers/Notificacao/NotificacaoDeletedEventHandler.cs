using DevPrime.Stack.Foundation.Application;
using Domain.Aggregates.Notificacao.Events;
using Application.Services.Notificacao.Model;
using Application.Interfaces.Adapters.State;

namespace Application.EventHandlers.Notificacao
{
    public class NotificacaoDeletedEventHandler:
        EventHandler<NotificacaoDeleted,INotificacaoState>
    {
        public NotificacaoDeletedEventHandler(INotificacaoState state, IDp dp) : base(state, dp) { }
        public override dynamic Handle(NotificacaoDeleted domainEvent)
        {
            var notificacao = domainEvent.Get<Domain.Aggregates.Notificacao.Notificacao>();
            Dp.State.Notificacao.Delete(notificacao.ID);

            var destination = Dp.Settings.Default("stream.notificacaoevents");
            var eventName = "NotificacaoDeleted";
            var dto = new NotificacaoDeletedEventDTO()
            {
              Nome = notificacao.Nome,
              Email = notificacao.Email,
              Telefone = notificacao.Telefone,
              ID = notificacao.ID
            };    
            Dp.Stream.Send(destination, eventName, dto);

            return true;
        }
    }
}