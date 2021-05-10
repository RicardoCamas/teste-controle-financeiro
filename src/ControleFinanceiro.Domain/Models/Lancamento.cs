using ControleFinanceiro.Domain.Core.Domain;
using ControleFinanceiro.Domain.Models.Validator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Models
{
    public class Lancamento:Entity<Lancamento>
    {
        protected Lancamento() { }

        public Lancamento(Guid id,
            DateTime data,
            decimal valor,
            string descricao,
            string conta,
            string tipo)
        {
            Id = id;
            Data = data;
            Valor = valor;
            Descricao = descricao;
            Conta = conta;
            Tipo = tipo;
        }
        public DateTime Data { get; private set; }
        public decimal Valor { get; private set; }
        public string Descricao { get; private set; }
        public string Conta { get; private set; }
        public string Tipo { get; private set; }

        public override bool EhValido()
        {
            ValidationResult = new LancamentoValidator(this).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
