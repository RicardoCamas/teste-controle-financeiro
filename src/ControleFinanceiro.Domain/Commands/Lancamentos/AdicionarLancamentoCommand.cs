using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Commands.Lancamentos
{
    public class AdicionarLancamentoCommand: LancamentoBaseCommand
    {
        public AdicionarLancamentoCommand (
        DateTime data,
        decimal valor,
        string descricao,
        string conta,
        string tipo)
        {
            Id = Guid.NewGuid();
            AggregateId = Id;
            Data = data;
            Valor = valor;
            Descricao = descricao;
            Conta = conta;
            Tipo = tipo;
        }
}
}
