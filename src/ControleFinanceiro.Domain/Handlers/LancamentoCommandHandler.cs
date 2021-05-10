using ControleFinanceiro.Domain.Commands.Lancamentos;
using ControleFinanceiro.Domain.Core.Bus;
using ControleFinanceiro.Domain.Core.Commands;
using ControleFinanceiro.Domain.Core.Interfaces;
using ControleFinanceiro.Domain.Core.Notifications;
using ControleFinanceiro.Domain.Events.Lancamentos;
using ControleFinanceiro.Domain.Interfaces.Repository;
using ControleFinanceiro.Domain.Interfaces.Repository.ReadOnly;
using ControleFinanceiro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Handlers
{
    public class LancamentoCommandHandler : CommandHandler,
        IHandler<AdicionarLancamentoCommand>,
        IHandler<AtualizarLancamentoCommand>,
        IHandler<RemoverLancamentoCommand>
    {
        private readonly ILancamentoRepository _lancamentoRepository;
        private readonly ILancamentoReadOnlyRepository _lancamentoReadOnlyRepository;
        private readonly IMediatorHandler _mediator;


        public LancamentoCommandHandler(
            ILancamentoRepository lancamentoRepository,
            ILancamentoReadOnlyRepository lancamentoReadOnlyRepository,
            IUnitOfWork uow,
            IMediatorHandler mediator,
            IDomainNotificationHandler<DomainNotification> notification)
            : base(uow, mediator, notification)
        {
            _lancamentoRepository = lancamentoRepository;
            _lancamentoReadOnlyRepository = lancamentoReadOnlyRepository;
            _mediator = mediator;
        }

        public async Task Handler(AdicionarLancamentoCommand request)
        {
            var lancamento = new Lancamento(request.Id, request.Data, request.Valor, request.Descricao, request.Conta, request.Tipo);

            if (!EntidadeValida(lancamento)) return;

             await _lancamentoRepository.Adicionar(lancamento).ConfigureAwait(false);

            if (Commit())
            {
                await _mediator.PublicarEvento(new LancamentoAdicionadoEvent(lancamento.Id, lancamento.Data, lancamento.Valor, lancamento.Descricao, lancamento.Conta, lancamento.Tipo)).ConfigureAwait(false);
            }
        }

        public async Task Handler(AtualizarLancamentoCommand request)
        {
            var lancamentoTupla = EntidadeExistente(request.Id, request.MessageType);
            if (!lancamentoTupla.exist) return;

            var lancamentoAtual = (Lancamento)lancamentoTupla.entity;

            var lancamentoParaAtualizar = new Lancamento(lancamentoAtual.Id, request.Data, request.Valor, request.Descricao, request.Conta, request.Tipo);

            if (!EntidadeValida(lancamentoParaAtualizar)) return;

            await _lancamentoRepository.Atualizar(lancamentoParaAtualizar).ConfigureAwait(false);

            if (Commit())
            {
                await _mediator.PublicarEvento(new LancamentoAtualizadoEvent(lancamentoParaAtualizar.Id, lancamentoParaAtualizar.Data, lancamentoParaAtualizar.Valor, lancamentoParaAtualizar.Descricao, lancamentoParaAtualizar.Conta, lancamentoParaAtualizar.Tipo)).ConfigureAwait(false);
            }
        }

        public async Task Handler(RemoverLancamentoCommand request)
        {
            var lancamentoTupla = EntidadeExistente(request.Id, request.MessageType);
            if (lancamentoTupla.exist) return;

            await _lancamentoRepository.Remover(request.Id).ConfigureAwait(false);

            if (Commit())
            {
                await _mediator.PublicarEvento(new LancamentoRemovidoEvent(request.Id)).ConfigureAwait(false);
            }
        }

        protected override (object entity, bool exist) EntidadeExistente(Guid id, string messageType)
        {
            var lancamento = _lancamentoReadOnlyRepository.ObterPorId(id);

            if (lancamento != null) return (lancamento, true);

            _mediator.PublicarEvento(new DomainNotification(messageType, "Lancamento não foi encontrado"));

            return (lancamento, false);
        }

        protected override bool EntidadeValida(object entity)
        {
            var lancamento = (Lancamento)entity;
            if (lancamento.EhValido()) return true;

            NotificarValidacoesErro(lancamento.ValidationResult);
            return false;
        }
    }
}
