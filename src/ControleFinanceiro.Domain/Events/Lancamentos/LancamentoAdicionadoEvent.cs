using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Events.Lancamentos
{
    public class LancamentoAdicionadoEvent: LancamentoBaseEvent
    {
        public LancamentoAdicionadoEvent(Guid id,
            DateTime data,
            decimal valor,
            string descricao,
            string conta,
            string tipo)
        {
            Id = id;
            AggregateId = id;
            Data = data;
            Valor = valor;
            Descricao = descricao;
            Conta = conta;
            Tipo = tipo;
        }
    }
}
