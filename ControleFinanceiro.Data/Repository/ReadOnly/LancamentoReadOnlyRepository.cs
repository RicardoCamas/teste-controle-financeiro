using ControleFinanceiro.Data.Base;
using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Domain.Interfaces.Repository.ReadOnly;
using ControleFinanceiro.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Data.Repository.ReadOnly
{
    public class LancamentoReadOnlyRepository : ReadOnlyRepository<Lancamento>, ILancamentoReadOnlyRepository
    {
        protected LancamentoReadOnlyRepository(ControleFinanceiroContext context, IHttpContextAccessor httpContextAccessor = null) : base(context, httpContextAccessor) { }
    }
}
