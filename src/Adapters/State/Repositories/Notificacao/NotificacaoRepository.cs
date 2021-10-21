using System;
using System.Linq;
using MongoDB.Driver;
using System.Collections.Generic;
using DevPrime.Stack.Foundation.State;
using Application.Interfaces.Adapters.State;
using DevPrime.State.Connections;

namespace DevPrime.State.Repositories.Notificacao
{
    public class NotificacaoRepository : RepositoryBase, INotificacaoRepository
    {
        public NotificacaoRepository(IDpState dp) : base(dp)
        {
            ConnectionAlias = "State1";
        }
        #region Write
        public void Add(Domain.Aggregates.Notificacao.Notificacao source)
        {
            Dp.Pipeline(Execute: (stateContext) =>
            {
                var state = new ConnectionMongo(stateContext);
                var model = FromDomainToStateNotificacao(source);
                state.Notificacao.InsertOne(model);
            });
        }
        public void Delete(Guid id)
        {
            Dp.Pipeline(Execute: (stateContext) =>
            {
                var state = new ConnectionMongo(stateContext);
                state.Notificacao.DeleteOne(prop => prop.NotificacaoID == id);
            });
        }
        public void Update(Domain.Aggregates.Notificacao.Notificacao source)
        {
            Dp.Pipeline(Execute: (stateContext) =>
            {
                var state = new ConnectionMongo(stateContext);
                var model = FromDomainToStateNotificacao(source);
                model.Id = state.Notificacao.Find(p => p.NotificacaoID == source.ID).FirstOrDefault().Id;
                state.Notificacao.ReplaceOne(p => p.NotificacaoID == source.ID, model);
            });
        }
        #endregion Write
        #region Read
        public Domain.Aggregates.Notificacao.Notificacao Get(Guid Id)
        {
            return Dp.Pipeline(ExecuteResult: (stateContext) =>
            {
                var state = new ConnectionMongo(stateContext);
                var source = state.Notificacao.Find(p => p.NotificacaoID == Id).FirstOrDefault();
                var model = FromStateToDomainNotificacao(source);
                return model;
            });
        }
        public List<Domain.Aggregates.Notificacao.Notificacao> GetAll()
        {
            return Dp.Pipeline(ExecuteResult: (stateContext) =>
            {
                var state = new ConnectionMongo(stateContext);
                var source = state.Notificacao.Find(_ => true).ToList();
                var model = FromStateToDomainNotificacao(source);
                return model;
            });
        }
        #endregion Read
        #region mappers

        public static DevPrime.State.Repositories.Notificacao.Model.Notificacao FromDomainToStateNotificacao(Domain.Aggregates.Notificacao.Notificacao source)
        {
            if (source is null)
                return new DevPrime.State.Repositories.Notificacao.Model.Notificacao();
            DevPrime.State.Repositories.Notificacao.Model.Notificacao model = new DevPrime.State.Repositories.Notificacao.Model.Notificacao();
            model.Nome = source.Nome;
            model.Email = source.Email;
            model.Telefone = source.Telefone;
            model.Parametros = source.Parametros;
            model.NotificacaoID = source.ID;
            return model;
        }
        public static Domain.Aggregates.Notificacao.Notificacao FromStateToDomainNotificacao(DevPrime.State.Repositories.Notificacao.Model.Notificacao source)
        {
            if (source is null)
                return new Domain.Aggregates.Notificacao.Notificacao() { IsNew = true };
            Domain.Aggregates.Notificacao.Notificacao model = new Domain.Aggregates.Notificacao.Notificacao(
            source.Nome,
            source.Email,
            source.Telefone,
            source.Parametros,
            source.NotificacaoID
            );
            return model;
        }
        public static List<Domain.Aggregates.Notificacao.Notificacao> FromStateToDomainNotificacao(IList<DevPrime.State.Repositories.Notificacao.Model.Notificacao> sourceList)
        {
            List<Domain.Aggregates.Notificacao.Notificacao> modelList = new List<Domain.Aggregates.Notificacao.Notificacao>();
            if (sourceList != null)
            {
                foreach (var source in sourceList)
                {
                    Domain.Aggregates.Notificacao.Notificacao model = new Domain.Aggregates.Notificacao.Notificacao(
                    source.Nome,
                    source.Email,
                    source.Telefone,
                    source.Parametros,
                    source.NotificacaoID
                    );
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion mappers
    }
}