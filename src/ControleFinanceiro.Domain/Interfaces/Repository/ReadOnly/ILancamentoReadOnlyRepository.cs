using ControleFinanceiro.Domain.Core.Interfaces.Repository;
using ControleFinanceiro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Interfaces.Repository.ReadOnly
{
    public interface ILancamentoReadOnlyRepository: IReadOnlyRepository<Lancamento>
    {
    }
}
