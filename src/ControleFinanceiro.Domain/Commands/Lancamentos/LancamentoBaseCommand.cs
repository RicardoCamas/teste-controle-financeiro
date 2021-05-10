using ControleFinanceiro.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Commands.Lancamentos
{
    public class LancamentoBaseCommand:Command
    {
        public Guid Id { get; protected set; }
        public DateTime Data { get; protected set; }
        public decimal Valor { get; protected set; }
        public string Descricao { get; protected set; }
        public string Conta { get; protected set; }
        public string Tipo { get; protected set; }
    }
}
