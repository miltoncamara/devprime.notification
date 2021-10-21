using Application.Interfaces.Adapters.Tools;
using DevPrime.Stack.Foundation;
using DevPrime.Stack.Foundation.Application;
using DevPrime.Stack.Tools;
using DevPrime.Tools.Positus;
using System.Collections.Generic;
using System.Linq;

namespace DevPrime.Tools
{
    public class WhatsApp : DevPrimeTools, IWhatsApp
    {
        public WhatsApp(IDpTools dpTools) : base(dpTools)
        {
        }

        public bool Notificar(string nome, string telefone, List<string> parametros)
        {
            return Dp.Pipeline(ExecuteResult: () =>
            {
                var mensagem = $"Olá {nome}, seja bem vindo ao serviço de notificação via Whats App. { parametros.FirstOrDefault() }";
                var messageTemplateRequest = new SendMessageTemplateRequest(telefone, mensagem);
                var paramHttp = new HTTPParameter(Dp.Settings.Default("positus.api.notification.url"));
                paramHttp.Content = messageTemplateRequest.ToString();
                paramHttp.Headers.Add("Authorization", $"Bearer {Dp.Settings.Default("positus.api.token")}");

                var resultadoApi = Dp.Services.HTTP.Post<SendMessageTemplateResponse>(paramHttp);

                if (resultadoApi.Status == 200 && resultadoApi.Content.message == "The message was successfully sent")
                    return true;
                return false;
            });
        }
    }
}
