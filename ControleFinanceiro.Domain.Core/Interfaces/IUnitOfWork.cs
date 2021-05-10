using ControleFinanceiro.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
