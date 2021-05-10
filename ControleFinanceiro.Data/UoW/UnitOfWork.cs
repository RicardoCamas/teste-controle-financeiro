using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Domain.Core.Commands;
using ControleFinanceiro.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ControleFinanceiroContext _context;
        public UnitOfWork(ControleFinanceiroContext context)
        {
            _context = context;
        }
        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
