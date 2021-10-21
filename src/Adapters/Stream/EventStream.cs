using Application.Interfaces.Services;
using DevPrime.Stack.Foundation.Stream;
using DevPrime.Stack.Stream;

namespace DevPrime.Stream
{
    public class EventStream : EventStreamBase, IEventStream
    {
        public override void StreamEvents()
        {
            Subscribe<INotificacaoService>("NotificacaoEvents", (payload, notificacaoService, Dp) =>
            {
                Dp.Observability.Log("Recebeu mensagem do Kafka: " + payload);
                //notificacaoService.Add();
            });
        }
    }
}