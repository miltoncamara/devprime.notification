using System;
using System.Collections.Generic;
using DevPrime.Stack.Foundation;
using Application.Services.Notificacao.Model;

namespace Application.Interfaces.Services
{
    public interface INotificacaoService
    {
        void Add(Notificacao command);
        void Update(Notificacao command);
        void Delete(Notificacao command);
        Notificacao Get(Notificacao query);
        List<Notificacao> GetAll(Notificacao query);
    }
}
