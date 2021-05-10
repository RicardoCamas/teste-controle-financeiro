using ControleFinanceiro.Domain.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Core.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        Task Adicionar(TEntity obj);

        Task Atualizar(TEntity obj);

        Task Remover(Guid id);

        int Salvar();
    }
}
