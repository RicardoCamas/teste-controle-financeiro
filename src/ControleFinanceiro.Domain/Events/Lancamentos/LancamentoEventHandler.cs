using ControleFinanceiro.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Events.Lancamentos
{
    public class LancamentoEventHandler :
        IHandler<LancamentoAdicionadoEvent>,
        IHandler<LancamentoAtualizadoEvent>,
        IHandler<LancamentoRemovidoEvent>
    {
        public Task Handler(LancamentoRemovidoEvent request)
        {
            return Task.CompletedTask;
        }

        public Task Handler(LancamentoAtualizadoEvent request)
        {
            return Task.CompletedTask; ;
        }

        public Task Handler(LancamentoAdicionadoEvent request)
        {
            return Task.CompletedTask;
        }
    }
}
