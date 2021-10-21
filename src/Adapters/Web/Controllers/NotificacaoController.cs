using DevPrime.Stack.Foundation;
using DevPrime.Stack.Foundation.Web;
using DevPrime.Stack.Web;
using Application.Services.Notificacao.Model;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace DevPrime.Web.Controllers
{
    [Route("v1/Notificacao")]
    public class NotificacaoController : DevPrimeController
    {
        private INotificacaoService Service { get; set; }
        public NotificacaoController(INotificacaoService service, IDpWeb dp) : base(dp)
        {
            Service = service;
        }
        [HttpPost]
        public async Task<Result> Add([FromBody] DevPrime.Web.Models.Notificacao.Notificacao NotificacaoAdd)
        {

            return await Dp.PipelineAsync(Execute: () =>
            {
                var command = NotificacaoAdd.ToApplication();
                Service.Add(command);
            });
        }
        [HttpPut]
        public async Task<Result> Update([FromBody] Notificacao command)
        {
            return await Dp.PipelineAsync(Execute: () =>
            {
                Service.Update(command);
            });
        }
        [HttpDelete("{id}")]
        public async Task<Result> Delete(Guid id)
        {
            return await Dp.PipelineAsync(Execute: () =>
            {
                Service.Delete(new Application.Services.Notificacao.Model.Notificacao(id));
            });
        }
        [HttpGet]
        public async Task<Result> Get()
        {
            return await Dp.PipelineAsync(ExecuteResult: () =>
            {
                var result = Service.GetAll(new Application.Services.Notificacao.Model.Notificacao());
                if(Dp.Exceptions.Count == 0)
                {
                    if (result == null || result.Count == 0)
                    {
                      Dp.Web.StatusCode = 404;
                      result = null;
                    } 
                }
                return result;
            });
        }
        [HttpGet("{id}")]
        public async Task<Result> Get(Guid id)
        {
            return await Dp.PipelineAsync(ExecuteResult: () =>
            {
                var result = Service.Get(new Application.Services.Notificacao.Model.Notificacao(id));
                if(Dp.Exceptions.Count == 0)
                {
                    if (result.ID == Guid.Empty)
                    {
                        Dp.Web.StatusCode = 404;
                        result = null;
                    }
                }        
                return result;
            });
        }

    }
}

