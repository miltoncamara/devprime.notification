using MongoDB.Driver;
using DevPrime.Stack.State.MongoDB;
using DevPrime.State.Repositories.Notificacao.Model;


namespace DevPrime.State.Connections
{
  public class ConnectionMongo : MongoBaseState
  {
    public ConnectionMongo(MongoBaseState stateContext) : base(stateContext)
    {
    }
    public IMongoCollection<DevPrime.State.Repositories.Notificacao.Model.Notificacao> Notificacao
    {
        get
        {
          return DB.GetCollection<DevPrime.State.Repositories.Notificacao.Model.Notificacao>("Notificacao");
        }
    }

  }
}
