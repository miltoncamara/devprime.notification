using System;                             
using System.Linq;
using System.Collections.Generic;                    
                                                    
namespace DevPrime.Web.Models.Notificacao       
{                                                   
    public class Notificacao                     
    {                                                     
      public string Nome { get; set; }
      public string Email { get; set; }
      public string Telefone { get; set; }
      public IList<System.String> Parametros { get; set; }
       

    public static Application.Services.Notificacao.Model.Notificacao FromWebToApplicationNotificacao(DevPrime.Web.Models.Notificacao.Notificacao source)
    {
      if(source is null)
        return new Application.Services.Notificacao.Model.Notificacao();
      Application.Services.Notificacao.Model.Notificacao model = new Application.Services.Notificacao.Model.Notificacao();
      model.Nome = source.Nome;
      model.Email = source.Email;
      model.Telefone = source.Telefone;
      model.Parametros = source.Parametros;
      return model;
    }
    public static List<Application.Services.Notificacao.Model.Notificacao> FromWebToApplicationNotificacao(IList<DevPrime.Web.Models.Notificacao.Notificacao> sourceList)
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
          modelList.Add(model);
        }
      }
      return modelList;
    }
    public virtual Application.Services.Notificacao.Model.Notificacao ToApplication()
    {
      var model = FromWebToApplicationNotificacao(this);
      return model;
    }
 
    }                                               
}                                                   
