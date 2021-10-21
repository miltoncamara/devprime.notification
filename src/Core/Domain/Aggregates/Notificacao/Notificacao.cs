using System.Linq;
using System;
using DevPrime.Stack.Foundation.Exceptions;
using Domain.Aggregates.Notificacao.Events;
using DevPrime.Stack.Foundation;
using System.Collections.Generic;
namespace Domain.Aggregates.Notificacao
{
    public class Notificacao : AggRoot
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public List<string> Parametros { get; private set; }
    
        private void ValidFields()
        {
          if (String.IsNullOrEmpty(Nome)) Dp.Notifications.Add("Nome is required");
          if (String.IsNullOrEmpty(Email)) Dp.Notifications.Add("Email is required");
          if (String.IsNullOrEmpty(Telefone)) Dp.Notifications.Add("Telefone is required");

          Dp.Notifications.ValidateAndThrow();
        }
        public virtual void Add()
        {
          Dp.Pipeline(Execute: () =>
          {
            ValidFields();
            ID = Guid.NewGuid();
            Dp.ProcessEvent(new NotificacaoCreated());
          });
        }
        public virtual void Update()
        {
          Dp.Pipeline(Execute: () =>
          {
            ValidFields();
            Dp.ProcessEvent(new NotificacaoUpdated());
          });
        }
        public virtual void Delete()
        {
          Dp.Pipeline(Execute: () =>
          {
            if(ID != Guid.Empty)
            Dp.ProcessEvent(new NotificacaoDeleted());
          });
        }

  

        public Notificacao(
            string _Nome,
            string _Email,
            string _Telefone,
            IList<System.String> _Parametros,
            Guid _ID
        )
        {
            Nome = _Nome;
            Email = _Email;
            Telefone = _Telefone;
            Parametros = _Parametros?.ToList();
            ID = _ID;

        }
        public Notificacao(){}

}
}