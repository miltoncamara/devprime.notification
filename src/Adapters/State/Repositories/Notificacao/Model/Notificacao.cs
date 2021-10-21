using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevPrime.State.Repositories.Notificacao.Model  
{
    public class Notificacao
    {
      [BsonId]
      [BsonElement("_id")]
      public ObjectId Id { get; set; }
 
      [BsonRepresentation(BsonType.String)]
      public Guid NotificacaoID { get; set; }
      public string Nome { get; set; }
      public string Email { get; set; }
      public string Telefone { get; set; }
      public IList<System.String> Parametros { get; set; }

    }
}
