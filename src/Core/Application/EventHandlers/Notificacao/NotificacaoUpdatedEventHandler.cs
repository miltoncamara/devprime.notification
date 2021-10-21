using DevPrime.Stack.Foundation.Application;
using Domain.Aggregates.Notificacao.Events;
using Application.Services.Notificacao.Model;
using Application.Interfaces.Adapters.State;

namespace Application.EventHandlers.Notificacao
{
    public class NotificacaoUpdatedEventHandler:
        EventHandler<NotificacaoUpdated,INotificacaoState>
    {
        public NotificacaoUpdatedEventHandler(INotificacaoState state, IDp dp) : base(state, dp) { }
        public override dynamic Handle(NotificacaoUpdated domainEvent)
        {
            var notificacao = domainEvent.Get<Domain.Aggregates.Notificacao.Notificacao>();
            Dp.State.Notificacao.Update(notificacao);

            var destination = Dp.Settings.Default("stream.notificacaoevents");
            var eventName = "NotificacaoUpdated";
            var dto = new NotificacaoUpdatedEventDTO()
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