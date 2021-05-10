using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFinanceiro.Domain.Core.Bus;
using ControleFinanceiro.Domain.Core.Interfaces;
using ControleFinanceiro.Domain.Core.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Base")]
    public abstract class BaseController : ControllerBase
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notification;
        private readonly IMediatorHandler _mediator;
        public BaseController(
            IDomainNotificationHandler<DomainNotification> notification,
            IMediatorHandler mediator)
        {
            _notification = notification;
            _mediator = mediator;
        }

        protected bool OperacaoValida()
        {
            return (!_notification.HasNotifications());
        }

        protected new IActionResult Response(object resultado = null)
        {
            if (OperacaoValida())
            {
                return Ok(new {
                  success = true,
                  data = resultado
                });
            }

            return BadRequest(new {
                success = false,
                data = _notification.GetNotications().Select(c => c.Value)
            });
        }

        protected bool ModelStateValida()
        {
            if (ModelState.IsValid) return true;

            NotificarErroModelInvalida();
            return false;
        }

        private void NotificarErroModelInvalida()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(string.Empty, erroMsg);
            }
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediator.PublicarEvento(new DomainNotification(codigo, mensagem));
        }
    }
}