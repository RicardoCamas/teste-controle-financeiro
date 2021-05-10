using ControleFinanceiro.Domain.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Core.Interfaces.Repository
{
    public interface IReadOnlyRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
    }
}
