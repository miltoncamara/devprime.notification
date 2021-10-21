using DevPrime.Stack.Foundation.Application;
using Domain.Aggregates.Notificacao.Events;
using Application.Services.Notificacao.Model;
using Application.Interfaces.Adapters.State;
using Application.Interfaces.Adapters.Tools;
using System.Collections.Generic;

namespace Application.EventHandlers.Notificacao
{
    public class NotificacaoCreatedEventHandler :
        EventHandlerWithStateAndTools<NotificacaoCreated, INotificacaoState, INotificacaoTools>
    {
        public NotificacaoCreatedEventHandler(INotificacaoState state, IDp dp, INotificacaoTools nt) : base(state, nt, dp) { }
        public override dynamic Handle(NotificacaoCreated domainEvent)
        {
            var notificacao = domainEvent.Get<Domain.Aggregates.Notificacao.Notificacao>();
            var listParametros = new List<string>() { notificacao.ID.ToString() };
            var mensagemEnviada = Dp.Tools.WhatsApp.Notificar(notificacao.Nome, notificacao.Telefone, listParametros);

            if (mensagemEnviada)
            {
                Dp.Observability.Log("Mensagem enviada.");
                Dp.Observability.Log("Persistindo notificação");
                Dp.State.Notificacao.Add(notificacao);

                var destination = "notificacaoevents";
                var eventName = "NotificationCreated";

                var dto = new NotificacaoCreatedEventDTO()
                {
                    ID = notificacao.ID,
                    Nome = notificacao.Nome,
                    Email = notificacao.Email,
                    Telefone = notificacao.Telefone
                };

                Dp.Stream.Send(destination, eventName, dto);

                return "Notificação Enviada com Sucesso.";
            }

            return true;
        }
    }
}