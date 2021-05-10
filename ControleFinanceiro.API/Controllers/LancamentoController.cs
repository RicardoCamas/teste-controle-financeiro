using AutoMapper;
using ControleFinanceiro.Domain.Commands.Lancamentos;
using ControleFinanceiro.Domain.Core.Bus;
using ControleFinanceiro.Domain.Core.Interfaces;
using ControleFinanceiro.Domain.Core.Notifications;
using ControleFinanceiro.Domain.Interfaces.Repository.ReadOnly;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleFinanceiro.API.Controllers
{
    public class LancamentoController : BaseController
    {
        private readonly ILancamentoReadOnlyRepository _lancamentoReadOnlyRepository;
        private readonly IMediatorHandler _mediator;
        IMapper _mapper;

        public LancamentoController(
            IDomainNotificationHandler<DomainNotification> notification,
            IMapper mapper,
            IMediatorHandler mediator,
            ILancamentoReadOnlyRepository lancamentoReadOnlyRepository) 
            : base(notification, mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _lancamentoReadOnlyRepository = lancamentoReadOnlyRepository;
        }

        [HttpGet]
        [Route("lancamento/{id:guid}")]
        public IActionResult ObterPorId(Guid? id, int version)
        {
            if (!id.HasValue)
            {
                _mediator.PublicarEvento(new DomainNotification("Parametro", "O parametro id para remover o Classe Ocupação não pode ser nulo!"));
                return Response();
            }

            var lancamento = _mapper.Map<LancamentoBaseCommand>(_lancamentoReadOnlyRepository.ObterPorId(id.Value));

            return Response(lancamento != null ? lancamento : null);
        }

        [HttpGet]
        [Route("lancemento/obter-todos-lancamentos")]
        public IActionResult ObterTodosLancementos(int version)
        {
            var lancamentos = _mapper.Map<IEnumerable<LancamentoBaseCommand>>(_lancamentoReadOnlyRepository.ObterTodos());
            return Response(lancamentos?.Any() == true ? lancamentos : null);
        }

        [HttpPost]
        [Route("lancamentos")]
        public IActionResult AdicionarLancamento([FromBody] AdicionarLancamentoCommand adicionarLancamentoCommand)
        {
            if (!ModelStateValida()) return Response();

            _mediator.PublicarCommando(adicionarLancamentoCommand);

            return Response(new ValidationResult
            {
                Message = "Lancamento Registrado com Sucesso.",
                ObjectJsonReturn = JsonConvert.SerializeObject(adicionarLancamentoCommand)
            });
        }

        [HttpPut]
        [Route("lancamentos")]
        public IActionResult AtualizarLancamento([FromBody] AtualizarLancamentoCommand atualizarLancamentoCommand)
        {
            if (!ModelStateValida()) return Response();

            _mediator.PublicarCommando(atualizarLancamentoCommand);

            return Response(new ValidationResult
            {
                Message = "Lancamento Atualizado com Sucesso.",
                ObjectJsonReturn = JsonConvert.SerializeObject(atualizarLancamentoCommand)
            });
        }

        [HttpDelete]
        [Route("lancamentos")]
        public IActionResult RemoverLancamento([FromBody] RemoverLancamentoCommand removerLancamentoCommand)
        {
            if (!ModelStateValida()) return Response();

            _mediator.PublicarCommando(removerLancamentoCommand);

            return Response(new ValidationResult
            {
                Message = "Lancamento Removido com Sucesso.",
                ObjectJsonReturn = JsonConvert.SerializeObject(removerLancamentoCommand)
            });
        }
    }
}