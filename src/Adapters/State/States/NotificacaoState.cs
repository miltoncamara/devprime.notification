using Application.Interfaces.Adapters.State;


namespace DevPrime.State.States
{
    public class NotificacaoState: INotificacaoState
    {
        public INotificacaoRepository Notificacao { get; set; }

        public NotificacaoState(
               INotificacaoRepository  notificacao

           )
        {
               Notificacao = notificacao;

        }

    }
}
