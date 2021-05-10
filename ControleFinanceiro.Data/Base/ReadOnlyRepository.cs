using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Domain.Core.Domain;
using ControleFinanceiro.Domain.Core.Interfaces.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleFinanceiro.Data.Base
{
    public class ReadOnlyRepository<TEntity> : ReadOnlyNotGenericRepository, IReadOnlyRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected ControleFinanceiroContext Db;
        protected DbSet<TEntity> DbSet;
        protected ReadOnlyRepository(ControleFinanceiroContext context, IHttpContextAccessor httpContextAccessor = null) : base(httpContextAccessor)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public TEntity ObterPorId(Guid id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
