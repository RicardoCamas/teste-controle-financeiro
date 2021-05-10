using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Domain.Core.Domain;
using ControleFinanceiro.Domain.Core.Interfaces.Repository;
using ControleFinanceiro.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected ControleFinanceiroContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(ControleFinanceiroContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual Task Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
            return Task.CompletedTask;
        }

        public virtual Task Atualizar(TEntity obj)
        {
            DbSet.Update(obj);
            return Task.CompletedTask;
        }

        public virtual void Dispose()
        {
            Db.Dispose();
        }

        public virtual Task Remover(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
            return Task.CompletedTask;
        }

        public virtual int Salvar()
        {
            return  Db.SaveChanges();
        }
    }
}
