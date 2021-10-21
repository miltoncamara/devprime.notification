using System;                             
using System.Linq;
using System.Collections.Generic;                    
                                                    
namespace Application.Services.Notificacao.Model       
{                                                   
  public class Notificacao                     
  {                                                     
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public IList<System.String> Parametros { get; set; }
    public Guid ID { get; set; }
    public virtual IList<Notificacao> ToNotificacaoList(IList<Domain.Aggregates.Notificacao.Notificacao> sourceList)
    {
      var modelList = FromDomainToApplicationNotificacao(sourceList);
      return modelList;
    }
    public virtual Notificacao ToNotificacao(Domain.Aggregates.Notificacao.Notificacao source)
    {
      var model = FromDomainToApplicationNotificacao(source);
      return model;
    }
    public virtual Domain.Aggregates.Notificacao.Notificacao ToNotificacaoDomain()
    {
      var model = FromApplicationToDomainNotificacao(this);
      return model;
    }
    public virtual Domain.Aggregates.Notificacao.Notificacao ToNotificacaoDomain(Guid id)
    {
      var model = new Domain.Aggregates.Notificacao.Notificacao();
      model.ID = id;
      return model;
    }
    public Notificacao()
    {
    }
    public Notificacao(Guid id)
    {
      ID = id;
    }
    public static Application.Services.Notificacao.Model.Notificacao FromDomainToApplicationNotificacao(Domain.Aggregates.Notificacao.Notificacao source)
    {
      if(source is null)
        return new Application.Services.Notificacao.Model.Notificacao();
      Application.Services.Notificacao.Model.Notificacao model = new Application.Services.Notificacao.Model.Notificacao();
      model.Nome = source.Nome;
      model.Email = source.Email;
      model.Telefone = source.Telefone;
      model.Parametros = source.Parametros;
      model.ID = source.ID;
      return model;
    }
    public static List<Application.Services.Notificacao.Model.Notificacao> FromDomainToApplicationNotificacao(IList<Domain.Aggregates.Notificacao.Notificacao> sourceList)
    {
      List<Application.Services.Notificacao.Model.Notificacao> modelList = new List<Application.Services.Notificacao.Model.Notificacao>();
      if(sourceList != null)
      {
        foreach(var source in sourceList)
        {
          Application.Services.Notificacao.Model.Notificacao model = new Application.Services.Notificacao.Model.Notificacao();
          model.Nome = source.Nome;
          model.Email = source.Email;
          model.Telefone = source.Telefone;
          model.Parametros = source.Parametros;
          model.ID = source.ID;
          modelList.Add(model);
        }
      }
      return modelList;
    }
    public static Domain.Aggregates.Notificacao.Notificacao FromApplicationToDomainNotificacao(Application.Services.Notificacao.Model.Notificacao source)
    {
      if(source is null)
        return new Domain.Aggregates.Notificacao.Notificacao();
      Domain.Aggregates.Notificacao.Notificacao model = new Domain.Aggregates.Notificacao.Notificacao(
      source.Nome,
      source.Email,
      source.Telefone,
      source.Parametros,
      source.ID
      );
      return model;
    }
    public static List<Domain.Aggregates.Notificacao.Notificacao> FromApplicationToDomainNotificacao(IList<Application.Services.Notificacao.Model.Notificacao> sourceList)
    {
      List<Domain.Aggregates.Notificacao.Notificacao> modelList = new List<Domain.Aggregates.Notificacao.Notificacao>();
      if(sourceList != null)
      {
        foreach(var source in sourceList)
        {
          Domain.Aggregates.Notificacao.Notificacao model = new Domain.Aggregates.Notificacao.Notificacao(
          source.Nome,
          source.Email,
          source.Telefone,
          source.Parametros,
          source.ID
          );
          modelList.Add(model);
        }
      }
      return modelList;
    }
       
  }                                               
}                                                 