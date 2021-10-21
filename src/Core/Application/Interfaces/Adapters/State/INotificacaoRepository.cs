using System;
using System.Collections.Generic;

namespace Application.Interfaces.Adapters.State
{
    public interface INotificacaoRepository
    {
        void Add(Domain.Aggregates.Notificacao.Notificacao source);
        void Delete(Guid Id);
        void Update(Domain.Aggregates.Notificacao.Notificacao source);
        Domain.Aggregates.Notificacao.Notificacao Get(Guid Id);
        List<Domain.Aggregates.Notificacao.Notificacao> GetAll();
    }
}
