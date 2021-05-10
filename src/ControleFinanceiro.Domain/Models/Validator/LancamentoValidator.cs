using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Models.Validator
{
    public class LancamentoValidator : AbstractValidator<Lancamento>
    {
        public LancamentoValidator(Lancamento lancamento)
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("Descrição não pode ser vazia.");

            RuleFor(c => c.Conta)
                .NotEmpty().WithMessage("Conta não pode ser vazia.");

            RuleFor(c => c.Tipo)
                .NotEmpty().WithMessage("Informar o Tipo da conta.");
        }
    }
}
