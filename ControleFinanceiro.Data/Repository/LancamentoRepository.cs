using ControleFinanceiro.Data.Base;
using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Domain.Interfaces.Repository;
using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.Data.Repository
{
    public class LancamentoRepository : Repository<Lancamento>, ILancamentoRepository
    {
        public LancamentoRepository(ControleFinanceiroContext context) : base(context) { }
    }
}
