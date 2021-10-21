using Microsoft.Extensions.DependencyInjection;
using DevPrime.Stream;
using DevPrime.State;
using DevPrime.Stack.Foundation.Stream;
using DevPrime.Stack.Foundation;
using DevPrime.Stack.App.Pipeline;
using Application.EventHandlers;
using Application.Interfaces.Adapters.State;
using DevPrime.State.Connections;
using DevPrime.State.States;
using DevPrime.State.Repositories.Notificacao;
using Application.Interfaces.Services;
using Application.Services.Notificacao;
using Application.Interfaces.Adapters.Tools;
using DevPrime.Tools;

namespace App
{
    public class App : AppBase
    {
        public App()
        {
            AppName = "MSNotification";
        }

        public override void GetDependencies(IServiceCollection services)
        {
            services.AddScoped<INotificacaoRepository, NotificacaoRepository>();
            services.AddScoped<INotificacaoService, NotificacaoService>();
            services.AddScoped<INotificacaoState, NotificacaoState>();
            services.AddScoped<INotificacaoTools, NotificacaoTools>();
            services.AddScoped<IWhatsApp, WhatsApp>();

            services.AddSingleton<IEventStream, EventStream>();
            services.AddSingleton<IEventHandler, EventHandler>();

        }
        public override void Start()
        {

        }
        public override  void Stop()
        {

        }
    }
}
