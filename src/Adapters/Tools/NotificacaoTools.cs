using Application.Interfaces.Adapters.Tools;

namespace DevPrime.Tools
{
    public class NotificacaoTools : INotificacaoTools
    {
        public IWhatsApp WhatsApp { get;set; }
        public NotificacaoTools(IWhatsApp whatsapp)
        {
          WhatsApp = whatsapp;
        }
    }
}
