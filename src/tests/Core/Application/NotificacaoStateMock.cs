using Application.Interfaces.Adapters.State;
using Application.Services.Notificacao;


namespace Tests_Application
{
    public class NotificacaoStateMock: INotificacaoState
    {
         public INotificacaoRepository Notificacao { get; set; }
      public NotificacaoStateMock(){}

        public NotificacaoStateMock(
               INotificacaoRepository  notificacao

           )
        {
               Notificacao = notificacao;

        }

    }
}
