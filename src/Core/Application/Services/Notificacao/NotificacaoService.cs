using System.Collections.Generic;
using DevPrime.Stack.Foundation.Application;
using Application.Interfaces.Services;
using Application.Interfaces.Adapters.State;

namespace Application.Services.Notificacao
{
    public class NotificacaoService : ApplicationService<INotificacaoState>, INotificacaoService
    {
        public NotificacaoService(INotificacaoState state, IDp dp) : base(state, dp) { }

        public void Add(Model.Notificacao command)
        {
            Dp.Pipeline(Execute: () =>
            {
                var agg = command.ToNotificacaoDomain();
                Dp.AddDomain(agg);
                agg.Add();
            });
        }
        public void Update(Model.Notificacao command)
        {
            Dp.Pipeline(Execute: () =>
            {
                var agg = command.ToNotificacaoDomain();
                Dp.AddDomain(agg);
                agg.Update();
            });
        }
        public void Delete(Model.Notificacao command)
        {
            Dp.Pipeline(Execute: () =>
            {
                var agg = command.ToNotificacaoDomain();
                Dp.AddDomain(agg);
                agg.Delete();
            });
        }
        public List<Model.Notificacao> GetAll(Model.Notificacao command)
        {
            return Dp.Pipeline(ExecuteResult: () =>
            {
                var model = command.ToNotificacaoList(Dp.State.Notificacao.GetAll());
                return model;
            });
        }
        public Model.Notificacao Get(Model.Notificacao command)
        {
            return Dp.Pipeline(ExecuteResult: () =>
            {
                var model = command.ToNotificacao(Dp.State.Notificacao.Get(command.ID));
                return model;
            });
        }
    }
}