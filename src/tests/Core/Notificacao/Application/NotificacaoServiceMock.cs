using Application.Interfaces.Adapters.State;
using Moq;
using System;
using System.Collections.Generic;
using DevPrime.Stack.Test;
using Domain.Aggregates.Notificacao.Events;
using DevPrime.Stack.Foundation;
using Application.Services.Notificacao;

namespace Tests_Application.Notificacao
{
    public class NotificacaoModelMock : Application.Services.Notificacao.Model.Notificacao
    {
        public override Domain.Aggregates.Notificacao.Notificacao ToNotificacaoDomain()
        {
            var agg = MockNotificacaoAggRoot(
            this.Nome,this.Email,this.Telefone,this.Parametros,this.ID            
            );
            return agg;
        }
        public override NotificacaoModelMock ToNotificacao(Domain.Aggregates.Notificacao.Notificacao agg)
        {
            var model = new NotificacaoModelMock();
            model.Nome = agg.Nome;
            model.Email = agg.Email;
            model.Telefone = agg.Telefone;
            model.ID = agg.ID;


            return model;
        }
        public override Domain.Aggregates.Notificacao.Notificacao ToNotificacaoDomain(Guid id)
        {
            var agg = MockNotificacaoAggRoot(
                       String.Empty,
                       String.Empty,
                       String.Empty,
                       null,
                       Guid.Empty

            );
            agg.DevPrimeSetProperty<Guid>("ID", id);

            return agg;
        }
        private Domain.Aggregates.Notificacao.Notificacao MockNotificacaoAggRoot(
            string _Nome,
            string _Email,
            string _Telefone,
            IList<System.String> _Parametros,
            Guid _ID

        )
        {
            var AggMock = new Mock<Domain.Aggregates.Notificacao.Notificacao>(_Nome,_Email,_Telefone,_Parametros,_ID); ;
            var agg = AggMock.Object;

            AggMock.Setup(o => o.Add()).Callback(() =>
            {
                agg.Dp.ProcessEvent(new NotificacaoCreated());
            });
            AggMock.Setup(o => o.Update()).Callback(() =>
            {
                agg.Dp.ProcessEvent(new NotificacaoUpdated());
            });
            AggMock.Setup(o => o.Delete()).Callback(() =>
            {
                agg.Dp.ProcessEvent(new NotificacaoDeleted());
            });

            return agg;
        }

    }
    public class NotificacaoServiceMock
    {
        public List<DomainEvent> OutPutDomainEvents { get; set; }

        public Application.Services.Notificacao.Model.Notificacao MockCommand()
        {
            var agg = new NotificacaoModelMock();
                agg.Nome = Faker.Lorem.Sentence();
                agg.Email = Faker.Lorem.Sentence();
                agg.Telefone = Faker.Lorem.Sentence();

            return agg;
        }

        public NotificacaoService MockNotificacaoService()
        {
            OutPutDomainEvents = new List<DomainEvent>();

            var state = new NotificacaoStateMock();
            var dp = new DpMock<INotificacaoState>(state,(domainevent)=> {
                OutPutDomainEvents.Add(domainevent);
            });
            
            var srv = new NotificacaoService(state,dp);
            
            return srv;
        }
    }
   
}