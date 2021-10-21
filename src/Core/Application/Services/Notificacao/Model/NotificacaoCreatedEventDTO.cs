using System;                             
using System.Linq;
using System.Collections.Generic;                    
                                                    
namespace Application.Services.Notificacao.Model      
{                                                   
  public class NotificacaoCreatedEventDTO                     
  {                                                     
      public string Nome { get; set;} 
      public string Email { get; set;} 
      public string Telefone { get; set;} 
      public Guid ID { get; set;} 
       
  }                                               
}                                                 