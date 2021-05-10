using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Events.Lancamentos
{
    public class LancamentoRemovidoEvent : LancamentoBaseEvent
    {
        public LancamentoRemovidoEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
