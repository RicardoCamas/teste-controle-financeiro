using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Commands.Lancamentos
{
    public class RemoverLancamentoCommand: LancamentoBaseCommand
    {
        public RemoverLancamentoCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
